/****** Object:  StoredProcedure [dbo].[SpProductosVendidos]    Script Date: 24/06/2017 11:28:21 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		MICHEL ROBERTO TRAÑA TABLADA
-- Create date: 12/07/2016
-- Description:	ESTE PROCEDIMIENTO ALMACENADO PERMITE SELECCIONAR EL LISTADO DE ProductoS VENDIDOS EN UN RANGO DE TIEMPO
-- =============================================
ALTER PROCEDURE [dbo].[SpProductosVendidosFiltrados]
	-- Add the parameters for the stored procedure here
	@Inicio		AS		DATETIME,
	@Final		AS		DATETIME,
	@IDBodega	AS		VARCHAR(36),
	@IDSerie	AS		VARCHAR(36),
	@NEmpleado	AS		VARCHAR(50),
	@Empleado	AS		VARCHAR(100),
	@NCliente	AS		VARCHAR(50),
	@Cliente	AS		VARCHAR(100),
	@TipoVenta	AS		INTEGER,
	@MonInv		AS		Bit,
	@Moneda		AS		Bit,
	@Taza		AS		DECIMAL,

	--Id de Laboratorio y Proveedor
	@LaboratorioId AS VARCHAR(36),
	@ProveedorId AS VARCHAR(36)
	--Fin

AS
BEGIN
	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--CONSULTA
	CREATE TABLE #dataWithoutFilter (
		IDAlterno			VARCHAR(36),
		LaboratorioId		VARCHAR(36),
		ProveedorId			VARCHAR(36),
		Descripcion			VARCHAR(500),
		Cantidad			DECIMAL,
		CostoPromedio		DECIMAL(10,4),
		CostoTotal			DECIMAL(10,4),
		PrecioPromedio		DECIMAL(10,4),
		SubTotal			DECIMAL(10,4),
		Descuento			DECIMAL(10,4),
		Iva					DECIMAL(10,4),
		Total				DECIMAL(10,4),
		Utilidad			DECIMAL(10,4),
		UtilidadPorcentaje	DECIMAL(10,4)
	)
	INSERT INTO #dataWithoutFilter Exec dbo.SpProductosVendidos
								@Inicio		=		@Inicio,
								@Final		=		@Final,
								@IDBodega	=		@IDBodega,
								@IDSerie	=		@IDSerie,
								@NEmpleado	=		@NEmpleado,
								@Empleado	=		@Empleado,
								@NCliente	=		@NCliente,
								@Cliente	=		@Cliente,
								@TipoVenta	=		@TipoVenta,
								@MonInv		=		@MonInv,
								@Moneda		=		@Moneda,
								@Taza		=		@Taza

	IF @LaboratorioId <> ''
		BEGIN
			SELECT * FROM
				#dataWithoutFilter
			WHERE
				LaboratorioId LIKE (@LaboratorioId + '%')
			AND
				ProveedorId LIKE (@ProveedorId + '%')
		END
	ELSE
		BEGIN
			SELECT * FROM
				#dataWithoutFilter
		END

END

Exec dbo.SpProductosVendidosFiltrados
								@Inicio			=		'2018-01-01',
								@Final			=		'2018-12-31',
								@IDBodega		=		'',
								@IDSerie		=		'',
								@NEmpleado		=		'',
								@Empleado		=		'',
								@NCliente		=		'',
								@Cliente		=		'',
								@TipoVenta		=		0,
								@MonInv			=		0,
								@Moneda			=		1,
								@Taza			=		27,
								@LaboratorioId	=		'',
								@ProveedorId	=		''