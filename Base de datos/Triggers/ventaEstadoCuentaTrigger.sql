CREATE OR ALTER TRIGGER dbo.[VentaEstadoCuentaTrigger] ON SadaraDb.dbo.[VentaEstadoCuenta]
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

	DECLARE @ventaEstadoCuentaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @ventaEstadoCuentaId = IDESTADO FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaEstadoCuenta',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaEstadoCuentaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @ventaEstadoCuentaId = IDESTADO FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaEstadoCuenta',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaEstadoCuentaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE ventaEstadoCuentaCursor CURSOR FOR
				SELECT IDESTADO FROM inserted;

		END
		ELSE BEGIN

			DECLARE ventaEstadoCuentaCursor CURSOR FOR
				SELECT IDESTADO FROM deleted;

		END

		OPEN ventaEstadoCuentaCursor;

		FETCH NEXT FROM ventaEstadoCuentaCursor INTO
			@ventaEstadoCuentaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaEstadoCuenta',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaEstadoCuentaId;

			FETCH NEXT FROM ventaEstadoCuentaCursor INTO
				@ventaEstadoCuentaId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO