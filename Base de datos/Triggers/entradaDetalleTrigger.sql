CREATE OR ALTER TRIGGER dbo.[EntradaDetalleTrigger] ON SadaraDb.dbo.[EntradaDetalle]
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

	DECLARE @entradaDetalleId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @entradaDetalleId = IDDETALLEENTRADA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'EntradaDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @entradaDetalleId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @entradaDetalleId = IDDETALLEENTRADA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'EntradaDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @entradaDetalleId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE entradaDetalleCursor CURSOR FOR
				SELECT IDDETALLEENTRADA FROM inserted;

		END
		ELSE BEGIN

			DECLARE entradaDetalleCursor CURSOR FOR
				SELECT IDDETALLEENTRADA FROM deleted;

		END

		OPEN entradaDetalleCursor;

		FETCH NEXT FROM entradaDetalleCursor INTO
			@entradaDetalleId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'EntradaDetalle',
				@transactionType = @triggerTransactionType,
				@valueId = @entradaDetalleId;

			FETCH NEXT FROM entradaDetalleCursor INTO
				@entradaDetalleId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO