CREATE OR ALTER TRIGGER dbo.[CompraReciboTrigger] ON SadaraDb.dbo.[CompraRecibo]
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

	DECLARE @compraReciboId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @compraReciboId = IDRECIBO FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraRecibo',
				@transactionType = @triggerTransactionType,
				@valueId = @compraReciboId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @compraReciboId = IDRECIBO FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraRecibo',
				@transactionType = @triggerTransactionType,
				@valueId = @compraReciboId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE compraReciboCursor CURSOR FOR
				SELECT IDRECIBO FROM inserted;

		END
		ELSE BEGIN

			DECLARE compraReciboCursor CURSOR FOR
				SELECT IDRECIBO FROM deleted;

		END

		OPEN compraReciboCursor;

		FETCH NEXT FROM compraReciboCursor INTO
			@compraReciboId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraRecibo',
				@transactionType = @triggerTransactionType,
				@valueId = @compraReciboId;

			FETCH NEXT FROM compraReciboCursor INTO
				@compraReciboId;

		END

		CLOSE compraReciboCursor;
		DEALLOCATE compraReciboCursor;

	END
	
GO