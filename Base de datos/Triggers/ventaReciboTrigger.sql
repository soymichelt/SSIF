CREATE OR ALTER TRIGGER dbo.[VentaReciboTrigger] ON SadaraDb.dbo.[VentaRecibo]
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

	DECLARE @ventaReciboId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @ventaReciboId = IDRECIBO FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaRecibo',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaReciboId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @ventaReciboId = IDRECIBO FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaRecibo',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaReciboId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE ventaReciboCursor CURSOR FOR
				SELECT IDRECIBO FROM inserted;

		END
		ELSE BEGIN

			DECLARE ventaReciboCursor CURSOR FOR
				SELECT IDRECIBO FROM deleted;

		END

		OPEN ventaReciboCursor;

		FETCH NEXT FROM ventaReciboCursor INTO
			@ventaReciboId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'VentaRecibo',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaReciboId;

			FETCH NEXT FROM ventaReciboCursor INTO
				@ventaReciboId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO