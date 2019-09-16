CREATE OR ALTER TRIGGER dbo.[ExistenciaTrigger] ON SadaraDb.dbo.[Existencia]
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

	DECLARE @existenciaId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @existenciaId = IDEXISTENCIA FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Existencia',
				@transactionType = @triggerTransactionType,
				@valueId = @existenciaId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @existenciaId = IDEXISTENCIA FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Existencia',
				@transactionType = @triggerTransactionType,
				@valueId = @existenciaId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE existenciaCursor CURSOR FOR
				SELECT IDEXISTENCIA FROM inserted;

		END
		ELSE BEGIN

			DECLARE existenciaCursor CURSOR FOR
				SELECT IDEXISTENCIA FROM deleted;

		END

		OPEN existenciaCursor;

		FETCH NEXT FROM existenciaCursor INTO
			@existenciaId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Existencia',
				@transactionType = @triggerTransactionType,
				@valueId = @existenciaId;

			FETCH NEXT FROM existenciaCursor INTO
				@existenciaId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO