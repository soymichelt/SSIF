CREATE OR ALTER TRIGGER dbo.[updateMarca]
ON Marca
AFTER  UPDATE
AS
	DECLARE
		@marcaId UNIQUEIDENTIFIER,
		@n BIGINT,
		@reg DATETIME,
		@descripcion VARCHAR(50),
		@activo VARCHAR(1)
	;
	
	DECLARE marcaCursor CURSOR FOR
	SELECT * FROM inserted;

	OPEN marcaCursor;

	FETCH NEXT FROM marcaCursor
		INTO @marcaId, @n, @reg, @descripcion, @activo;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @marcaId
		PRINT @n
		PRINT @reg
		PRINT @descripcion
		PRINT @activo
		PRINT '-----------------------------------------'
		
		FETCH NEXT FROM marcaCursor
			INTO @marcaId, @n, @reg, @descripcion, @activo;

	END

	CLOSE marcaCursor;
	DEALLOCATE marcaCursor;

GO

SELECT * FROM Marca
GO

INSERT INTO Marca
(
	IDMARCA,
	Reg,
	DESCRIPCION,
	ACTIVO
)
VALUES (
	NEWID(),
	GETDATE(),
	'DESCRIPCION 4',
	'S'
)

update Marca set Reg = getdate()