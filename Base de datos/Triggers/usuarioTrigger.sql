CREATE OR ALTER TRIGGER dbo.[UsuarioTrigger] ON SadaraDb.dbo.[Usuario]
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

	DECLARE @usuarioId VARCHAR(36);

	IF (@countRegs = 1 OR @countRegsDeleted = 1) BEGIN

		IF @countRegs = 1 BEGIN

			SELECT TOP 1 @usuarioId = IDUsuario FROM inserted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Usuario',
				@transactionType = @triggerTransactionType,
				@valueId = @usuarioId;

		END
		ELSE BEGIN
			
			SELECT TOP 1 @usuarioId = IDUsuario FROM deleted;
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Usuario',
				@transactionType = @triggerTransactionType,
				@valueId = @usuarioId;

		END
		
	END
	ELSE BEGIN
		
		IF(@countRegs = 1) BEGIN
			
			DECLARE usuarioCursor CURSOR FOR
				SELECT IDUsuario FROM inserted;

		END
		ELSE BEGIN

			DECLARE usuarioCursor CURSOR FOR
				SELECT IDUsuario FROM deleted;

		END

		OPEN usuarioCursor;

		FETCH NEXT FROM usuarioCursor INTO
			@usuarioId;

		WHILE @@FETCH_STATUS = 0 BEGIN
			
			EXEC [dbo].SpInsertDataForSync
				@tableName = 'Usuario',
				@transactionType = @triggerTransactionType,
				@valueId = @usuarioId;

			FETCH NEXT FROM usuarioCursor INTO
				@usuarioId;

		END

		CLOSE cotizacionDetalleCursor;
		DEALLOCATE cotizacionDetalleCursor;

	END
	
GO