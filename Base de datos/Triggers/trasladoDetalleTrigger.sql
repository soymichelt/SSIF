CREATE OR ALTER TRIGGER dbo.[TrasladoDetalleTrigger] ON SadaraDb.dbo.[TrasladoDetalle]
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

	DECLARE @trasladoDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @trasladoDetalleId = IDDETALLETRASLADO FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'TrasladoDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @trasladoDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @trasladoDetalleId = IDDETALLETRASLADO FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'TrasladoDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @trasladoDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE trasladoDetalleCursor CURSOR FOR
				SELECT IDDETALLETRASLADO FROM inserted;

		END
		ELSE BEGIN

			DECLARE trasladoDetalleCursor CURSOR FOR
				SELECT IDDETALLETRASLADO FROM deleted;

		END

		OPEN trasladoDetalleCursor;

		FETCH NEXT FROM trasladoDetalleCursor INTO
			@trasladoDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'TrasladoDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @trasladoDetalleId;

			FETCH NEXT FROM trasladoDetalleCursor INTO
				@trasladoDetalleId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO