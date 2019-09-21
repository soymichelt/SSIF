CREATE OR ALTER TRIGGER dbo.[VentaTrigger] ON SadaraDb.dbo.[Venta]
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

	DECLARE @ventaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @ventaId = IDVENTA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Venta',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @ventaId = IDVENTA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Venta',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE ventaCursor CURSOR FOR
				SELECT IDVENTA FROM inserted;

		END
		ELSE BEGIN

			DECLARE ventaCursor CURSOR FOR
				SELECT IDVENTA FROM deleted;

		END

		OPEN ventaCursor;

		FETCH NEXT FROM ventaCursor INTO
			@ventaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Venta',
				@transactionType = @triggerTransactionType,
				@valueId = @ventaId;

			FETCH NEXT FROM ventaCursor INTO
				@ventaId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO