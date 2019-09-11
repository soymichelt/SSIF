/****** Object:  StoredProcedure [dbo].[SpAccountsReceivable]    Script Date: 23/05/2018 17:00:21 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		MICHEL ROBERTO TRAÑA TABLADA
-- Create date: 08/06/2018
-- Description:	Retorna listado de clientes con su deuda actual
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[SpAccountsReceivable]

	-- Add the parameters for the stored procedure here
	@CustomerCode AS VARCHAR(50),
	@CustomerName AS VARCHAR(100),
	@BusinessName AS VARCHAR(100),
	@ExchangeRate AS DECIMAL(18,4)

AS
BEGIN
	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Statements for procedure here
	SELECT
		res.CustomerCode,
		res.DNI,
		res.CustomerName,
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
					Cliente.N_CLIENTE AS CustomerCode,
					Cliente.IDENTIFICACION AS DNI,
					CONCAT(Cliente.NOMBRES, ' ', Cliente.APELLIDOS) AS CustomerName,
					Cliente.RAZONSOCIAL AS BusinessName,
					Cliente.TELEFONO AS Phone,
					Cliente.PLAZO AS CreditTerm,

					Cliente.MONEDA AS MoneyOfCredit,

					Cliente.LIMITECREDITO AS CreditLimit,

					SUM(
						CASE Venta.MONEDA WHEN 'C' THEN
							Venta.SALDOCREDITO
						ELSE
							0.0
						END
					)
					AS
						Billed,

					SUM(
						CASE Venta.MONEDA WHEN 'D' THEN
							Venta.SALDOCREDITO
						ELSE
							0.0
						END
					)
					AS
						BilledDollar,

					0.0 AS AmountExpired,

					0.0 AS AmountExpiredDollar,

					Cliente.LIMITECREDITO
					-
					SUM(
						CASE Cliente.MONEDA WHEN Venta.MONEDA THEN
							Venta.SALDOCREDITO
						ELSE
							CASE Cliente.MONEDA WHEN 'C' THEN
								Venta.SALDOCREDITO * @ExchangeRate
							ELSE
								Venta.SALDOCREDITO / @ExchangeRate
							END
						END
					)
					AS
						AmountAvailable
				FROM
					Cliente
					INNER JOIN Venta ON Venta.IDCLIENTE = Cliente.IDCLIENTE
				WHERE
						Cliente.N_CLIENTE LIKE @CustomerCode + '%'
					AND
						CONCAT(Cliente.NOMBRES, ' ', Cliente.APELLIDOS) LIKE @CustomerName + '%'
					AND
						Cliente.RAZONSOCIAL LIKE @BusinessName + '%'
					AND
						Venta.ANULADO = 'N'
				GROUP BY
					Cliente.N_CLIENTE,
					Cliente.IDENTIFICACION,
					CONCAT(Cliente.NOMBRES, ' ', Cliente.APELLIDOS),
					Cliente.RAZONSOCIAL,
					Cliente.TELEFONO,
					Cliente.MONEDA,
					Cliente.PLAZO,
					Cliente.LIMITECREDITO
			)
		UNION
			(
				SELECT
					Cliente.N_CLIENTE AS CustomerCode,
					Cliente.IDENTIFICACION AS DNI,
					CONCAT(Cliente.NOMBRES, ' ', Cliente.APELLIDOS) AS CustomerName,
					Cliente.RAZONSOCIAL AS BusinessName,
					Cliente.TELEFONO AS Phone,
					Cliente.PLAZO AS CreditTerm,
					Cliente.MONEDA AS MoneyOfCredit,
					Cliente.LIMITECREDITO AS CreditLimit,

					0.0 AS Billed,

					0.0 AS BilledDollar,

					SUM(
						CASE Venta.MONEDA WHEN 'C' THEN
							Venta.SALDOCREDITO
						ELSE
							0.0
						END
					)
					AS
						AmountExpired,

					SUM(
						CASE Venta.MONEDA WHEN 'D' THEN
							Venta.SALDOCREDITO
						ELSE
							0.0
						END
					)
					AS
						AmountExpiredDollar,

					0.0 AS AmountAvailable

				FROM
					Cliente
					INNER JOIN Venta ON Venta.IDCLIENTE = Cliente.IDCLIENTE
				WHERE
						Venta.ANULADO = 'N'
					AND
						Cliente.N_CLIENTE LIKE @CustomerCode + '%'
					AND
						CONCAT(Cliente.NOMBRES, ' ', Cliente.APELLIDOS) LIKE @CustomerName + '%'
					AND
						Cliente.RAZONSOCIAL LIKE @BusinessName + '%'
					AND
						Venta.CREDITO = 1
					AND
						Venta.FECHACREDITOVENCIMIENTO IS NOT NULL
					AND
						Venta.FECHACREDITOVENCIMIENTO < GETDATE()
				GROUP BY
					Cliente.N_CLIENTE,
					Cliente.IDENTIFICACION,
					CONCAT(Cliente.NOMBRES, ' ', Cliente.APELLIDOS),
					Cliente.RAZONSOCIAL,
					Cliente.TELEFONO,
					Cliente.MONEDA,
					Cliente.PLAZO,
					Cliente.LIMITECREDITO
			)
		)
	AS
		res
	GROUP BY
		res.CustomerCode,
		res.DNI,
		res.CustomerName,
		res.BusinessName,
		res.Phone,
		res.MoneyOfCredit,
		res.CreditTerm,
		res.CreditLimit
	HAVING
		res.CreditLimit > SUM(res.AmountAvailable)
	ORDER BY
		res.CustomerCode
	--FIN DEL STATEMENT

END