CREATE OR ALTER TRIGGER dbo.[EmpleadoTrigger] ON SadaraDb.dbo.[Empleado]
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

	DECLARE @empleadoId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @empleadoId = IDEMPLEADO FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Empleado',
				@transactionType = @triggerTransactionType,
				@valueId = @empleadoId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @empleadoId = IDEMPLEADO FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Empleado',
				@transactionType = @triggerTransactionType,
				@valueId = @empleadoId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE empleadoCursor CURSOR FOR
				SELECT IDEMPLEADO FROM inserted;

		END
		ELSE BEGIN

			DECLARE empleadoCursor CURSOR FOR
				SELECT IDEMPLEADO FROM deleted;

		END

		OPEN empleadoCursor;

		FETCH NEXT FROM empleadoCursor INTO
			@empleadoId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Empleado',
				@transactionType = @triggerTransactionType,
				@valueId = @empleadoId;

			FETCH NEXT FROM empleadoCursor INTO
				@empleadoId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO