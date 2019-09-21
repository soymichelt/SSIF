CREATE OR ALTER TRIGGER dbo.[CotizacionTrigger] ON SadaraDb.dbo.[Cotizacion]
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

	DECLARE @cotizacionId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @cotizacionId = IDCOTIZACION FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Cotizacion',
				@transactionType = @triggerTransactionType,
				@valueId = @cotizacionId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @cotizacionId = IDCOTIZACION FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Cotizacion',
				@transactionType = @triggerTransactionType,
				@valueId = @cotizacionId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE cotizacionCursor CURSOR FOR
				SELECT IDCOTIZACION FROM inserted;

		END
		ELSE BEGIN

			DECLARE cotizacionCursor CURSOR FOR
				SELECT IDCOTIZACION FROM deleted;

		END

		OPEN cotizacionCursor;

		FETCH NEXT FROM cotizacionCursor INTO
			@cotizacionId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Cotizacion',
				@transactionType = @triggerTransactionType,
				@valueId = @cotizacionId;

			FETCH NEXT FROM cotizacionCursor INTO
				@cotizacionId;

		END

		CLOSE cotizacionCursor;
		DEALLOCATE cotizacionCursor;

	END
	
GO