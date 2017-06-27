-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ING. MICHAEL TRAÑA
-- Create date: 01/07/2017
-- Description:	Seleccionar las ventas por mes en un rango de fecha
-- =============================================
CREATE PROCEDURE SpMonthlySales
	-- Add the parameters for the stored procedure here
	@InitialDate	AS DATETIME,
	@FinalDate		AS DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		CONCAT(YEAR(Venta.FECHAFACTURA), '/', DATENAME(month,Venta.FECHAFACTURA)) AS Name,
		SUM(Venta.TOTAL_C) AS Value
	FROM
		Venta
	WHERE
		Venta.FECHAFACTURA BETWEEN @InitialDate AND @FinalDate
	GROUP BY
		YEAR(Venta.FECHAFACTURA),
		DATENAME(month, Venta.FECHAFACTURA)
	ORDER BY
			YEAR(Venta.FECHAFACTURA),
			DATENAME(month, Venta.FECHAFACTURA)
		ASC
END
GO