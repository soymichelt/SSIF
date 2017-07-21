Imports System.Data
Imports System.Data.Entity

Imports Sadara.Models.V1.POCO


Namespace Database

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CodeFirst
        Inherits DbContext
        Public Sub New()
            MyBase.New("Data Source=" & Config.SQLServerName & ";Initial Catalog=" & Config.InitialCatalog & ";" & If(Config.SQLUser = "" Or Config.SQLPass = "", "Integrated Security=True;", "Integrated Security = False; User ID=" & Config.SQLUser & "; Password=" & Config.SQLPass & ";"))
        End Sub

        'MODELO DE CONTEXTO
        'VARIABLES DE NAVEGACION
        Public Property Empresas() As DbSet(Of Empresa)
        Public Property Bodegas() As DbSet(Of Bodega)
        Public Property Clientes() As DbSet(Of Cliente)
        Public Property Compras() As DbSet(Of Compra)
        Public Property ComprasDevoluciones As DbSet(Of CompraDevolucion)
        Public Property ComprasDevolucionesDetalles As DbSet(Of CompraDevolucionDetalle)
        Public Property ComprasRecibos As DbSet(Of CompraRecibo)
        Public Property ComprasRecibosDetalles As DbSet(Of CompraReciboDetalle)
        Public Property ComprasEstadosCuentas As DbSet(Of CompraEstadoCuenta)
        Public Property Consignaciones() As DbSet(Of Consignacion)
        Public Property Cotizaciones() As DbSet(Of Cotizacion)
        Public Property Desconsignaciones() As DbSet(Of Desconsignacion)
        Public Property ComprasDetalles() As DbSet(Of CompraDetalle)
        Public Property ConsignacionesDetalles() As DbSet(Of ConsignacionDetalle)
        Public Property CotizacionesDetalles() As DbSet(Of CotizacionDetalle)
        Public Property DesconsignacionesDetalles() As DbSet(Of DesconsignacionDetalle)
        Public Property VentasDevolucionesDetalles() As DbSet(Of VentaDevolucionDetalle)
        Public Property EntradasDetalles() As DbSet(Of EntradaDetalle)
        Public Property VentasRecibosDetalles() As DbSet(Of VentaReciboDetalle)
        Public Property SalidasDetalles() As DbSet(Of SalidaDetalle)
        Public Property TrasladosDetalles() As DbSet(Of TrasladoDetalle)
        Public Property VentasDetalles() As DbSet(Of VentaDetalle)
        Public Property VentasDevoluciones() As DbSet(Of VentaDevolucion)
        Public Property Entradas() As DbSet(Of Entrada)
        Public Property VentasEstadosCuentas As DbSet(Of VentaEstadoCuenta)
        Public Property Existencias() As DbSet(Of Existencia)
        Public Property Kardexs() As DbSet(Of Kardex)
        Public Property Laboratorios() As DbSet(Of Laboratorio)
        Public Property Marcas() As DbSet(Of Marca)
        Public Property Periodos() As DbSet(Of Periodo)
        Public Property Presentaciones() As DbSet(Of Presentacion)
        Public Property Productos() As DbSet(Of Producto)
        Public Property Promociones() As DbSet(Of Promocion)
        Public Property PromocionesExistencias() As DbSet(Of PromocionExistencia)
        Public Property Proveedores() As DbSet(Of Proveedor)
        Public Property VentasRecibos() As DbSet(Of VentaRecibo)
        Public Property Salidas() As DbSet(Of Salida)
        Public Property Series() As DbSet(Of Serie)
        Public Property Tazas() As DbSet(Of Taza)
        Public Property ImpuestosValoresAgregados() As DbSet(Of ImpuestoValorAgregado)
        Public Property Empleados() As DbSet(Of Empleado)
        Public Property Traslados() As DbSet(Of Traslado)
        Public Property UnidadesMedidas() As DbSet(Of UnidadMedida)
        Public Property Usuarios() As DbSet(Of Usuario)
        Public Property Ventas() As DbSet(Of Venta)

        Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
            modelBuilder.Conventions.Remove(Of System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention)()

            'DECIMALES EN CLIENTE
            modelBuilder.Entity(Of Cliente).Property(Function(f) f.LIMITECREDITO).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cliente).Property(Function(f) f.FACTURADO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cliente).Property(Function(f) f.FACTURADO_D).HasPrecision(18, 4)

            'DECIMALES EN COMPRA
            modelBuilder.Entity(Of Compra).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Compra).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

            'DECIMALES EN DEVOLUCION DE COMPRA
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucion).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

            'DECIMALES EN DEVOLUCION DE COMPRA DETALLE
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.CANTIDAD_DEVUELTA).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.PRECIOMONEDAORIGINAL).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDevolucionDetalle).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

            'DECIMALES COMPRA PAGO PROVEEDOR
            modelBuilder.Entity(Of CompraEstadoCuenta).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraEstadoCuenta).Property(Function(f) f.DEBE_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraEstadoCuenta).Property(Function(f) f.DEBE_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraEstadoCuenta).Property(Function(f) f.HABER_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraEstadoCuenta).Property(Function(f) f.HABER_D).HasPrecision(18, 4)

            'DECIMALES COMPRA RECIBO
            modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.IMPORTETOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.IMPORTETOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.DESCUENTOTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.DESCUENTOTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.SOBRANTEDECAJA_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.SOBRANTEDECAJA_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.MONTOTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraRecibo).Property(Function(f) f.MONTOTOTAL_D).HasPrecision(18, 4)

            'DETALLE COMPRA RECIBO DETALLE
            modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.IMPORTE_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.IMPORTE_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.DESCUENTO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.DESCUENTO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.NUEVO_SALDO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraReciboDetalle).Property(Function(f) f.NUEVO_SALDO_D).HasPrecision(18, 4)

            'DECIMALES EN COTIZACION
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Cotizacion).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

            'DECIMALES EN DETALLE COMPRA
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CompraDetalle).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

            'DECIMALES EN DETALLE COTIZACION
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of CotizacionDetalle).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

            'DECIMALES EN DETALLE DEVOLUCION
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucionDetalle).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

            'DECIMALES EN DETALLE ENTRADA
            modelBuilder.Entity(Of EntradaDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of EntradaDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
            modelBuilder.Entity(Of EntradaDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of EntradaDetalle).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

            'DETALLE VENTA RECIBO DETALLE
            modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.IMPORTE_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.IMPORTE_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.DESCUENTO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.DESCUENTO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.NUEVO_SALDO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaReciboDetalle).Property(Function(f) f.NUEVO_SALDO_D).HasPrecision(18, 4)

            'DECIMALES EN DETALLE SALIDA
            modelBuilder.Entity(Of SalidaDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of SalidaDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
            modelBuilder.Entity(Of SalidaDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of SalidaDetalle).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

            'DECIMALES EN DETALLE TRASLADO
            modelBuilder.Entity(Of TrasladoDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of TrasladoDetalle).Property(Function(f) f.EXISTENCIAEXTERNA).HasPrecision(18, 4)
            modelBuilder.Entity(Of TrasladoDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
            modelBuilder.Entity(Of TrasladoDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of TrasladoDetalle).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

            'DECIMALES EN DETALLE VENTA
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.COSTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.EXISTENCIA_PRODUCTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.PRECIOUNITARIO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.PRECIOUNITARIO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.DESCUENTO_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.DESCUENTO_DIN_TOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.PRECIONETO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.PRECIONETO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.IVA_DIN_TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.IVA_DIN_TOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDetalle).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

            'DECIMALES EN DEVOLUCION VENTA
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaDevolucion).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

            'DECIMALES EN ENTRADA
            modelBuilder.Entity(Of Entrada).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

            'DECIMALES ESTADO DE CUENTA
            modelBuilder.Entity(Of VentaEstadoCuenta).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaEstadoCuenta).Property(Function(f) f.DEBE_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaEstadoCuenta).Property(Function(f) f.DEBE_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaEstadoCuenta).Property(Function(f) f.HABER_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaEstadoCuenta).Property(Function(f) f.HABER_D).HasPrecision(18, 4)

            'DECIMALES EN EXISTENCIA
            modelBuilder.Entity(Of Existencia).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
            modelBuilder.Entity(Of Existencia).Property(Function(f) f.CONSIGNADO).HasPrecision(18, 4)

            'DECIMALES EN KARDEX
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.ENTRADA).HasPrecision(18, 4)
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.SALIDA).HasPrecision(18, 4)
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.EXISTENCIA_ANTERIOR).HasPrecision(18, 4)
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.EXISTENCIA_ALMACEN).HasPrecision(18, 4)
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.COSTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.COSTO_PROMEDIO).HasPrecision(18, 4)
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.PRECIO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.PRECIO_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.DEBER).HasPrecision(18, 4)
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.HABER).HasPrecision(18, 4)
            modelBuilder.Entity(Of Kardex).Property(Function(f) f.SALDO).HasPrecision(18, 4)

            'DECIMALES EN PRODUCTO
            modelBuilder.Entity(Of Producto).Property(Function(f) f.COSTO).HasPrecision(18, 4)
            modelBuilder.Entity(Of Producto).Property(Function(f) f.CONTIENE).HasPrecision(18, 4)
            modelBuilder.Entity(Of Producto).Property(Function(f) f.PRECIO1).HasPrecision(18, 4)
            modelBuilder.Entity(Of Producto).Property(Function(f) f.PRECIO2).HasPrecision(18, 4)
            modelBuilder.Entity(Of Producto).Property(Function(f) f.PRECIO3).HasPrecision(18, 4)
            modelBuilder.Entity(Of Producto).Property(Function(f) f.PRECIO4).HasPrecision(18, 4)
            modelBuilder.Entity(Of Producto).Property(Function(f) f.CANTIDAD_MAXIMA).HasPrecision(18, 4)
            modelBuilder.Entity(Of Producto).Property(Function(f) f.CANTIDAD_MINIMA).HasPrecision(18, 4)
            modelBuilder.Entity(Of Producto).Property(Function(f) f.Descuento).HasPrecision(18, 4)
            modelBuilder.Entity(Of Producto).Property(Function(f) f.CANTIDAD).HasPrecision(18, 4)
            modelBuilder.Entity(Of Producto).Property(Function(f) f.SALDO).HasPrecision(18, 4)

            'DECIMALES EN PROMOCIONES
            modelBuilder.Entity(Of PromocionExistencia).Property(Function(f) f.Descuento).HasPrecision(18, 4)

            'DECIMALES EN PROVEEDOR
            modelBuilder.Entity(Of Proveedor).Property(Function(f) f.LIMITECREDITO).HasPrecision(18, 4)
            modelBuilder.Entity(Of Proveedor).Property(Function(f) f.FACTURADO_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Proveedor).Property(Function(f) f.FACTURADO_D).HasPrecision(18, 4)

            'DECIMALES VENTA RECIBO
            modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.IMPORTETOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.IMPORTETOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.DESCUENTOTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.DESCUENTOTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.SOBRANTEDECAJA_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.SOBRANTEDECAJA_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.MONTOTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of VentaRecibo).Property(Function(f) f.MONTOTOTAL_D).HasPrecision(18, 4)

            'DECIMALES EN SALIDA
            modelBuilder.Entity(Of Salida).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

            'DECIMALES EN TAZA
            modelBuilder.Entity(Of Taza).Property(Function(f) f.CAMBIO).HasPrecision(18, 4)

            'DECIMALES EN IVA
            modelBuilder.Entity(Of ImpuestoValorAgregado).Property(Function(f) f.PORCENTAJE).HasPrecision(18, 4)

            ''DECIMALES EN TRABAJADOR
            'modelBuilder.Entity(Of TRABAJADOR).Property(Function(f) f.SUELDO).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR).Property(Function(f) f.COMISION_POR).HasPrecision(18, 4)

            ''DECIMALES EN PLANILLA
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_SUELDO_BASE).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_SUELDO_HORA_NORMAL).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_SUELDO_HORA_EXTRA).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_COMISION).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_SALARIO_BRUTO).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_DEDUCCION).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA).Property(Function(f) f.TOTAL_SALARIO_NETO).HasPrecision(18, 4)

            ''DECIMALES EN DETALLE PLANILLA
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.SUELDO_BASE).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_NORMAL).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_NORMAL_TARIFA).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_NORMAL_TOTAL).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_EXTRA).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_EXTRA_TARIFA).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.HORA_EXTRA_TOTAL).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.COMISION).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.SALARIO_BRUTO).HasPrecision(18, 4)
            'modelBuilder.Entity(Of TRABAJADOR_PLANILLA_DETALLE).Property(Function(f) f.SALARIO_NETO).HasPrecision(18, 4)

            'DECIMALES EN TRASLADO
            modelBuilder.Entity(Of Traslado).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

            'DECIMALES EN VENTA
            modelBuilder.Entity(Of Venta).Property(Function(f) f.SALDOCREDITO).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.TAZACAMBIO).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.DESCUENTO_POR_FACT).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.DESCUENTO_DIN_FACT_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.DESCUENTO_DIN_FACT_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.DESCUENTO_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.DESCUENTO_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.COSTO_TOTAL).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.SUBTOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.SUBTOTAL_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.IVA_POR).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.IVA_DIN_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.IVA_DIN_D).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.TOTAL_C).HasPrecision(18, 4)
            modelBuilder.Entity(Of Venta).Property(Function(f) f.TOTAL_D).HasPrecision(18, 4)

            ''DECIMALES EN CUENTA
            'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.DEBER_C).HasPrecision(18, 4)
            'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.DEBER_D).HasPrecision(18, 4)
            'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.HABER_C).HasPrecision(18, 4)
            'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.HABER_D).HasPrecision(18, 4)
            'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.SALDO_C).HasPrecision(18, 4)
            'modelBuilder.Entity(Of CUENTA).Property(Function(f) f.SALDO_D).HasPrecision(18, 4)

            ''DECIMALES EN POLIZA
            'modelBuilder.Entity(Of POLIZA).Property(Function(f) f.TOTAL).HasPrecision(18, 4)

            ''DECIMALES EN DETALLE POLIZA
            'modelBuilder.Entity(Of POLIZA_DETALLE).Property(Function(f) f.DEBER_C).HasPrecision(18, 4)
            'modelBuilder.Entity(Of POLIZA_DETALLE).Property(Function(f) f.DEBER_D).HasPrecision(18, 4)
            'modelBuilder.Entity(Of POLIZA_DETALLE).Property(Function(f) f.HABER_C).HasPrecision(18, 4)
            'modelBuilder.Entity(Of POLIZA_DETALLE).Property(Function(f) f.HABER_D).HasPrecision(18, 4)

            MyBase.OnModelCreating(modelBuilder)
        End Sub
    End Class

End Namespace
