CREATE OR ALTER TRIGGER dbo.[KardexTrigger] ON SadaraDb.dbo.[Kardex]
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

	DECLARE @kardexId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @kardexId = IDKARDEX FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Kardex',
				@transactionType = @triggerTransactionType,
				@valueId = @kardexId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @kardexId = IDKARDEX FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Kardex',
				@transactionType = @triggerTransactionType,
				@valueId = @kardexId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE kardexCursor CURSOR FOR
				SELECT IDKARDEX FROM inserted;

		END
		ELSE BEGIN

			DECLARE kardexCursor CURSOR FOR
				SELECT IDKARDEX FROM deleted;

		END

		OPEN kardexCursor;

		FETCH NEXT FROM kardexCursor INTO
			@kardexId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Kardex',
				@transactionType = @triggerTransactionType,
				@valueId = @kardexId;

			FETCH NEXT FROM kardexCursor INTO
				@kardexId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO