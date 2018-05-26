EXEC dbo.SpAccountsReceivable
	@CustomerCode = '',
	@CustomerName = '',
	@BusinessName = '',
	@Money = 'C'
GO

SELECT * FROM Venta ORDER BY Venta.N
GO

UPDATE Venta SET FECHACREDITOVENCIMIENTO = '2018-05-20 20:01:38.597'
WHERE N = 8
GO


/****** Object:  StoredProcedure [dbo].[SpProductosVendidos]    Script Date: 23/05/2018 17:00:21 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		MICHEL ROBERTO TRAÑA TABLADA
-- Create date: 23/05/2018
-- Description:	Retorna listado de clientes con su deuda actual
-- =============================================
ALTER PROCEDURE [dbo].[SpAccountsReceivable]

	-- Add the parameters for the stored procedure here
	@CustomerCode AS VARCHAR(50),
	@CustomerName AS VARCHAR(100),
	@BusinessName AS VARCHAR(100),
	@Money AS CHAR(1)

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
		res.CreditTerm,
		res.CreditLimit,
		SUM(res.Billed) AS Billed,
		SUM(res.AmountExpired) AS AmountExpired,
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
					Cliente.LIMITECREDITO AS CreditLimit,
					SUM(
						CASE @Money WHEN 'C' THEN
							CASE Venta.MONEDA WHEN 'C' THEN
								Venta.SALDOCREDITO
							ELSE
								Venta.TAZACAMBIO * Venta.SALDOCREDITO
							END
						ELSE
							CASE Venta.MONEDA WHEN 'C' THEN
								Venta.SALDOCREDITO / Venta.TAZACAMBIO
							ELSE
								Venta.SALDOCREDITO
							END
						END
					)
					AS
						Billed,
					0.0 AS AmountExpired,
					Cliente.LIMITECREDITO -
					SUM(
						CASE @Money WHEN 'C' THEN
							CASE Venta.MONEDA WHEN 'C' THEN
								Venta.SALDOCREDITO
							ELSE
								Venta.TAZACAMBIO * Venta.SALDOCREDITO
							END
						ELSE
							CASE Venta.MONEDA WHEN 'C' THEN
								Venta.SALDOCREDITO / Venta.TAZACAMBIO
							ELSE
								Venta.SALDOCREDITO
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
				GROUP BY
					Cliente.N_CLIENTE,
					Cliente.IDENTIFICACION,
					CONCAT(Cliente.NOMBRES, ' ', Cliente.APELLIDOS),
					Cliente.RAZONSOCIAL,
					Cliente.TELEFONO,
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
					Cliente.LIMITECREDITO AS CreditLimit,
					0.0 AS Billed,
					SUM(
						CASE @Money WHEN 'C' THEN
							CASE Venta.MONEDA WHEN 'C' THEN
								Venta.SALDOCREDITO
							ELSE
								Venta.TAZACAMBIO * Venta.SALDOCREDITO
							END
						ELSE
							CASE Venta.MONEDA WHEN 'C' THEN
								Venta.SALDOCREDITO / Venta.TAZACAMBIO
							ELSE
								Venta.SALDOCREDITO
							END
						END
					)
					AS
						AmountExpired,
					0.0 AS AmountAvailable
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
		res.CreditTerm,
		res.CreditLimit
	ORDER BY
		res.CustomerCode
	--FIN DEL STATEMENT

END