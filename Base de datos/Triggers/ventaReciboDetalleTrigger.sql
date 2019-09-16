CREATE OR ALTER TRIGGER dbo.[VentaReciboDetalleTrigger] ON SadaraDb.dbo.[VentaReciboDetalle]
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

	DECLARE @ventaReciboDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @ventaReciboDetalleId = IDDETALLERECIBO FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaReciboDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaReciboDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @ventaReciboDetalleId = IDDETALLERECIBO FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaReciboDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaReciboDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE ventaReciboDetalleCursor CURSOR FOR
				SELECT IDDETALLERECIBO FROM inserted;

		END
		ELSE BEGIN

			DECLARE ventaReciboDetalleCursor CURSOR FOR
				SELECT IDDETALLERECIBO FROM deleted;

		END

		OPEN ventaReciboDetalleCursor;

		FETCH NEXT FROM ventaReciboDetalleCursor INTO
			@ventaReciboDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaReciboDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaReciboDetalleId;

			FETCH NEXT FROM ventaReciboDetalleCursor INTO
				@ventaReciboDetalleId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO