CREATE OR ALTER TRIGGER dbo.[PromocionExistenciaTrigger] ON SadaraDb.dbo.[PromocionExistencia]
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

	DECLARE @promocionExistenciaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @promocionExistenciaId = PromocionExistenciaID FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'PromocionExistencia',
				@transactionType = @triggerTransactionType,
				@valueId = @promocionExistenciaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @promocionExistenciaId = PromocionExistenciaID FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'PromocionExistencia',
				@transactionType = @triggerTransactionType,
				@valueId = @promocionExistenciaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE promocionExistenciaCursor CURSOR FOR
				SELECT PromocionExistenciaID FROM inserted;

		END
		ELSE BEGIN

			DECLARE promocionExistenciaCursor CURSOR FOR
				SELECT PromocionExistenciaID FROM deleted;

		END

		OPEN promocionExistenciaCursor;

		FETCH NEXT FROM promocionExistenciaCursor INTO
			@promocionExistenciaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'PromocionExistencia',
				@transactionType = @triggerTransactionType,
				@valueId = @promocionExistenciaId;

			FETCH NEXT FROM promocionExistenciaCursor INTO
				@promocionExistenciaId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO