CREATE OR ALTER TRIGGER dbo.[TrasladoTrigger] ON SadaraDb.dbo.[Traslado]
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

	DECLARE @trasladoId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @trasladoId = IDTRASLADO FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Traslado',
				@transactionType = @triggerTransactionType,
				@valueId = @trasladoId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @trasladoId = IDTRASLADO FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Traslado',
				@transactionType = @triggerTransactionType,
				@valueId = @trasladoId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE trasladoCursor CURSOR FOR
				SELECT IDTRASLADO FROM inserted;

		END
		ELSE BEGIN

			DECLARE trasladoCursor CURSOR FOR
				SELECT IDTRASLADO FROM deleted;

		END

		OPEN trasladoCursor;

		FETCH NEXT FROM trasladoCursor INTO
			@trasladoId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Traslado',
				@transactionType = @triggerTransactionType,
				@valueId = @trasladoId;

			FETCH NEXT FROM trasladoCursor INTO
				@trasladoId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO