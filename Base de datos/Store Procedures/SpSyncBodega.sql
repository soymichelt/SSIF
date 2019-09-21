/****** Object:  StoredProcedure [dbo].[SpAccountsReceivable]    Script Date: 23/05/2018 17:00:21 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		MICHEL ROBERTO TRAÑA TABLADA
-- Create date: 16/09/2019
-- Description:	Sincronizar datos de la aplicación que han sido modificados
-- =============================================
ALTER PROCEDURE [dbo].[SpSyncBodega]

	-- Add the parameters for the stored procedure here
	@TransactionType AS VARCHAR(10),
	@ValueId AS UNIQUEIDENTIFIER

AS
BEGIN
	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Statements for procedure here
	IF @TransactionType = 'INSERT'
	BEGIN
		INSERT INTO Bodega (
			IDBODEGA,
			N_BODEGA,
			Reg,
			DESCRIPCION,
			ACTIVO
		)
		SELECT
			IDBODEGA,
			N_BODEGA,
			Reg,
			DESCRIPCION,
			ACTIVO
		FROM
			[SadaraSyncTempDb].[dbo].[Bodega]
		WHERE
			IDBODEGA = @ValueId
	END

	IF @TransactionType = 'UPDATE'
	BEGIN
		
		DECLARE @nBodega VARCHAR(36);
		DECLARE @reg DATETIME;
		DECLARE @descripcion VARCHAR(500);
		DECLARE @activo CHAR(1);

		SELECT TOP 1
			@nBodega = N_BODEGA,
			@reg = Reg,
			@descripcion = DESCRIPCION,
			@activo = ACTIVO
		FROM
			[SadaraSyncTempDb].[dbo].[Bodega]
		WHERE
			IDBODEGA = @ValueId

		UPDATE
			Bodega
		SET
			N_BODEGA = @nBodega,
			Reg = @reg,
			DESCRIPCION = @descripcion,
			ACTIVO = @activo
		WHERE
			IDBODEGA = @ValueId

	END

	IF @TransactionType = 'DELETE'
	BEGIN

		DELETE FROM Bodega WHERE IDBODEGA = @ValueId

	END
	--FIN DEL STATEMENT

END