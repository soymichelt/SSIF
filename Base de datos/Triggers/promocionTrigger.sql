CREATE OR ALTER TRIGGER dbo.[PromocionTrigger] ON SadaraDb.dbo.[Promocion]
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

	DECLARE @promocionId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @promocionId = PromocionID FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Promocion',
				@transactionType = @triggerTransactionType,
				@valueId = @promocionId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @promocionId = PromocionID FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Promocion',
				@transactionType = @triggerTransactionType,
				@valueId = @promocionId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE promocionCursor CURSOR FOR
				SELECT PromocionID FROM inserted;

		END
		ELSE BEGIN

			DECLARE promocionCursor CURSOR FOR
				SELECT PromocionID FROM deleted;

		END

		OPEN promocionCursor;

		FETCH NEXT FROM promocionCursor INTO
			@promocionId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Promocion',
				@transactionType = @triggerTransactionType,
				@valueId = @promocionId;

			FETCH NEXT FROM promocionCursor INTO
				@promocionId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO