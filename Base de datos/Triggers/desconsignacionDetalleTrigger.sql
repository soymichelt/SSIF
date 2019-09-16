CREATE OR ALTER TRIGGER dbo.[DesconsignacionDetalleTrigger] ON SadaraDb.dbo.[DesconsignacionDetalle]
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

	DECLARE @desconsignacionDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @desconsignacionDetalleId = IDDETALLEDESCONSIGNACION FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'DesconsignacionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @desconsignacionDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @desconsignacionDetalleId = IDDETALLEDESCONSIGNACION FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'DesconsignacionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @desconsignacionDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE desconsignacionDetalleCursor CURSOR FOR
				SELECT IDDETALLEDESCONSIGNACION FROM inserted;

		END
		ELSE BEGIN

			DECLARE desconsignacionDetalleCursor CURSOR FOR
				SELECT IDDETALLEDESCONSIGNACION FROM deleted;

		END

		OPEN desconsignacionDetalleCursor;

		FETCH NEXT FROM desconsignacionDetalleCursor INTO
			@desconsignacionDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'DesconsignacionDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @desconsignacionDetalleId;

			FETCH NEXT FROM desconsignacionDetalleCursor INTO
				@desconsignacionDetalleId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO