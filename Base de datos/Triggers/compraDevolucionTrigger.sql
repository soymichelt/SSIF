CREATE OR ALTER TRIGGER dbo.[CompraDevolucionTrigger] ON SadaraDb.dbo.[CompraDevolucion]
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

	DECLARE @compraDevolucionId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @compraDevolucionId = IDDEVOLUCION FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraDevolucion',
				@transactionType = @triggerTransactionType,
				@valueId = @compraDevolucionId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @compraDevolucionId = IDDEVOLUCION FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraDevolucion',
				@transactionType = @triggerTransactionType,
				@valueId = @compraDevolucionId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE compraDevolucionCursor CURSOR FOR
				SELECT IDDEVOLUCION FROM inserted;

		END
		ELSE BEGIN

			DECLARE compraDevolucionCursor CURSOR FOR
				SELECT IDDEVOLUCION FROM deleted;

		END

		OPEN compraDevolucionCursor;

		FETCH NEXT FROM compraDevolucionCursor INTO
			@compraDevolucionId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraDevolucion',
				@transactionType = @triggerTransactionType,
				@valueId = @compraDevolucionId;

			FETCH NEXT FROM compraDevolucionCursor INTO
				@compraDevolucionId;

		END

		CLOSE compraDevolucionCursor;
		DEALLOCATE compraDevolucionCursor;

	END
	
GO