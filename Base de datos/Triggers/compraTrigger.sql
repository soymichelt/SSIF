CREATE OR ALTER TRIGGER dbo.[CompraTrigger] ON SadaraDb.dbo.[Compra]
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

	DECLARE @compraId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @compraId = IDCOMPRA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Compra',
				@transactionType = @triggerTransactionType,
				@valueId = @compraId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @compraId = IDCOMPRA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Compra',
				@transactionType = @triggerTransactionType,
				@valueId = @compraId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE compraCursor CURSOR FOR
				SELECT IDCOMPRA FROM inserted;

		END
		ELSE BEGIN

			DECLARE compraCursor CURSOR FOR
				SELECT IDCOMPRA FROM deleted;

		END

		OPEN compraCursor;

		FETCH NEXT FROM compraCursor INTO
			@compraId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Compra',
				@transactionType = @triggerTransactionType,
				@valueId = @compraId;

			FETCH NEXT FROM compraCursor INTO
				@compraId;

		END

		CLOSE compraCursor;
		DEALLOCATE compraCursor;

	END
	
GO