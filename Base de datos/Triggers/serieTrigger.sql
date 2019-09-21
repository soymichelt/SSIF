CREATE OR ALTER TRIGGER dbo.[SerieTrigger] ON SadaraDb.dbo.[Serie]
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

	DECLARE @serieId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @serieId = IDSERIE FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Serie',
				@transactionType = @triggerTransactionType,
				@valueId = @serieId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @serieId = IDSERIE FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Serie',
				@transactionType = @triggerTransactionType,
				@valueId = @serieId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE serieCursor CURSOR FOR
				SELECT IDSERIE FROM inserted;

		END
		ELSE BEGIN

			DECLARE serieCursor CURSOR FOR
				SELECT IDSERIE FROM deleted;

		END

		OPEN serieCursor;

		FETCH NEXT FROM serieCursor INTO
			@serieId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Serie',
				@transactionType = @triggerTransactionType,
				@valueId = @serieId;

			FETCH NEXT FROM serieCursor INTO
				@serieId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO