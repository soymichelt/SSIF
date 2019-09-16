CREATE OR ALTER TRIGGER dbo.[VentaDevolucionDetalleTrigger] ON SadaraDb.dbo.[VentaDevolucionDetalle]
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

	DECLARE @ventaDevolucionDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @ventaDevolucionDetalleId = IDDETALLEDEVOLUCION FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaDevolucionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaDevolucionDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @ventaDevolucionDetalleId = IDDETALLEDEVOLUCION FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaDevolucionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaDevolucionDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE ventaDevolucionDetalleCursor CURSOR FOR
				SELECT IDDETALLEDEVOLUCION FROM inserted;

		END
		ELSE BEGIN

			DECLARE ventaDevolucionDetalleCursor CURSOR FOR
				SELECT IDDETALLEDEVOLUCION FROM deleted;

		END

		OPEN ventaDevolucionDetalleCursor;

		FETCH NEXT FROM ventaDevolucionDetalleCursor INTO
			@ventaDevolucionDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaDevolucionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaDevolucionDetalleId;

			FETCH NEXT FROM ventaDevolucionDetalleCursor INTO
				@ventaDevolucionDetalleId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO