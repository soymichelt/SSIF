CREATE OR ALTER TRIGGER dbo.[DesconsignacionTrigger] ON SadaraDb.dbo.[Desconsignacion]
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

	DECLARE @desconsignacionId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @desconsignacionId = IDDESCONSIGNACION FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Desconsignacion',
				@transactionType = @triggerTransactionType,
				@valueId = @desconsignacionId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @desconsignacionId = IDDESCONSIGNACION FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Desconsignacion',
				@transactionType = @triggerTransactionType,
				@valueId = @desconsignacionId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE desconsignacionCursor CURSOR FOR
				SELECT IDDESCONSIGNACION FROM inserted;

		END
		ELSE BEGIN

			DECLARE desconsignacionCursor CURSOR FOR
				SELECT IDDESCONSIGNACION FROM deleted;

		END

		OPEN desconsignacionCursor;

		FETCH NEXT FROM desconsignacionCursor INTO
			@desconsignacionId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Desconsignacion',
				@transactionType = @triggerTransactionType,
				@valueId = @desconsignacionId;

			FETCH NEXT FROM desconsignacionCursor INTO
				@desconsignacionId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO