CREATE OR ALTER TRIGGER dbo.[ImpuestoValorAgregadoTrigger] ON SadaraDb.dbo.[ImpuestoValorAgregado]
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

	DECLARE @impuestoValorAgregadoId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @impuestoValorAgregadoId = IDIVA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'ImpuestoValorAgregado',
				@transactionType = @triggerTransactionType,
				@valueId = @impuestoValorAgregadoId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @impuestoValorAgregadoId = IDIVA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'ImpuestoValorAgregado',
				@transactionType = @triggerTransactionType,
				@valueId = @impuestoValorAgregadoId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE impuestoValorAgregadoCursor CURSOR FOR
				SELECT IDIVA FROM inserted;

		END
		ELSE BEGIN

			DECLARE impuestoValorAgregadoCursor CURSOR FOR
				SELECT IDIVA FROM deleted;

		END

		OPEN impuestoValorAgregadoCursor;

		FETCH NEXT FROM impuestoValorAgregadoCursor INTO
			@impuestoValorAgregadoId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'ImpuestoValorAgregado',
				@transactionType = @triggerTransactionType,
				@valueId = @impuestoValorAgregadoId;

			FETCH NEXT FROM impuestoValorAgregadoCursor INTO
				@impuestoValorAgregadoId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO