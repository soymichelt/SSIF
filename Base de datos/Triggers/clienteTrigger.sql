CREATE OR ALTER TRIGGER dbo.[ClienteTrigger] ON SadaraDb.dbo.[Cliente]
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

	DECLARE @clienteId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @clienteId = IDCLIENTE FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Cliente',
				@transactionType = @triggerTransactionType,
				@valueId = @clienteId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @clienteId = IDCLIENTE FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Cliente',
				@transactionType = @triggerTransactionType,
				@valueId = @clienteId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE clienteCursor CURSOR FOR
				SELECT IDCLIENTE FROM inserted;

		END
		ELSE BEGIN

			DECLARE clienteCursor CURSOR FOR
				SELECT IDCLIENTE FROM deleted;

		END

		OPEN clienteCursor;

		FETCH NEXT FROM clienteCursor INTO
			@clienteId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Cliente',
				@transactionType = @triggerTransactionType,
				@valueId = @clienteId;

			FETCH NEXT FROM clienteCursor INTO
				@clienteId;

		END

		CLOSE clienteCursor;
		DEALLOCATE clienteCursor;

	END
	
GO