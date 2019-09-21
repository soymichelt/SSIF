CREATE OR ALTER TRIGGER dbo.[EmpresaTrigger] ON SadaraDb.dbo.[Empresa]
	AFTER INSERT, UPDATE, DELETE
AS

	DECLARE @triggerTransactionType AS VARCHAR(10);

	IF EXISTS(SELECT 1 FROM inserted) BEGIN
		IF NOT EXISTS(SELECT 1 FROM deleted) BEGIN
			SET @triggerTransactionType = 'INSERT';
		END
		ELSE BEGIN
			SET @triggerTransactionType = 'UPDATE';
		END
	END
	ELSE BEGIN
		SET @triggerTransactionType = 'DELETE';
	END

	DECLARE @countRegs INT;
	SET @countRegs = (SELECT COUNT(*) AS countRegs FROM inserted);

	DECLARE @countRegsDeleted INT;
	SET @countRegsDeleted = (SELECT COUNT(*) AS countRegs FROM deleted);

	DECLARE @empresaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @empresaId = IdEmpresa FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Empresa',
				@transactionType = @triggerTransactionType,
				@valueId = @empresaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @empresaId = IdEmpresa FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Empresa',
				@transactionType = @triggerTransactionType,
				@valueId = @empresaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE empresaCursor CURSOR FOR
				SELECT IdEmpresa FROM inserted;

		END
		ELSE BEGIN

			DECLARE empresaCursor CURSOR FOR
				SELECT IdEmpresa FROM deleted;

		END

		OPEN empresaCursor;

		FETCH NEXT FROM empresaCursor INTO
			@empresaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Empresa',
				@transactionType = @triggerTransactionType,
				@valueId = @empresaId;

			FETCH NEXT FROM empresaCursor INTO
				@empresaId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO