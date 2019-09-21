CREATE OR ALTER TRIGGER dbo.[VentaDetalleTrigger] ON SadaraDb.dbo.[VentaDetalle]
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

	DECLARE @ventaDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @ventaDetalleId = IDDETALLEVENTA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @ventaDetalleId = IDDETALLEVENTA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE ventaDetalleCursor CURSOR FOR
				SELECT IDDETALLEVENTA FROM inserted;

		END
		ELSE BEGIN

			DECLARE ventaDetalleCursor CURSOR FOR
				SELECT IDDETALLEVENTA FROM deleted;

		END

		OPEN ventaDetalleCursor;

		FETCH NEXT FROM ventaDetalleCursor INTO
			@ventaDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaDetalleId;

			FETCH NEXT FROM ventaDetalleCursor INTO
				@ventaDetalleId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO