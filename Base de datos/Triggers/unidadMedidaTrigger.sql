CREATE OR ALTER TRIGGER dbo.[UnidadMedidaTrigger] ON SadaraDb.dbo.[UnidadMedida]
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

	DECLARE @unidadMedidaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @unidadMedidaId = IDUNIDAD FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'UnidadMedida',
				@transactionType = @triggerTransactionType,
				@valueId = @unidadMedidaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @unidadMedidaId = IDUNIDAD FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'UnidadMedida',
				@transactionType = @triggerTransactionType,
				@valueId = @unidadMedidaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE unidadMedidaCursor CURSOR FOR
				SELECT IDUNIDAD FROM inserted;

		END
		ELSE BEGIN

			DECLARE unidadMedidaCursor CURSOR FOR
				SELECT IDUNIDAD FROM deleted;

		END

		OPEN unidadMedidaCursor;

		FETCH NEXT FROM unidadMedidaCursor INTO
			@unidadMedidaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'UnidadMedida',
				@transactionType = @triggerTransactionType,
				@valueId = @unidadMedidaId;

			FETCH NEXT FROM unidadMedidaCursor INTO
				@unidadMedidaId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO