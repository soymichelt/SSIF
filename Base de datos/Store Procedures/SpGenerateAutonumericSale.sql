SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ING. MICHAEL TRAÑA
-- Create date: 25/12/2019
-- Description:	Seleccionar las ventas por mes en un rango de fecha
-- =============================================
CREATE OR ALTER PROCEDURE SpGenerateAutonumericSaleId
	-- Add the parameters for the stored procedure here
	@SerieId	AS CHAR(36)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @LatestId AS VARCHAR(10);
	
	SELECT
		@LatestId = MAX(Venta.CONSECUTIVO)
	FROM
		Venta
	WHERE
		Venta.IDSERIE = @SerieId;

	IF @LatestId IS NOT NULL
	BEGIN
		SELECT CAST(@LatestId AS INT) + 1 AS Id
	END
	ELSE
	BEGIN
		SELECT 1 AS Id
	END

END
GO