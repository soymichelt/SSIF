CREATE OR ALTER TRIGGER dbo.[TazaTrigger] ON SadaraDb.dbo.[Taza]
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

	DECLARE @tazaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @tazaId = IDTAZA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Taza',
				@transactionType = @triggerTransactionType,
				@valueId = @tazaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @tazaId = IDTAZA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Taza',
				@transactionType = @triggerTransactionType,
				@valueId = @tazaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE tazaCursor CURSOR FOR
				SELECT IDTAZA FROM inserted;

		END
		ELSE BEGIN

			DECLARE tazaCursor CURSOR FOR
				SELECT IDTAZA FROM deleted;

		END

		OPEN tazaCursor;

		FETCH NEXT FROM tazaCursor INTO
			@tazaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Taza',
				@transactionType = @triggerTransactionType,
				@valueId = @tazaId;

			FETCH NEXT FROM tazaCursor INTO
				@tazaId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO