CREATE OR ALTER TRIGGER dbo.[CompraReciboDetalleTrigger] ON SadaraDb.dbo.[CompraReciboDetalle]
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

	DECLARE @compraReciboDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @compraReciboDetalleId = IDDETALLERECIBO FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraReciboDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @compraReciboDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @compraReciboDetalleId = IDDETALLERECIBO FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraReciboDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @compraReciboDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE compraReciboDetalleCursor CURSOR FOR
				SELECT IDDETALLERECIBO FROM inserted;

		END
		ELSE BEGIN

			DECLARE compraReciboDetalleCursor CURSOR FOR
				SELECT IDDETALLERECIBO FROM deleted;

		END

		OPEN compraReciboDetalleCursor;

		FETCH NEXT FROM compraReciboDetalleCursor INTO
			@compraReciboDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraReciboDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @compraReciboDetalleId;

			FETCH NEXT FROM compraReciboDetalleCursor INTO
				@compraReciboDetalleId;

		END

		CLOSE compraReciboDetalleCursor;
		DEALLOCATE compraReciboDetalleCursor;

	END
	
GO