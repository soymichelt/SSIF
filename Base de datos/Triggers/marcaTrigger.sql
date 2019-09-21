CREATE OR ALTER TRIGGER dbo.[MarcaTrigger] ON SadaraDb.dbo.[Marca]
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

	DECLARE @marcaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @marcaId = IDMARCA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Marca',
				@transactionType = @triggerTransactionType,
				@valueId = @marcaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @marcaId = IDMARCA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Marca',
				@transactionType = @triggerTransactionType,
				@valueId = @marcaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE marcaCursor CURSOR FOR
				SELECT IDMARCA FROM inserted;

		END
		ELSE BEGIN

			DECLARE marcaCursor CURSOR FOR
				SELECT IDMARCA FROM deleted;

		END

		OPEN marcaCursor;

		FETCH NEXT FROM marcaCursor INTO
			@marcaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Marca',
				@transactionType = @triggerTransactionType,
				@valueId = @marcaId;

			FETCH NEXT FROM marcaCursor INTO
				@marcaId;

		END

		CLOSE marcaCursor;
		DEALLOCATE marcaCursor;

	END
	
GO