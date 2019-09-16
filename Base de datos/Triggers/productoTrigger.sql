CREATE OR ALTER TRIGGER dbo.[ProductoTrigger] ON SadaraDb.dbo.[Producto]
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

	DECLARE @productoId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @productoId = IDPRODUCTO FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Producto',
				@transactionType = @triggerTransactionType,
				@valueId = @productoId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @productoId = IDPRODUCTO FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Producto',
				@transactionType = @triggerTransactionType,
				@valueId = @productoId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE productoCursor CURSOR FOR
				SELECT IDPRODUCTO FROM inserted;

		END
		ELSE BEGIN

			DECLARE productoCursor CURSOR FOR
				SELECT IDPRODUCTO FROM deleted;

		END

		OPEN productoCursor;

		FETCH NEXT FROM productoCursor INTO
			@productoId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Producto',
				@transactionType = @triggerTransactionType,
				@valueId = @productoId;

			FETCH NEXT FROM productoCursor INTO
				@productoId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO