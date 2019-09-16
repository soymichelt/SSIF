CREATE OR ALTER TRIGGER dbo.[CotizacionDetalleTrigger] ON SadaraDb.dbo.[CotizacionDetalle]
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

	DECLARE @cotizacionDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @cotizacionDetalleId = IDDETALLECOTIZACION FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CotizacionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @cotizacionDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @cotizacionDetalleId = IDDETALLECOTIZACION FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CotizacionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @cotizacionDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE cotizacionDetalleCursor CURSOR FOR
				SELECT IDDETALLECOTIZACION FROM inserted;

		END
		ELSE BEGIN

			DECLARE cotizacionDetalleCursor CURSOR FOR
				SELECT IDDETALLECOTIZACION FROM deleted;

		END

		OPEN cotizacionDetalleCursor;

		FETCH NEXT FROM cotizacionDetalleCursor INTO
			@cotizacionDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CotizacionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @cotizacionDetalleId;

			FETCH NEXT FROM cotizacionDetalleCursor INTO
				@cotizacionDetalleId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO