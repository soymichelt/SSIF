CREATE OR ALTER TRIGGER dbo.[SalidaTrigger] ON SadaraDb.dbo.[Salida]
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

	DECLARE @salidaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @salidaId = IDSALIDA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Salida',
				@transactionType = @triggerTransactionType,
				@valueId = @salidaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @salidaId = IDSALIDA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Salida',
				@transactionType = @triggerTransactionType,
				@valueId = @salidaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE salidaCursor CURSOR FOR
				SELECT IDSALIDA FROM inserted;

		END
		ELSE BEGIN

			DECLARE salidaCursor CURSOR FOR
				SELECT IDSALIDA FROM deleted;

		END

		OPEN salidaCursor;

		FETCH NEXT FROM salidaCursor INTO
			@salidaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Salida',
				@transactionType = @triggerTransactionType,
				@valueId = @salidaId;

			FETCH NEXT FROM salidaCursor INTO
				@salidaId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO