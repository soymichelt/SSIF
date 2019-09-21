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
ALTER PROCEDURE [dbo].[SpSyncCliente]

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
		INSERT INTO [dbo].[Cliente] (
			IDCLIENTE,
			N,
			Reg,
			N_CLIENTE,
			IDENTIFICACION,
			TIPOPERSONA,
			NOMBRES,
			APELLIDOS,
			RAZONSOCIAL,
			TELEFONO,
			DOMICILIO,
			SEXO,
			CORREO,
			MONEDA,
			LIMITECREDITO,
			PLAZO,
			FACTURADO_C,
			FACTURADO_D,
			ACTIVO
		)
		SELECT
			IDCLIENTE,
			N,
			Reg,
			N_CLIENTE,
			IDENTIFICACION,
			TIPOPERSONA,
			NOMBRES,
			APELLIDOS,
			RAZONSOCIAL,
			TELEFONO,
			DOMICILIO,
			SEXO,
			CORREO,
			MONEDA,
			LIMITECREDITO,
			PLAZO,
			FACTURADO_C,
			FACTURADO_D,
			ACTIVO
		FROM
			[SadaraSyncTempDb].[dbo].[Cliente]
		WHERE
			IDCLIENTE = @ValueId
	END

	IF @TransactionType = 'UPDATE'
	BEGIN
		
		DECLARE @nCliente		VARCHAR(36);
		DECLARE @reg			DATETIME;
		DECLARE @identificacion VARCHAR(20);
		DECLARE @tipoPersona	VARCHAR(20);
		DECLARE @nombres		VARCHAR(50);
		DECLARE @apellidos		VARCHAR(50);
		DECLARE @razonsocial	VARCHAR(100);
		DECLARE @telefono		VARCHAR(20);
		DECLARE @domicilio		VARCHAR(500);
		DECLARE @sexo			VARCHAR(10);
		DECLARE @correo			VARCHAR(200);
		DECLARE @moneda			CHAR(1);
		DECLARE @limiteCredito	DECIMAL(18, 4);
		DECLARE @plazo			INT;
		DECLARE @facturadoC		DECIMAL(18, 4);
		DECLARE @facturadoD		DECIMAL(18, 4);
		DECLARE @activo			CHAR(1);

		SELECT TOP 1
			@nCliente = N_CLIENTE,
			@reg = Reg,
			@identificacion = IDENTIFICACION,
			@tipoPersona = TIPOPERSONA,
			@nombres = NOMBRES,
			@apellidos = APELLIDOS,
			@razonsocial = RAZONSOCIAL,
			@telefono = TELEFONO,
			@domicilio = DOMICILIO,
			@sexo = SEXO,
			@correo = CORREO,
			@moneda = MONEDA,
			@limiteCredito = LIMITECREDITO,
			@plazo = PLAZO,
			@facturadoC = FACTURADO_C,
			@facturadoD = FACTURADO_D,
			@activo = ACTIVO
		FROM
			[SadaraSyncTempDb].[dbo].[Cliente]
		WHERE
			IDBODEGA = @ValueId

		UPDATE
			Cliente
		SET
			Reg = @reg,
			N_CLIENTE = @nCliente,
			IDENTIFICACION = @identificacion,
			TIPOPERSONA = @tipoPersona,
			NOMBRES = @nombres,
			APELLIDOS = @apellidos,
			RAZONSOCIAL = @razonsocial,
			TELEFONO = @telefono,
			DOMICILIO = @domicilio,
			SEXO = @sexo,
			CORREO = @correo,
			MONEDA = @moneda,
			LIMITECREDITO = @limiteCredito,
			PLAZO = @plazo,
			FACTURADO_C = @facturadoC,
			FACTURADO_D = @facturadoD,
			ACTIVO = @activo
		WHERE
			IDCLIENTE = @ValueId

	END

	IF @TransactionType = 'DELETE'
	BEGIN

		DELETE FROM Cliente WHERE IDCLIENTE = @ValueId

	END
	--FIN DEL STATEMENT

END