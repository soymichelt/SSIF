CREATE OR ALTER TRIGGER dbo.[EntradaTrigger] ON SadaraDb.dbo.[Entrada]
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

	DECLARE @entradaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @entradaId = IDENTRADA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Entrada',
				@transactionType = @triggerTransactionType,
				@valueId = @entradaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @entradaId = IDENTRADA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Entrada',
				@transactionType = @triggerTransactionType,
				@valueId = @entradaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE entradaCursor CURSOR FOR
				SELECT IDENTRADA FROM inserted;

		END
		ELSE BEGIN

			DECLARE entradaCursor CURSOR FOR
				SELECT IDENTRADA FROM deleted;

		END

		OPEN entradaCursor;

		FETCH NEXT FROM entradaCursor INTO
			@entradaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Entrada',
				@transactionType = @triggerTransactionType,
				@valueId = @entradaId;

			FETCH NEXT FROM entradaCursor INTO
				@entradaId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO