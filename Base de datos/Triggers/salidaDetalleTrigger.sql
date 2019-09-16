CREATE OR ALTER TRIGGER dbo.[SalidaDetalleTrigger] ON SadaraDb.dbo.[SalidaDetalle]
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

	DECLARE @salidaDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @salidaDetalleId = IDDETALLESALIDA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'SalidaDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @salidaDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @salidaDetalleId = IDDETALLESALIDA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'SalidaDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @salidaDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE salidaDetalleCursor CURSOR FOR
				SELECT IDDETALLESALIDA FROM inserted;

		END
		ELSE BEGIN

			DECLARE salidaDetalleCursor CURSOR FOR
				SELECT IDDETALLESALIDA FROM deleted;

		END

		OPEN salidaDetalleCursor;

		FETCH NEXT FROM salidaDetalleCursor INTO
			@salidaDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'SalidaDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @salidaDetalleId;

			FETCH NEXT FROM salidaDetalleCursor INTO
				@salidaDetalleId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO