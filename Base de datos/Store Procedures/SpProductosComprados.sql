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
CREATE OR ALTER PROCEDURE [dbo].[SpProductosComprados]
	-- Add the parameters for the stored procedure here
@Inicio AS DATETIME,
@Final AS DATETIME,
@IDBodega AS VARCHAR(36),
@IDSerie AS VARCHAR(36),
@NEmpleado AS VARCHAR(50),
@Empleado AS VARCHAR(100),
@NProveedor AS VARCHAR(50),
@Proveedor AS VARCHAR(100),
@TipoCompra AS INTEGER,
@MonInv AS Bit,
@Moneda AS Bit,
@Taza AS DECIMAL
AS
BEGIN
	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--DECLARAR VARIABLES DE TAZA DE CAMBIO
	DECLARE @TazaCordoba AS DECIMAL(18,4)
	DECLARE @TazaDolar AS DECIMAL(18,4)
	IF @Moneda = 1
		BEGIN
			SET @TazaCordoba = 1
			SET @TazaDolar = @Taza
		END
	ELSE
		BEGIN
			SET @TazaDolar = 1
			SET @TazaCordoba = @Taza
		END
	-- 1. SELECCIONAR TODOS LOS DATOS
	IF @TipoCompra <> 1 AND @TipoCompra <> 2
	BEGIN
		SELECT
			
			res.IDALTERNO AS IDAlterno,

			res.DESCRIPCION AS Descripcion,

			SUM(res.Cantidad)  AS Cantidad,

			SUM(res.SubTotal) / SUM(res.Cantidad) AS PrecioPromedio,

			SUM(res.SubTotal)  AS SubTotal,

			SUM(res.Descuento)  AS Descuento,

			SUM(res.Iva)  AS Iva,

			SUM(res.Total)  AS Total

		FROM (
			(SELECT
				
				NEWID() AS Id,

				Producto.IDALTERNO,

				Producto.DESCRIPCION,
				
				SUM(CompraDetalle.CANTIDAD) AS Cantidad,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.DESCUENTO_DIN_TOTAL_C ELSE CompraDetalle.DESCUENTO_DIN_TOTAL_D END) AS Descuento,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.SUBTOTAL_C ELSE CompraDetalle.SUBTOTAL_D END) AS SubTotal,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.IVA_DIN_TOTAL_C ELSE CompraDetalle.IVA_DIN_TOTAL_D END) AS Iva,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.TOTAL_C ELSE CompraDetalle.TOTAL_D END) AS Total
				
			FROM
				Producto
				INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
				INNER JOIN CompraDetalle ON Existencia.IDExistencia = CompraDetalle.IDExistencia
				INNER JOIN Compra ON CompraDetalle.IDCompra = Compra.IDCompra
				INNER JOIN Empleado ON Compra.IDEmpleado = Empleado.IDEmpleado
				INNER JOIN Proveedor ON Compra.IDProveedor = Proveedor.IDProveedor
				INNER JOIN Serie ON Compra.IDSerie = Serie.IDSerie
				INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
			WHERE
				Compra.ANULADO = 'N'
				AND Compra.FECHACOMPRA >= @INICIO
				AND Compra.FECHACOMPRA <= @FINAL
				AND Bodega.IDBodega LIKE (@IDBodega + '%')
				AND Serie.IDSerie LIKE (@IDSerie + '%')
				AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
				AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
				AND Proveedor.N_Proveedor LIKE (@NProveedor + '%')
				AND (Proveedor.NOMBRES + ' ' + Proveedor.APELLIDOS) LIKE (@Proveedor + '%')
			GROUP BY
				Producto.IDALTERNO,
				Producto.DESCRIPCION
			HAVING
				SUM(CompraDetalle.CANTIDAD) > 0
			)
		UNION
			(SELECT

				NEWID() AS Id,

				Producto.IDALTERNO,

				Producto.DESCRIPCION,
				
				SUM(CompraDetalle.CANTIDAD) AS Cantidad,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.DESCUENTO_DIN_TOTAL_C ELSE CompraDetalle.DESCUENTO_DIN_TOTAL_D END) AS Descuento,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.SUBTOTAL_C ELSE CompraDetalle.SUBTOTAL_D END) AS SubTotal,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.IVA_DIN_TOTAL_C ELSE CompraDetalle.IVA_DIN_TOTAL_D END) AS Iva,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.TOTAL_C ELSE CompraDetalle.TOTAL_D END) AS Total

			FROM
				Producto
				INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
				INNER JOIN CompraDetalle ON Existencia.IDExistencia = CompraDetalle.IDExistencia
				INNER JOIN Compra ON CompraDetalle.IDCompra = Compra.IDCompra
				INNER JOIN Empleado ON Compra.IDEmpleado = Empleado.IDEmpleado
				INNER JOIN Serie ON Compra.IDSerie = Serie.IDSerie
				INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
			WHERE
				Compra.ANULADO = 'N'
				AND Compra.IDProveedor IS NULL
				AND Compra.FECHACOMPRA >= @INICIO
				AND Compra.FECHACOMPRA <= @FINAL
				AND Bodega.IDBodega LIKE (@IDBodega + '%')
				AND Serie.IDSerie LIKE (@IDSerie + '%')
				AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
				AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
				AND RTRIM(@NProveedor) = ('')
				AND (Compra.ProveedorContado) LIKE (@Proveedor + '%')
			GROUP BY
				Producto.IDALTERNO,
				Producto.DESCRIPCION
			HAVING
				SUM(CompraDetalle.CANTIDAD) > 0
			)
		)
		AS
			res
		GROUP BY
			res.IDALTERNO, res.DESCRIPCION
		ORDER BY
			res.IDALTERNO ASC
	END






	--2. SELECCIONAR CompraS DE CONTADO
	IF @TipoCompra = 1
	BEGIN
		SELECT
			
			res.IDALTERNO AS IDAlterno,

			res.DESCRIPCION AS Descripcion,

			SUM(res.Cantidad)  AS Cantidad,

			SUM(res.SubTotal) / SUM(res.Cantidad) AS PrecioPromedio,

			SUM(res.SubTotal)  AS SubTotal,

			SUM(res.Descuento)  AS Descuento,

			SUM(res.Iva)  AS Iva,

			SUM(res.Total)  AS Total

		FROM (
			(SELECT
				NEWID() AS Id,

				Producto.IDALTERNO,

				Producto.DESCRIPCION,
				
				SUM(CompraDetalle.CANTIDAD) AS Cantidad,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.DESCUENTO_DIN_TOTAL_C ELSE CompraDetalle.DESCUENTO_DIN_TOTAL_D END) AS Descuento,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.SUBTOTAL_C ELSE CompraDetalle.SUBTOTAL_D END) AS SubTotal,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.IVA_DIN_TOTAL_C ELSE CompraDetalle.IVA_DIN_TOTAL_D END) AS Iva,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.TOTAL_C ELSE CompraDetalle.TOTAL_D END) AS Total
			FROM
				Producto
				INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
				INNER JOIN CompraDetalle ON Existencia.IDExistencia = CompraDetalle.IDExistencia
				INNER JOIN Compra ON CompraDetalle.IDCompra = Compra.IDCompra
				INNER JOIN Empleado ON Compra.IDEmpleado = Empleado.IDEmpleado
				INNER JOIN Proveedor ON Compra.IDProveedor = Proveedor.IDProveedor
				INNER JOIN Serie ON Compra.IDSerie = Serie.IDSerie
				INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
			WHERE
				Compra.ANULADO = 'N'
				AND Compra.FECHACOMPRA >= @INICIO
				AND Compra.FECHACOMPRA <= @FINAL
				AND Bodega.IDBodega LIKE (@IDBodega + '%')
				AND Serie.IDSerie LIKE (@IDSerie + '%')
				AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
				AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
				AND Proveedor.N_Proveedor LIKE (@NProveedor + '%')
				AND (Proveedor.NOMBRES + ' ' + Proveedor.APELLIDOS) LIKE (@Proveedor + '%')
				AND Compra.CREDITO = 0
			GROUP BY
				Producto.IDALTERNO,
				Producto.DESCRIPCION
			HAVING
				SUM(CompraDetalle.CANTIDAD) > 0
			)
		UNION
			(SELECT
				
				NEWID() AS Id,

				Producto.IDALTERNO,

				Producto.DESCRIPCION,
				
				SUM(CompraDetalle.CANTIDAD) AS Cantidad,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.DESCUENTO_DIN_TOTAL_C ELSE CompraDetalle.DESCUENTO_DIN_TOTAL_D END) AS Descuento,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.SUBTOTAL_C ELSE CompraDetalle.SUBTOTAL_D END) AS SubTotal,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.IVA_DIN_TOTAL_C ELSE CompraDetalle.IVA_DIN_TOTAL_D END) AS Iva,
				
				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.TOTAL_C ELSE CompraDetalle.TOTAL_D END) AS Total

			FROM
				Producto
				INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
				INNER JOIN CompraDetalle ON Existencia.IDExistencia = CompraDetalle.IDExistencia
				INNER JOIN Compra ON CompraDetalle.IDCompra = Compra.IDCompra
				INNER JOIN Empleado ON Compra.IDEmpleado = Empleado.IDEmpleado
				INNER JOIN Serie ON Compra.IDSerie = Serie.IDSerie
				INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
			WHERE
				Compra.ANULADO = 'N'
				AND Compra.IDProveedor IS NULL
				AND Compra.FECHACOMPRA >= @INICIO
				AND Compra.FECHACOMPRA <= @FINAL
				AND Bodega.IDBodega LIKE (@IDBodega + '%')
				AND Serie.IDSerie LIKE (@IDSerie + '%')
				AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
				AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
				AND RTRIM(@NProveedor) = ('')
				AND (Compra.ProveedorCONTADO) LIKE (@Proveedor + '%')
			GROUP BY
				Producto.IDALTERNO,
				Producto.DESCRIPCION
			HAVING
				SUM(CompraDetalle.CANTIDAD) > 0
			)
		)
		AS
			res
		GROUP BY
			res.IDALTERNO, res.DESCRIPCION
		ORDER BY
			res.IDALTERNO ASC
	END






	--3. SELECCIONAR Compras DE CREDITO
	IF @TipoCompra = 2
	BEGIN
		SELECT
			
			res.IDALTERNO AS IDAlterno,

			res.DESCRIPCION AS Descripcion,

			SUM(res.Cantidad) AS Cantidad,

			SUM(res.SubTotal) / SUM(res.Cantidad) AS PrecioPromedio,

			SUM(res.SubTotal) AS SubTotal,

			SUM(res.Descuento) AS Descuento,

			SUM(res.Iva) AS Iva,

			SUM(res.Total) AS Total

		FROM (
			(SELECT 
				
				NEWID() AS Id,
				
				Producto.IDALTERNO,
				
				Producto.DESCRIPCION,

				SUM(CASE Compra.MONEDA WHEN 'C' THEN CompraDetalle.SUBTOTAL_C / @TazaCordoba ELSE CompraDetalle.SUBTOTAL_D * @TazaDolar END) / SUM(CompraDetalle.CANTIDAD) AS PrecioPromedio,

				SUM(CompraDetalle.CANTIDAD) AS Cantidad,

				SUM(CompraDetalle.COSTO * CompraDetalle.CANTIDAD) AS Costo_Total,

				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.DESCUENTO_DIN_TOTAL_C ELSE CompraDetalle.DESCUENTO_DIN_TOTAL_D END) AS Descuento,

				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.SUBTOTAL_C ELSE CompraDetalle.SUBTOTAL_D END) AS SubTotal,

				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.IVA_DIN_TOTAL_C ELSE CompraDetalle.IVA_DIN_TOTAL_D END) AS Iva,

				SUM(CASE @Moneda WHEN 1 THEN CompraDetalle.TOTAL_C ELSE CompraDetalle.TOTAL_D END) AS Total

			FROM
				Producto
				INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
				INNER JOIN CompraDetalle ON Existencia.IDExistencia = CompraDetalle.IDExistencia
				INNER JOIN Compra ON CompraDetalle.IDCompra = Compra.IDCompra
				INNER JOIN Empleado ON Compra.IDEmpleado = Empleado.IDEmpleado
				INNER JOIN Proveedor ON Compra.IDProveedor = Proveedor.IDProveedor
				INNER JOIN Serie ON Compra.IDSerie = Serie.IDSerie
				INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
			WHERE
				Compra.ANULADO = 'N'
				AND Compra.FECHACOMPRA >= @INICIO
				AND Compra.FECHACOMPRA <= @FINAL
				AND Bodega.IDBodega LIKE (@IDBodega + '%')
				AND Serie.IDSerie LIKE (@IDSerie + '%')
				AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
				AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
				AND Proveedor.N_Proveedor LIKE (@NProveedor + '%')
				AND (Proveedor.NOMBRES + ' ' + Proveedor.APELLIDOS) LIKE (@Proveedor + '%')
				AND Compra.CREDITO = 1
			GROUP BY
				Producto.IDALTERNO,
				Producto.DESCRIPCION
			HAVING
				SUM(CompraDetalle.CANTIDAD) > 0
			)
		)
		AS
			res
		GROUP BY
			res.IDALTERNO, res.DESCRIPCION
		ORDER BY
			res.IDALTERNO ASC
	END
	--FIN DEL STATEMENT


END