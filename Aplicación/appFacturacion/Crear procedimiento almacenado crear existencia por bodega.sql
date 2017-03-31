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
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SpCrearExistenciaPorBodega
	-- Add the parameters for the stored procedure here
	@IDProducto AS CHAR(36)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Existencia
	(
		IDEXISTENCIA,
		Reg,
		CANTIDAD,
		CONSIGNADO,
		IDBODEGA,
		IDPRODUCTO
	)
	SELECT
		NEWID(),
		GETDATE() AS Reg,
		0 AS CANTIDAD,
		0 AS CONSIGNADO,
		Bodega.IDBODEGA,
		@IDProducto AS IDPRODUCTO
	FROM
		Bodega
	INNER JOIN
		Existencia ON Bodega.IDBODEGA = Existencia.IDPRODUCTO
	WHERE
		Existencia.IDPRODUCTO <> @IDProducto
	
	
END
GO
