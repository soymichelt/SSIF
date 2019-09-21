CREATE OR ALTER TRIGGER dbo.[PresentacionTrigger] ON SadaraDb.dbo.[Presentacion]
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

	DECLARE @presentacionId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @presentacionId = IDPRESENTACION FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Presentacion',
				@transactionType = @triggerTransactionType,
				@valueId = @presentacionId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @presentacionId = IDPRESENTACION FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Presentacion',
				@transactionType = @triggerTransactionType,
				@valueId = @presentacionId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE presentacionCursor CURSOR FOR
				SELECT IDPRESENTACION FROM inserted;

		END
		ELSE BEGIN

			DECLARE presentacionCursor CURSOR FOR
				SELECT IDPRESENTACION FROM deleted;

		END

		OPEN presentacionCursor;

		FETCH NEXT FROM presentacionCursor INTO
			@presentacionId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Presentacion',
				@transactionType = @triggerTransactionType,
				@valueId = @presentacionId;

			FETCH NEXT FROM presentacionCursor INTO
				@presentacionId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO