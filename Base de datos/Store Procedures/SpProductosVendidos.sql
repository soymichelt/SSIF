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
ALTER PROCEDURE [dbo].[SpProductosVendidos]
	-- Add the parameters for the stored procedure here
@Inicio AS DATETIME,
@Final AS DATETIME,
@IDBodega AS VARCHAR(36),
@IDSerie AS VARCHAR(36),
@NEmpleado AS VARCHAR(50),
@Empleado AS VARCHAR(100),
@NCliente AS VARCHAR(50),
@Cliente AS VARCHAR(100),
@TipoVenta AS INTEGER,
@MonInv AS Bit,
@Moneda AS Bit,
@Taza AS DECIMAL

AS
BEGIN
	
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	-- 1. SELECCIONAR TODOS LOS DATOS
	IF @TipoVenta <> 1 AND @TipoVenta <> 2
	BEGIN


		
		PRINT @Moneda
		PRINT @MonInv
		


		SELECT

			restuladoConDevoluciones.IDALTERNO AS IDAlterno,
			restuladoConDevoluciones.IDLABORATORIO AS LaboratorioId,
			restuladoConDevoluciones.IDPROVEEDOR AS ProveedorId,
			restuladoConDevoluciones.DESCRIPCION AS Descripcion,
			SUM(restuladoConDevoluciones.Cantidad)  AS Cantidad,
			SUM(restuladoConDevoluciones.DetalleCostoTotal) / SUM(restuladoConDevoluciones.Cantidad) AS CostoPromedio,
			SUM(restuladoConDevoluciones.DetalleCostoTotal) AS CostoTotal,
			SUM(restuladoConDevoluciones.SubTotal) / SUM(restuladoConDevoluciones.Cantidad) AS PrecioPromedio,
			SUM(restuladoConDevoluciones.SubTotal)  AS SubTotal,
			SUM(restuladoConDevoluciones.Descuento)  AS Descuento,
			SUM(restuladoConDevoluciones.Iva)  AS Iva,
			SUM(restuladoConDevoluciones.Total)  AS Total,
			SUM(restuladoConDevoluciones.SubTotal) - SUM(restuladoConDevoluciones.DetalleCostoTotal)  AS Utilidad,
			(
				(SUM(restuladoConDevoluciones.SubTotal) - SUM(restuladoConDevoluciones.DetalleCostoTotal))
				*
				100
				/
				SUM(restuladoConDevoluciones.Total)
			)
			AS UtilidadPorcentaje
		FROM
		(

			(
				
				(

					-- INICIO SELECCIONAR VENTAS DE CLIENTES REGISTRADOS
					SELECT
						
						NEWID() AS Id,

						Producto.IDALTERNO,

						Producto.IDLABORATORIO,
						
						Producto.IDPROVEEDOR,

						Producto.DESCRIPCION,
						
						SUM
							((CASE @Moneda WHEN 1 THEN
								(CASE @MonInv WHEN 1 THEN
									VentaDevolucionDetalle.COSTO
								ELSE
									VentaDevolucionDetalle.COSTO * VentaDevolucion.TazaCambio
								END)
							 ELSE
								(CASE @MonInv WHEN 1 THEN
									VentaDevolucionDetalle.COSTO / VentaDevolucion.TazaCambio
								ELSE
									VentaDevolucionDetalle.COSTO
								END)
							 END)
							 *
							 VentaDevolucionDetalle.CANTIDAD) * -1
						AS DetalleCostoTotal,
				
						SUM(VentaDevolucionDetalle.CANTIDAD) * -1 AS Cantidad,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDevolucionDetalle.DESCUENTO_DIN_TOTAL_C ELSE VentaDevolucionDetalle.DESCUENTO_DIN_TOTAL_D END) * -1 AS Descuento,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDevolucionDetalle.SUBTOTAL_C ELSE VentaDevolucionDetalle.SUBTOTAL_D END) * -1 AS SubTotal,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDevolucionDetalle.IVA_DIN_TOTAL_C ELSE VentaDevolucionDetalle.IVA_DIN_TOTAL_D END) * -1 AS Iva,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDevolucionDetalle.TOTAL_C ELSE VentaDevolucionDetalle.TOTAL_D END) * -1 AS Total

					FROM
						Producto
						INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
						INNER JOIN VentaDevolucionDetalle ON Existencia.IDExistencia = VentaDevolucionDetalle.IDExistencia
						INNER JOIN VentaDevolucion ON VentaDevolucionDetalle.IDDEVOLUCION = VentaDevolucion.IDDEVOLUCION
						INNER JOIN Empleado ON VentaDevolucion.IDEmpleado = Empleado.IDEmpleado
						INNER JOIN Cliente ON VentaDevolucion.IDCliente = Cliente.IDCliente
						INNER JOIN Serie ON VentaDevolucion.IDSerie = Serie.IDSerie
						INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
					WHERE
						VentaDevolucion.ANULADO = 'N'
						AND VentaDevolucion.FECHADEVOLUCION >= @INICIO
						AND VentaDevolucion.FECHADEVOLUCION <= @FINAL
						AND Bodega.IDBodega LIKE (@IDBodega + '%')
						AND Serie.IDSerie LIKE (@IDSerie + '%')
						AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
						AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
						AND Cliente.N_Cliente LIKE (@NCliente + '%')
						AND (Cliente.NOMBRES + ' ' + Cliente.APELLIDOS) LIKE (@Cliente + '%')
						
						-- Filtro por Laboratorio y Proveedor
						--AND Producto.IDLABORATORIO LIKE (@LaboratorioId + '%')
						--AND Producto.IDPROVEEDOR LIKE (@ProveedorId + '%')
						-- Fin

					GROUP BY
						Producto.IDALTERNO,
						Producto.DESCRIPCION,
						Producto.IDLABORATORIO,
						Producto.IDPROVEEDOR
					HAVING
						SUM(VentaDevolucionDetalle.CANTIDAD) > 0
					-- FIN SELECCIONAR DEVOLUCIONES DE CLIENTES REGISTRADOS

				)
				UNION
				(
					
					-- INICIO SELECCIONAR DEVOLUCIONES DE CLIENTES SIN REGISTRAR
					SELECT

						NEWID() AS Id,

						Producto.IDALTERNO,

						Producto.IDLABORATORIO,
						
						Producto.IDPROVEEDOR,

						Producto.DESCRIPCION,
				
						SUM
							((CASE @Moneda WHEN 1 THEN
								(CASE @MonInv WHEN 1 THEN
									VentaDevolucionDetalle.COSTO
								ELSE 
									VentaDevolucionDetalle.COSTO * VentaDevolucion.TazaCambio
								END)
							ELSE 
								(CASE @MonInv WHEN 1 THEN
									VentaDevolucionDetalle.COSTO / VentaDevolucion.TazaCambio
								ELSE
									VentaDevolucionDetalle.COSTO
								END)
							END)
								*
								VentaDevolucionDetalle.CANTIDAD) * -1
						AS DetalleCostoTotal,
				
						SUM(VentaDevolucionDetalle.CANTIDAD) * -1 AS Cantidad,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDevolucionDetalle.DESCUENTO_DIN_TOTAL_C ELSE VentaDevolucionDetalle.DESCUENTO_DIN_TOTAL_D END) * -1 AS Descuento,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDevolucionDetalle.SUBTOTAL_C ELSE VentaDevolucionDetalle.SUBTOTAL_D END) * -1 AS SubTotal,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDevolucionDetalle.IVA_DIN_TOTAL_C ELSE VentaDevolucionDetalle.IVA_DIN_TOTAL_D END) * -1 AS Iva,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDevolucionDetalle.TOTAL_C ELSE VentaDevolucionDetalle.TOTAL_D END) * -1 AS Total

					FROM
						Producto
						INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
						INNER JOIN VentaDevolucionDetalle ON Existencia.IDExistencia = VentaDevolucionDetalle.IDExistencia
						INNER JOIN VentaDevolucion ON VentaDevolucionDetalle.IDDEVOLUCION = VentaDevolucion.IDDEVOLUCION
						INNER JOIN Empleado ON VentaDevolucion.IDEmpleado = Empleado.IDEmpleado
						INNER JOIN Serie ON VentaDevolucion.IDSerie = Serie.IDSerie
						INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
					WHERE
						VentaDevolucion.ANULADO = 'N'
						AND VentaDevolucion.IDCliente IS NULL
						AND VentaDevolucion.FECHADEVOLUCION >= @INICIO
						AND VentaDevolucion.FECHADEVOLUCION <= @FINAL
						AND Bodega.IDBodega LIKE (@IDBodega + '%')
						AND Serie.IDSerie LIKE (@IDSerie + '%')
						AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
						AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
						AND RTRIM(@NCliente) = ('')
						AND (VentaDevolucion.CLIENTECONTADO) LIKE (@Cliente + '%')
						
						-- Filtro por Laboratorio y Proveedor
						--AND Producto.IDLABORATORIO LIKE (@LaboratorioId + '%')
						--AND Producto.IDPROVEEDOR LIKE (@ProveedorId + '%')
						-- Fin

					GROUP BY
						Producto.IDALTERNO,
						Producto.DESCRIPCION,
						Producto.IDLABORATORIO,
						Producto.IDPROVEEDOR
					HAVING
						SUM(VentaDevolucionDetalle.CANTIDAD) > 0
					-- FIN SELECCIONAR DEVOLUCIONES DE CLIENTES SIN REGISTRAR
				)
			)
		UNION
			(

				
				(

					
					-- INICIO SELECCIONAR VENTAS DE CLIENTES REGISTRADOS

					SELECT
				
						NEWID() AS Id,

						Producto.IDALTERNO,

						Producto.IDLABORATORIO,
						
						Producto.IDPROVEEDOR,

						Producto.DESCRIPCION,
				
						SUM
							((CASE @Moneda WHEN 1 THEN
								(CASE @MonInv WHEN 1 THEN
									VentaDetalle.COSTO
								ELSE
									VentaDetalle.COSTO * Venta.TazaCambio
								END)
								ELSE
								(CASE @MonInv WHEN 1 THEN
									VentaDetalle.COSTO / Venta.TazaCambio
								ELSE
									VentaDetalle.COSTO
								END)
								END)
								*
								VentaDetalle.CANTIDAD)
						AS DetalleCostoTotal,
				
						SUM(VentaDetalle.CANTIDAD) AS Cantidad,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.DESCUENTO_DIN_TOTAL_C ELSE VentaDetalle.DESCUENTO_DIN_TOTAL_D END) AS Descuento,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.SUBTOTAL_C ELSE VentaDetalle.SUBTOTAL_D END) AS SubTotal,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.IVA_DIN_TOTAL_C ELSE VentaDetalle.IVA_DIN_TOTAL_D END) AS Iva,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.TOTAL_C ELSE VentaDetalle.TOTAL_D END) AS Total
				
					FROM
						Producto
						INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
						INNER JOIN VentaDetalle ON Existencia.IDExistencia = VentaDetalle.IDExistencia
						INNER JOIN Venta ON VentaDetalle.IDVenta = Venta.IDVenta
						INNER JOIN Empleado ON Venta.IDEmpleado = Empleado.IDEmpleado
						INNER JOIN Cliente ON Venta.IDCliente = Cliente.IDCliente
						INNER JOIN Serie ON Venta.IDSerie = Serie.IDSerie
						INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
					WHERE
						Venta.ANULADO = 'N'
						AND Venta.FECHAFACTURA >= @INICIO
						AND Venta.FECHAFACTURA <= @FINAL
						AND Bodega.IDBodega LIKE (@IDBodega + '%')
						AND Serie.IDSerie LIKE (@IDSerie + '%')
						AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
						AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
						AND Cliente.N_Cliente LIKE (@NCliente + '%')
						AND (Cliente.NOMBRES + ' ' + Cliente.APELLIDOS) LIKE (@Cliente + '%')
						
						-- Filtro por Laboratorio y Proveedor
						--AND Producto.IDLABORATORIO LIKE (@LaboratorioId + '%')
						--AND Producto.IDPROVEEDOR LIKE (@ProveedorId + '%')
						-- Fin

					GROUP BY
						Producto.IDALTERNO,
						Producto.DESCRIPCION,
						Producto.IDLABORATORIO,
						Producto.IDPROVEEDOR
					HAVING
						SUM(VentaDetalle.CANTIDAD) > 0
					-- FIN SELECCIONAR VENTAS DE CLIENTES REGISTRADOS

				)
			UNION
				(
					
					-- INICIO SELECCIONAR VENTAS DE CLIENTES SIN REGISTRAR
					SELECT

						NEWID() AS Id,

						Producto.IDALTERNO,

						Producto.IDLABORATORIO,
						
						Producto.IDPROVEEDOR,

						Producto.DESCRIPCION,
				
						SUM
							((CASE @Moneda WHEN 1 THEN
								(CASE @MonInv WHEN 1 THEN 
									VentaDetalle.COSTO
								ELSE 
									VentaDetalle.COSTO * Venta.TazaCambio
								END)
								ELSE 
								(CASE @MonInv WHEN 1 THEN
									VentaDetalle.COSTO / Venta.TazaCambio
								ELSE
									VentaDetalle.COSTO
								END)
								END)
								*
								VentaDetalle.CANTIDAD)
						AS DetalleCostoTotal,
				
						SUM(VentaDetalle.CANTIDAD) AS Cantidad,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.DESCUENTO_DIN_TOTAL_C ELSE VentaDetalle.DESCUENTO_DIN_TOTAL_D END) AS Descuento,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.SUBTOTAL_C ELSE VentaDetalle.SUBTOTAL_D END) AS SubTotal,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.IVA_DIN_TOTAL_C ELSE VentaDetalle.IVA_DIN_TOTAL_D END) AS Iva,
				
						SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.TOTAL_C ELSE VentaDetalle.TOTAL_D END) AS Total

					FROM
						Producto
						INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
						INNER JOIN VentaDetalle ON Existencia.IDExistencia = VentaDetalle.IDExistencia
						INNER JOIN Venta ON VentaDetalle.IDVenta = Venta.IDVenta
						INNER JOIN Empleado ON Venta.IDEmpleado = Empleado.IDEmpleado
						INNER JOIN Serie ON Venta.IDSerie = Serie.IDSerie
						INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
					WHERE
						Venta.ANULADO = 'N'
						AND Venta.IDCliente IS NULL
						AND Venta.FECHAFACTURA >= @INICIO
						AND Venta.FECHAFACTURA <= @FINAL
						AND Bodega.IDBodega LIKE (@IDBodega + '%')
						AND Serie.IDSerie LIKE (@IDSerie + '%')
						AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
						AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
						AND RTRIM(@NCliente) = ('')
						AND (Venta.ClienteCONTADO) LIKE (@Cliente + '%')
						
						-- Filtro por Laboratorio y Proveedor
						--AND Producto.IDLABORATORIO LIKE (@LaboratorioId + '%')
						--AND Producto.IDPROVEEDOR LIKE (@ProveedorId + '%')
						-- Fin

					GROUP BY
						Producto.IDALTERNO,
						Producto.DESCRIPCION,
						Producto.IDLABORATORIO,
						Producto.IDPROVEEDOR
					HAVING
						SUM(VentaDetalle.CANTIDAD) > 0
					-- FIN SELECCIONAR VENTAS DE CLIENTES SIN REGISTRAR

				)




			)




		)
		AS
			restuladoConDevoluciones
		GROUP BY
			restuladoConDevoluciones.IDALTERNO,
			restuladoConDevoluciones.DESCRIPCION,
			restuladoConDevoluciones.IDLABORATORIO,
			restuladoConDevoluciones.IDPROVEEDOR
		ORDER BY
			restuladoConDevoluciones.IDALTERNO ASC


		
	END






	--2. SELECCIONAR VentaS DE CONTADO
	IF @TipoVenta = 1
	BEGIN
		SELECT
			
			res.IDALTERNO AS IDAlterno,

			res.IDLABORATORIO AS LaboratorioId,
			
			res.IDPROVEEDOR AS ProveedorId,

			res.DESCRIPCION AS Descripcion,

			SUM(res.Cantidad)  AS Cantidad,

			SUM(res.DetalleCostoTotal) / SUM(res.Cantidad) AS CostoPromedio,

			SUM(res.DetalleCostoTotal) AS CostoTotal,

			SUM(res.SubTotal) / SUM(res.Cantidad) AS PrecioPromedio,

			SUM(res.SubTotal)  AS SubTotal,

			SUM(res.Descuento)  AS Descuento,

			SUM(res.Iva)  AS Iva,

			SUM(res.Total)  AS Total,

			SUM(res.SubTotal) - SUM(res.DetalleCostoTotal)  AS Utilidad,

			(
				(SUM(res.SubTotal) - SUM(res.DetalleCostoTotal))
				*
				100
				/
				SUM(res.Total)
			)
			AS UtilidadPorcentaje


		FROM (
			(SELECT
				NEWID() AS Id,

				Producto.IDALTERNO,

				Producto.IDLABORATORIO,
				Producto.IDPROVEEDOR,

				Producto.DESCRIPCION,
				
				SUM
					((CASE @Moneda WHEN 1 THEN
						(CASE @MonInv WHEN 1 THEN
							VentaDetalle.COSTO
						ELSE 
							VentaDetalle.COSTO * Venta.TazaCambio
						END)
					 ELSE 
						(CASE @MonInv WHEN 1 THEN
							VentaDetalle.COSTO / Venta.TazaCambio
						ELSE
							VentaDetalle.COSTO
						END)
					 END)
					 *
					 VentaDetalle.CANTIDAD)
				AS DetalleCostoTotal,
				
				SUM(VentaDetalle.CANTIDAD) AS Cantidad,
				
				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.DESCUENTO_DIN_TOTAL_C ELSE VentaDetalle.DESCUENTO_DIN_TOTAL_D END) AS Descuento,
				
				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.SUBTOTAL_C ELSE VentaDetalle.SUBTOTAL_D END) AS SubTotal,
				
				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.IVA_DIN_TOTAL_C ELSE VentaDetalle.IVA_DIN_TOTAL_D END) AS Iva,
				
				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.TOTAL_C ELSE VentaDetalle.TOTAL_D END) AS Total
			FROM
				Producto
				INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
				INNER JOIN VentaDetalle ON Existencia.IDExistencia = VentaDetalle.IDExistencia
				INNER JOIN Venta ON VentaDetalle.IDVenta = Venta.IDVenta
				INNER JOIN Empleado ON Venta.IDEmpleado = Empleado.IDEmpleado
				INNER JOIN Cliente ON Venta.IDCliente = Cliente.IDCliente
				INNER JOIN Serie ON Venta.IDSerie = Serie.IDSerie
				INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
			WHERE
				Venta.ANULADO = 'N'
				AND Venta.FECHAFACTURA >= @INICIO
				AND Venta.FECHAFACTURA <= @FINAL
				AND Bodega.IDBodega LIKE (@IDBodega + '%')
				AND Serie.IDSerie LIKE (@IDSerie + '%')
				AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
				AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
				AND Cliente.N_Cliente LIKE (@NCliente + '%')
				AND (Cliente.NOMBRES + ' ' + Cliente.APELLIDOS) LIKE (@Cliente + '%')
				AND Venta.CREDITO = 0

			GROUP BY
				Producto.IDALTERNO,
				Producto.DESCRIPCION,
				Producto.IDLABORATORIO,
				Producto.IDPROVEEDOR
			HAVING
				SUM(VentaDetalle.CANTIDAD) > 0
			)
		UNION
			(SELECT
				
				NEWID() AS Id,

				Producto.IDALTERNO,

				Producto.IDLABORATORIO,

				Producto.IDPROVEEDOR,

				Producto.DESCRIPCION,
				
				SUM
					((CASE @Moneda WHEN 1 THEN
						(CASE @MonInv WHEN 1 THEN 
							VentaDetalle.COSTO
						ELSE
							VentaDetalle.COSTO * Venta.TazaCambio
						END)
					 ELSE 
						(CASE @MonInv WHEN 1 THEN
							VentaDetalle.COSTO / Venta.TazaCambio
						ELSE
							VentaDetalle.COSTO
						END)
					 END)
					 *
					 VentaDetalle.CANTIDAD)
				AS DetalleCostoTotal,
				
				SUM(VentaDetalle.CANTIDAD) AS Cantidad,
				
				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.DESCUENTO_DIN_TOTAL_C ELSE VentaDetalle.DESCUENTO_DIN_TOTAL_D END) AS Descuento,
				
				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.SUBTOTAL_C ELSE VentaDetalle.SUBTOTAL_D END) AS SubTotal,
				
				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.IVA_DIN_TOTAL_C ELSE VentaDetalle.IVA_DIN_TOTAL_D END) AS Iva,
				
				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.TOTAL_C ELSE VentaDetalle.TOTAL_D END) AS Total

			FROM
				Producto
				INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
				INNER JOIN VentaDetalle ON Existencia.IDExistencia = VentaDetalle.IDExistencia
				INNER JOIN Venta ON VentaDetalle.IDVenta = Venta.IDVenta
				INNER JOIN Empleado ON Venta.IDEmpleado = Empleado.IDEmpleado
				INNER JOIN Serie ON Venta.IDSerie = Serie.IDSerie
				INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
			WHERE
				Venta.ANULADO = 'N'
				AND Venta.IDCliente IS NULL
				AND Venta.FECHAFACTURA >= @INICIO
				AND Venta.FECHAFACTURA <= @FINAL
				AND Bodega.IDBodega LIKE (@IDBodega + '%')
				AND Serie.IDSerie LIKE (@IDSerie + '%')
				AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
				AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
				AND RTRIM(@NCliente) = ('')
				AND (Venta.ClienteCONTADO) LIKE (@Cliente + '%')
				
			GROUP BY
				Producto.IDALTERNO,
				Producto.DESCRIPCION,
				Producto.IDLABORATORIO,
				Producto.IDPROVEEDOR
			HAVING
				SUM(VentaDetalle.CANTIDAD) > 0
			)
		)
		AS
			res
		GROUP BY
			res.IDALTERNO, res.DESCRIPCION, res.IDLABORATORIO, res.IDPROVEEDOR
		ORDER BY
			res.IDALTERNO ASC
	END






	--3. SELECCIONAR Ventas DE CREDITO
	IF @TipoVenta = 2
	BEGIN
		SELECT
			
			res.IDALTERNO AS IDAlterno,

			res.IDLABORATORIO AS LaboratorioId,

			res.IDPROVEEDOR AS ProveedorId,

			res.DESCRIPCION AS Descripcion,

			SUM(res.Cantidad)  AS Cantidad,

			SUM(res.DetalleCostoTotal) / SUM(res.Cantidad)  AS CostoPromedio,

			SUM(res.DetalleCostoTotal) AS CostoTotal,

			SUM(res.SubTotal) / SUM(res.Cantidad) AS PrecioPromedio,

			SUM(res.SubTotal)  AS SubTotal,

			SUM(res.Descuento)  AS Descuento,

			SUM(res.Iva)  AS Iva,

			SUM(res.Total)  AS Total,

			SUM(res.SubTotal) - SUM(res.DetalleCostoTotal)  AS Utilidad,

			(
				(SUM(res.SubTotal) - SUM(res.DetalleCostoTotal))
				*
				100
				/
				SUM(res.Total)
			)
			AS UtilidadPorcentaje

		FROM (
			(SELECT 
				
				NEWID() AS Id,
				
				Producto.IDALTERNO,

				Producto.IDLABORATORIO,

				Producto.IDPROVEEDOR,
				
				Producto.DESCRIPCION,
				
				SUM
					((CASE @Moneda WHEN 1 THEN
						(CASE @MonInv WHEN 1 THEN 
							VentaDetalle.COSTO
						ELSE 
							VentaDetalle.COSTO * Venta.TazaCambio
						END)
					ELSE 
						(CASE @MonInv WHEN 1 THEN
							VentaDetalle.COSTO / Venta.TazaCambio
						ELSE
							VentaDetalle.COSTO
						END)
					END)
					*
					VentaDetalle.CANTIDAD)
				AS DetalleCostoTotal,

				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.SUBTOTAL_C ELSE VentaDetalle.SUBTOTAL_D END) / SUM(VentaDetalle.CANTIDAD) AS PrecioPromedio,

				SUM(VentaDetalle.CANTIDAD) AS Cantidad,

				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.DESCUENTO_DIN_TOTAL_C ELSE VentaDetalle.DESCUENTO_DIN_TOTAL_D END) AS Descuento,

				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.SUBTOTAL_C ELSE VentaDetalle.SUBTOTAL_D END) AS SubTotal,

				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.IVA_DIN_TOTAL_C ELSE VentaDetalle.IVA_DIN_TOTAL_D END) AS Iva,

				SUM(CASE @Moneda WHEN 1 THEN VentaDetalle.TOTAL_C ELSE VentaDetalle.TOTAL_D END) AS Total

			FROM
				Producto
				INNER JOIN Existencia ON Producto.IDProducto = Existencia.IDProducto
				INNER JOIN VentaDetalle ON Existencia.IDExistencia = VentaDetalle.IDExistencia
				INNER JOIN Venta ON VentaDetalle.IDVenta = Venta.IDVenta
				INNER JOIN Empleado ON Venta.IDEmpleado = Empleado.IDEmpleado
				INNER JOIN Cliente ON Venta.IDCliente = Cliente.IDCliente
				INNER JOIN Serie ON Venta.IDSerie = Serie.IDSerie
				INNER JOIN Bodega ON Serie.IDBodega = Bodega.IDBodega
			WHERE
				Venta.ANULADO = 'N'
				AND Venta.FECHAFACTURA >= @INICIO
				AND Venta.FECHAFACTURA <= @FINAL
				AND Bodega.IDBodega LIKE (@IDBodega + '%')
				AND Serie.IDSerie LIKE (@IDSerie + '%')
				AND Empleado.N_TRABAJADOR LIKE (@NEmpleado + '%')
				AND (Empleado.NOMBRES + ' ' + Empleado.APELLIDOS) LIKE (@Empleado + '%')
				AND Cliente.N_Cliente LIKE (@NCliente + '%')
				AND (Cliente.NOMBRES + ' ' + Cliente.APELLIDOS) LIKE (@Cliente + '%')
				AND Venta.CREDITO = 1
				
			GROUP BY
				Producto.IDALTERNO,
				Producto.DESCRIPCION,
				Producto.IDLABORATORIO,
				Producto.IDPROVEEDOR
			HAVING
				SUM(VentaDetalle.CANTIDAD) > 0
			)
		)
		AS
			res
		GROUP BY
			res.IDALTERNO, res.DESCRIPCION, res.IDLABORATORIO, res.IDPROVEEDOR
		ORDER BY
			res.IDALTERNO ASC
	END
	--FIN DEL STATEMENT


END


Exec dbo.SpProductosVendidos
@Inicio = '2018-01-01',
@Final = '2018-12-31',
@IDBodega = '',
@IDSerie = '',
@NEmpleado = '',
@Empleado = '',
@NCliente = '',
@Cliente = '',
@TipoVenta = 0,
@MonInv = 0,
@Moneda = 1,
@Taza = 27

SELECT * FROM Producto
GO