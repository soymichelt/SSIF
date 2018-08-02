/****** Object:  StoredProcedure [dbo].[SpAccountsToPay]    Script Date: 23/05/2018 17:00:21 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		MICHEL ROBERTO TRAÑA TABLADA
-- Create date: 10/06/2018
-- Description:	Retorna listado de proveedores con su deuda actual
-- =============================================
ALTER PROCEDURE [dbo].[SpAccountsToPay]

	-- Add the parameters for the stored procedure here
	@ProviderCode AS VARCHAR(50),
	@ProviderName AS VARCHAR(100),
	@BusinessName AS VARCHAR(100),
	@Money AS CHAR(1),
	@ExchangeRate AS DECIMAL

AS
BEGIN
	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Statements for procedure here
	SELECT
		res.ProviderCode,
		res.DNI,
		res.ProviderName,
		res.BusinessName,
		res.Phone,
		res.CreditTerm,
		res.CreditLimit,
		SUM(res.Billed) AS Billed,
		SUM(res.AmountExpired) AS AmountExpired,
		SUM(res.AmountAvailable) AS AmountAvailable
	FROM
		(
			(
				SELECT
					Proveedor.N_PROVEEDOR AS ProviderCode,
					Proveedor.IDENTIFICACION AS DNI,
					CONCAT(Proveedor.NOMBRES, ' ', Proveedor.APELLIDOS) AS ProviderName,
					Proveedor.RAZONSOCIAL AS BusinessName,
					Proveedor.TELEFONO AS Phone,
					Proveedor.PLAZO AS CreditTerm,

					CASE @Money WHEN Proveedor.MONEDA THEN
						Proveedor.LIMITECREDITO
					ELSE
						CASE @Money WHEN 'C' THEN
							Proveedor.LIMITECREDITO * @ExchangeRate
						ELSE
							Proveedor.LIMITECREDITO / @ExchangeRate
						END
					END
					AS
						CreditLimit,

					SUM(
						CASE @Money WHEN 'C' THEN
							CASE Compra.MONEDA WHEN 'C' THEN
								Compra.SALDOCREDITO
							ELSE
								Compra.TAZACAMBIO * Compra.SALDOCREDITO
							END
						ELSE
							CASE Compra.MONEDA WHEN 'C' THEN
								Compra.SALDOCREDITO / Compra.TAZACAMBIO
							ELSE
								Compra.SALDOCREDITO
							END
						END
					)
					AS
						Billed,

					0.0 AS AmountExpired,

						CASE @Money WHEN Proveedor.MONEDA THEN
							Proveedor.LIMITECREDITO
						ELSE
							CASE @Money WHEN 'C' THEN
								Proveedor.LIMITECREDITO * @ExchangeRate
							ELSE
								Proveedor.LIMITECREDITO / @ExchangeRate
							END
						END
					-
						SUM(
							CASE @Money WHEN 'C' THEN
								CASE Compra.MONEDA WHEN 'C' THEN
									Compra.SALDOCREDITO
								ELSE
									Compra.TAZACAMBIO * Compra.SALDOCREDITO
								END
							ELSE
								CASE Compra.MONEDA WHEN 'C' THEN
									Compra.SALDOCREDITO / Compra.TAZACAMBIO
								ELSE
									Compra.SALDOCREDITO
								END
							END
						)
					AS
						AmountAvailable

				FROM
					Proveedor
					INNER JOIN Compra ON Compra.IDPROVEEDOR = Proveedor.IDPROVEEDOR
				WHERE
						Proveedor.N_PROVEEDOR LIKE @ProviderCode + '%'
					AND
						CONCAT(Proveedor.NOMBRES, ' ', Proveedor.APELLIDOS) LIKE @ProviderName + '%'
					AND
						Proveedor.RAZONSOCIAL LIKE @BusinessName + '%'
				GROUP BY
					Proveedor.N_PROVEEDOR,
					Proveedor.IDENTIFICACION,
					CONCAT(Proveedor.NOMBRES, ' ', Proveedor.APELLIDOS),
					Proveedor.RAZONSOCIAL,
					Proveedor.TELEFONO,
					Proveedor.MONEDA,
					Proveedor.PLAZO,
					Proveedor.LIMITECREDITO
			)
		UNION
			(
				SELECT
					Proveedor.N_PROVEEDOR AS ProviderCode,
					Proveedor.IDENTIFICACION AS DNI,
					CONCAT(Proveedor.NOMBRES, ' ', Proveedor.APELLIDOS) AS ProviderName,
					Proveedor.RAZONSOCIAL AS BusinessName,
					Proveedor.TELEFONO AS Phone,
					Proveedor.PLAZO AS CreditTerm,
					
					CASE @Money WHEN Proveedor.MONEDA THEN
						Proveedor.LIMITECREDITO
					ELSE
						CASE @Money WHEN 'C' THEN
							Proveedor.LIMITECREDITO * @ExchangeRate
						ELSE
							Proveedor.LIMITECREDITO / @ExchangeRate
						END
					END
					AS
						CreditLimit,

					0.0 AS Billed,

					SUM(
						CASE @Money WHEN 'C' THEN
							CASE Compra.MONEDA WHEN 'C' THEN
								Compra.SALDOCREDITO
							ELSE
								Compra.TAZACAMBIO * Compra.SALDOCREDITO
							END
						ELSE
							CASE Compra.MONEDA WHEN 'C' THEN
								Compra.SALDOCREDITO / Compra.TAZACAMBIO
							ELSE
								Compra.SALDOCREDITO
							END
						END
					)
					AS
						AmountExpired,

					0.0 AS AmountAvailable

				FROM
					Proveedor
					INNER JOIN Compra ON Compra.IDPROVEEDOR = Proveedor.IDPROVEEDOR
				WHERE
						Proveedor.N_PROVEEDOR LIKE @ProviderCode + '%'
					AND
						CONCAT(Proveedor.NOMBRES, ' ', Proveedor.APELLIDOS) LIKE @ProviderName + '%'
					AND
						Proveedor.RAZONSOCIAL LIKE @BusinessName + '%'
					AND
						Compra.CREDITO = 1
					AND
						Compra.FECHACREDITOVENCIMIENTO IS NOT NULL
					AND
						Compra.FECHACREDITOVENCIMIENTO < GETDATE()
				GROUP BY
					Proveedor.N_PROVEEDOR,
					Proveedor.IDENTIFICACION,
					CONCAT(Proveedor.NOMBRES, ' ', Proveedor.APELLIDOS),
					Proveedor.RAZONSOCIAL,
					Proveedor.TELEFONO,
					Proveedor.MONEDA,
					Proveedor.PLAZO,
					Proveedor.LIMITECREDITO
			)
		)
	AS
		res
	GROUP BY
		res.ProviderCode,
		res.DNI,
		res.ProviderName,
		res.BusinessName,
		res.Phone,
		res.CreditTerm,
		res.CreditLimit
	ORDER BY
		res.ProviderCode
	--FIN DEL STATEMENT

END