CREATE OR ALTER TRIGGER dbo.[CompraDevolucionDetalleTrigger] ON SadaraDb.dbo.[CompraDevolucionDetalle]
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

	DECLARE @compraDevolucionDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @compraDevolucionDetalleId = IDDETALLEDEVOLUCION FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraDevolucionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @compraDevolucionDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @compraDevolucionDetalleId = IDDETALLEDEVOLUCION FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraDevolucionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @compraDevolucionDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE compraDevolucionDetalleCursor CURSOR FOR
				SELECT IDDETALLEDEVOLUCION FROM inserted;

		END
		ELSE BEGIN

			DECLARE compraDevolucionDetalleCursor CURSOR FOR
				SELECT IDDETALLEDEVOLUCION FROM deleted;

		END

		OPEN compraDevolucionDetalleCursor;

		FETCH NEXT FROM compraDevolucionDetalleCursor INTO
			@compraDevolucionDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'CompraDevolucionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @compraDevolucionDetalleId;

			FETCH NEXT FROM compraDevolucionDetalleCursor INTO
				@compraDevolucionDetalleId;

		END

		CLOSE compraDevolucionDetalleCursor;
		DEALLOCATE compraDevolucionDetalleCursor;

	END
	
GO