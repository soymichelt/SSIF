CREATE OR ALTER TRIGGER dbo.[BodegaTrigger] ON SadaraDb.dbo.[Bodega]
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

	DECLARE @bodegaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @bodegaId = IDBODEGA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Bodega',
				@transactionType = @triggerTransactionType,
				@valueId = @bodegaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @bodegaId = IDBODEGA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Bodega',
				@transactionType = @triggerTransactionType,
				@valueId = @bodegaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE bodegaCursor CURSOR FOR
				SELECT IDBODEGA FROM inserted;

		END
		ELSE BEGIN

			DECLARE bodegaCursor CURSOR FOR
				SELECT IDBODEGA FROM deleted;

		END

		OPEN bodegaCursor;

		FETCH NEXT FROM bodegaCursor INTO
			@bodegaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Bodega',
				@transactionType = @triggerTransactionType,
				@valueId = @bodegaId;

			FETCH NEXT FROM bodegaCursor INTO
				@bodegaId;

		END

		CLOSE bodegaCursor;
		DEALLOCATE bodegaCursor;

	END
	
GO