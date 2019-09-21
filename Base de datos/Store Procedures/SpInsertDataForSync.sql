
/****** Object:  StoredProcedure [dbo].[SpCrearExistenciaPorBodega]    Script Date: 01/06/2017 03:19:24 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<MICHEL ROBERTO TRAÑA TABLADA (https://soymichel.com)>
-- Create date: <14/09/2019>
-- Description:	<Insertar datos a tblDataForSync>
-- =============================================
CREATE PROCEDURE [dbo].[SpInsertDataForSync]
	-- Add the parameters for the stored procedure here
	@tableName AS VARCHAR(50),
	@transactionType AS VARCHAR(20),
	@valueId AS UNIQUEIDENTIFIER
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO tblDataForSync(
		DataId,
		[Date],
		TableName,
		TransactionType,
		ValueId,
		IsApplied
	)
	VALUES (
		NEWID(),
		GETDATE(),
		@tableName,
		@transactionType,
		@valueId,
		0
	)

END
