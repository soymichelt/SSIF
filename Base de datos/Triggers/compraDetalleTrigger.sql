CREATE OR ALTER TRIGGER dbo.[CompraDetalleTrigger] ON SadaraDb.dbo.[CompraDetalle]
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

	DECLARE @compraDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @compraDetalleId = IDDETALLECOMPRA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @compraDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @compraDetalleId = IDDETALLECOMPRA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @compraDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE compraDetalleCursor CURSOR FOR
				SELECT IDDETALLECOMPRA FROM inserted;

		END
		ELSE BEGIN

			DECLARE compraDetalleCursor CURSOR FOR
				SELECT IDDETALLECOMPRA FROM deleted;

		END

		OPEN compraDetalleCursor;

		FETCH NEXT FROM compraDetalleCursor INTO
			@compraDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @compraDetalleId;

			FETCH NEXT FROM compraDetalleCursor INTO
				@compraDetalleId;

		END

		CLOSE compraDetalleCursor;
		DEALLOCATE compraDetalleCursor;

	END
	
GO