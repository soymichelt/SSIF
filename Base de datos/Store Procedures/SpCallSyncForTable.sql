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
ALTER PROCEDURE [dbo].[SpCallSyncForTable]

	-- Add the parameters for the stored procedure here
	@TableName AS VARCHAR(50),
	@TransactionType AS VARCHAR(10),
	@ValueId AS UNIQUEIDENTIFIER
AS
BEGIN
	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Statements for procedure here
	IF @TableName = 'Bodega'
	BEGIN
		EXEC dbo.SpSyncBodega
			@TransactionType = @TransactionType,
			@ValueId = @ValueId;
	END
	--FIN DEL STATEMENT

END