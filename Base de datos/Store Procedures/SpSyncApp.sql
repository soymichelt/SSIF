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
ALTER PROCEDURE [dbo].[SpSyncApp]

	-- Add the parameters for the stored procedure here
	

AS
BEGIN
	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Statements for procedure here
	DECLARE @Date DATETIME;
	DECLARE @TableName VARCHAR(50);
	DECLARE @TransactionType VARCHAR(10);
	DECLARE @ValueId UNIQUEIDENTIFIER;
	DECLARE @IsApplied BIT;

	DECLARE dataForSyncCursor CURSOR FOR
		SELECT [Date], TableName, TransactionType, ValueId, IsApplied FROM tblDataForSync;

	OPEN dataForSyncCursor;

	FETCH NEXT FROM dataForSyncCursor INTO
		@Date, @TableName, @TransactionType, @ValueId, @IsApplied;

	WHILE (@@FETCH_STATUS = 0)
	BEGIN

		

		FETCH NEXT FROM dataForSyncCursor INTO
			@Date, @TableName, @TransactionType, @ValueId, @IsApplied;
	END
	--FIN DEL STATEMENT

END