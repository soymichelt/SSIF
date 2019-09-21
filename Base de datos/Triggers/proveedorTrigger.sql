CREATE OR ALTER TRIGGER dbo.[ProveedorTrigger] ON SadaraDb.dbo.[Proveedor]
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

	DECLARE @proveedorId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @proveedorId = IDPROVEEDOR FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Proveedor',
				@transactionType = @triggerTransactionType,
				@valueId = @proveedorId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @proveedorId = IDPROVEEDOR FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Proveedor',
				@transactionType = @triggerTransactionType,
				@valueId = @proveedorId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE proveedorCursor CURSOR FOR
				SELECT IDPROVEEDOR FROM inserted;

		END
		ELSE BEGIN

			DECLARE proveedorCursor CURSOR FOR
				SELECT IDPROVEEDOR FROM deleted;

		END

		OPEN proveedorCursor;

		FETCH NEXT FROM proveedorCursor INTO
			@proveedorId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Proveedor',
				@transactionType = @triggerTransactionType,
				@valueId = @proveedorId;

			FETCH NEXT FROM proveedorCursor INTO
				@proveedorId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO