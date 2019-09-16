CREATE OR ALTER TRIGGER dbo.[ConsignacionTrigger] ON SadaraDb.dbo.[Consignacion]
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

	DECLARE @consignacionId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @consignacionId = IDCONSIGNACION FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Consignacion',
				@transactionType = @triggerTransactionType,
				@valueId = @consignacionId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @consignacionId = IDCONSIGNACION FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Consignacion',
				@transactionType = @triggerTransactionType,
				@valueId = @consignacionId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE consignacionCursor CURSOR FOR
				SELECT IDCONSIGNACION FROM inserted;

		END
		ELSE BEGIN

			DECLARE consignacionCursor CURSOR FOR
				SELECT IDCONSIGNACION FROM deleted;

		END

		OPEN consignacionCursor;

		FETCH NEXT FROM consignacionCursor INTO
			@consignacionId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Consignacion',
				@transactionType = @triggerTransactionType,
				@valueId = @consignacionId;

			FETCH NEXT FROM consignacionCursor INTO
				@consignacionId;

		END

		CLOSE consignacionCursor;
		DEALLOCATE consignacionCursor;

	END
	
GO