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
CREATE OR ALTER PROCEDURE [dbo].[SpAccountsToPay]

	-- Add the parameters for the stored procedure here
	@ProviderCode AS VARCHAR(50),
	@ProviderName AS VARCHAR(100),
	@BusinessName AS VARCHAR(100),
	@ExchangeRate AS DECIMAL(18,4)

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
		res.MoneyOfCredit,
		res.CreditTerm,
		res.CreditLimit,
		SUM(res.Billed) AS Billed,
		SUM(res.BilledDollar) AS BilledDollar,
		SUM(res.AmountExpired) AS AmountExpired,
		SUM(res.AmountExpiredDollar) AS AmountExpiredDollar,
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

					Proveedor.MONEDA AS MoneyOfCredit,

					Proveedor.LIMITECREDITO AS CreditLimit,

					SUM(
						CASE Compra.MONEDA WHEN 'C' THEN
							Compra.SALDOCREDITO
						ELSE
							0.0
						END
					)
					AS
						Billed,

					SUM(
						CASE Compra.MONEDA WHEN 'D' THEN
							Compra.SALDOCREDITO
						ELSE
							0.0
						END
					)
					AS
						BilledDollar,

					0.0 AS AmountExpired,

					0.0 AS AmountExpiredDollar,

					Proveedor.LIMITECREDITO
					-
					SUM(
						CASE Proveedor.MONEDA WHEN Compra.MONEDA THEN
							Compra.SALDOCREDITO
						ELSE
							CASE Proveedor.MONEDA WHEN 'C' THEN
								Compra.SALDOCREDITO * @ExchangeRate
							ELSE
								Compra.SALDOCREDITO / @ExchangeRate
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
					AND
						Compra.ANULADO = 'N'
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

					Proveedor.MONEDA AS MoneyOfCredit,
					
					Proveedor.LIMITECREDITO AS CreditLimit,

					0.0 AS Billed,

					0.0 AS BilledDollar,

					SUM(
						CASE Compra.MONEDA WHEN 'C' THEN
							Compra.SALDOCREDITO
						ELSE
							0.0
						END
					)
					AS
						AmountExpired,

					SUM(
						CASE Compra.MONEDA WHEN 'D' THEN
							Compra.SALDOCREDITO
						ELSE
							0.0
						END
					)
					AS
						AmountExpiredDollar,

					0.0 AS AmountAvailable

				FROM
					Proveedor
					INNER JOIN Compra ON Compra.IDPROVEEDOR = Proveedor.IDPROVEEDOR
				WHERE
						Compra.ANULADO = 'N'
					AND
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
		res.MoneyOfCredit,
		res.CreditTerm,
		res.CreditLimit
	HAVING
		res.CreditLimit > SUM(res.AmountAvailable)
	ORDER BY
		res.ProviderCode
	--FIN DEL STATEMENT

END


EXEC dbo.SpAccountsToPay @ProviderCode = '', @ProviderName = '', @BusinessName = '', @ExchangeRate = 30.95