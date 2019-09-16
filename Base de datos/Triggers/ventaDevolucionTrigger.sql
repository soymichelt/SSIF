CREATE OR ALTER TRIGGER dbo.[VentaDevolucionTrigger] ON SadaraDb.dbo.[VentaDevolucion]
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

	DECLARE @ventaDevolucionId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @ventaDevolucionId = IDDEVOLUCION FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaDevolucion',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaDevolucionId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @ventaDevolucionId = IDDEVOLUCION FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaDevolucion',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaDevolucionId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE ventaDevolucionCursor CURSOR FOR
				SELECT IDDEVOLUCION FROM inserted;

		END
		ELSE BEGIN

			DECLARE ventaDevolucionCursor CURSOR FOR
				SELECT IDDEVOLUCION FROM deleted;

		END

		OPEN ventaDevolucionCursor;

		FETCH NEXT FROM ventaDevolucionCursor INTO
			@ventaDevolucionId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaDevolucion',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaDevolucionId;

			FETCH NEXT FROM ventaDevolucionCursor INTO
				@ventaDevolucionId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO