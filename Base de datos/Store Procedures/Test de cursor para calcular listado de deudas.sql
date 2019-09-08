/****** Object:  StoredProcedure [dbo].[SpCrearExistenciaPorBodega]    Script Date: 01/06/2017 03:19:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpListadoDeDeudas]
	-- Add the parameters for the stored procedure here
	@Money AS CHAR(1),
	@ExchangeRate AS DECIMAL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @IDCLIENTE UNIQUEIDENTIFIER;
	DECLARE @N_CLIENTE VARCHAR(50);
	DECLARE @IDENTIFICACION VARCHAR(50);
	DECLARE @NombreCliente VARCHAR(200);
	DECLARE @RAZONSOCIAL VARCHAR(200);
	DECLARE @TELEFONO VARCHAR(9);
	DECLARE @PLAZO INT;
	DECLARE @LIMITECREDITO DECIMAL(18, 4);
	DECLARE @VENTATOTAL DECIMAL(18, 4);

	DECLARE @TotalAbonos DECIMAL(18, 4);

	DECLARE VentaCliente CURSOR FOR
	SELECT
		Cliente.IDCLIENTE,
		Cliente.N_CLIENTE,
		Cliente.IDENTIFICACION,
		Cliente.NOMBRES + ' ' + Cliente.APELLIDOS AS NombreCliente,
		Cliente.RAZONSOCIAL,
		Cliente.TELEFONO,
		Cliente.PLAZO,
		CASE @Money WHEN Cliente.MONEDA THEN
			Cliente.LIMITECREDITO
		ELSE
			CASE @Money WHEN 'C' THEN
				Cliente.LIMITECREDITO * @ExchangeRate
			ELSE
				Cliente.LIMITECREDITO / @ExchangeRate
			END
		END
		AS
			LIMITECREDITO,
		CASE @Money WHEN Cliente.MONEDA THEN
			Venta.SALDOCREDITO
		ELSE
			CASE @Money WHEN 'C' THEN
				Venta.SALDOCREDITO * @ExchangeRate
			ELSE
				Venta.SALDOCREDITO / @ExchangeRate
			END
		END
		AS
			VENTATOTAL
	FROM
		Cliente INNER JOIN
		Venta ON Cliente.IDCLIENTE = Venta.IDCLIENTE
	WHERE
		Venta.SALDOCREDITO > 0;

	CREATE TABLE #TempVentaCliente (
		IDCLIENTE UNIQUEIDENTIFIER,
		N_CLIENTE VARCHAR(50),
		IDENTIFICACION VARCHAR(50),
		NombreCliente VARCHAR(200),
		RAZONSOCIAL VARCHAR(200),
		TELEFONO VARCHAR(9),
		PLAZO INT,
		LIMITECREDITO DECIMAL(18, 4),
		VENTATOTAL DECIMAL(18, 4),
		ABONOS DECIMAL(18, 4)
	)

	Open VentaCliente;

	FETCH NEXT FROM
		VentaCliente
	INTO
		@IDCLIENTE,
		@N_CLIENTE,
		@IDENTIFICACION,
		@NombreCliente,
		@RAZONSOCIAL,
		@TELEFONO,
		@PLAZO,
		@LIMITECREDITO,
		@VENTATOTAL

	WHILE (@@FETCH_STATUS=0)
	BEGIN

		SET @TotalAbonos = (
			SELECT
				SUM(
					CASE @Money WHEN 'C' THEN
						VentaReciboDetalle.
					ELSE
						VentaRecibo.MONTOTOTAL_D
					END
				)
				AS TotalAbonos
			FROM 
				VentaReciboDetalle
				INNER JOIN VentaRecibo ON VentaReciboDetalle.IDRECIBO = VentaRecibo.IDRECIBO
			WHERE
				VentaRecibo.IDCLIENTE = @IDCLIENTE
		)
		
		INSERT INTO #TempVentaCliente
			(
				IDCLIENTE,
				N_CLIENTE,
				IDENTIFICACION,
				NombreCliente,
				RAZONSOCIAL,
				TELEFONO,
				PLAZO,
				LIMITECREDITO,
				VENTATOTAL,
				ABONOS
			)
		VALUES
			(
				@IDCLIENTE,
				@N_CLIENTE,
				@IDENTIFICACION,
				@NombreCliente,
				@RAZONSOCIAL,
				@TELEFONO,
				@PLAZO,
				@LIMITECREDITO,
				@VENTATOTAL,
				@TotalAbonos
			)

		FETCH NEXT FROM
			VentaCliente
		INTO
			@IDCLIENTE,
			@N_CLIENTE,
			@IDENTIFICACION,
			@NombreCliente,
			@RAZONSOCIAL,
			@TELEFONO,
			@PLAZO,
			@LIMITECREDITO,
			@VENTATOTAL

	END

	SELECT * FROM #TempVentaCliente

END
SELECT * FROM VentaEstadoCuenta
GO