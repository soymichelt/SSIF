CREATE OR ALTER TRIGGER dbo.[ConsignacionDetalleTrigger] ON SadaraDb.dbo.[ConsignacionDetalle]
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

	DECLARE @consignacionDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @consignacionDetalleId = IDDETALLECONSIGNACION FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'ConsignacionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @consignacionDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @consignacionDetalleId = IDDETALLECONSIGNACION FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'ConsignacionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @consignacionDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE consignacionDetalleCursor CURSOR FOR
				SELECT IDDETALLECONSIGNACION FROM inserted;

		END
		ELSE BEGIN

			DECLARE consignacionDetalleCursor CURSOR FOR
				SELECT IDDETALLECONSIGNACION FROM deleted;

		END

		OPEN consignacionDetalleCursor;

		FETCH NEXT FROM consignacionDetalleCursor INTO
			@consignacionDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'ConsignacionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @consignacionDetalleId;

			FETCH NEXT FROM consignacionDetalleCursor INTO
				@consignacionDetalleId;

		END

		CLOSE consignacionDetalleCursor;
		DEALLOCATE consignacionDetalleCursor;

	END
	
GO