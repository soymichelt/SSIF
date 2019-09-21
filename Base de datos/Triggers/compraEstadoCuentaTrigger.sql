CREATE OR ALTER TRIGGER dbo.[CompraEstadoCuentaTrigger] ON SadaraDb.dbo.[CompraEstadoCuenta]
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

	DECLARE @compraEstadoCuentaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @compraEstadoCuentaId = IDESTADO FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraEstadoCuenta',
				@transactionType = @triggerTransactionType,
				@valueId = @compraEstadoCuentaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @compraEstadoCuentaId = IDESTADO FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraEstadoCuenta',
				@transactionType = @triggerTransactionType,
				@valueId = @compraEstadoCuentaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE compraEstadoCuentaCursor CURSOR FOR
				SELECT IDESTADO FROM inserted;

		END
		ELSE BEGIN

			DECLARE compraEstadoCuentaCursor CURSOR FOR
				SELECT IDESTADO FROM deleted;

		END

		OPEN compraEstadoCuentaCursor;

		FETCH NEXT FROM compraEstadoCuentaCursor INTO
			@compraEstadoCuentaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraEstadoCuenta',
				@transactionType = @triggerTransactionType,
				@valueId = @compraEstadoCuentaId;

			FETCH NEXT FROM compraEstadoCuentaCursor INTO
				@compraEstadoCuentaId;

		END

		CLOSE compraEstadoCuentaCursor;
		DEALLOCATE compraEstadoCuentaCursor;

	END
	
GO