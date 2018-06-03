using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadara.BusinessLayer
{

    public class Inventory
    {

        private static Inventory instance;

        private static readonly object padlock = new object();

        private static bool InstanceIsInitialized()
        {

            return instance != null;

        }

        private static void InitializeInstance()
        {

            instance = new Inventory();

        }

        public static Inventory Instance {

            get
            {

                lock (padlock)
                {

                    if (!InstanceIsInitialized())
                        InitializeInstance();

                    return instance;

                }

            }

        }

        public string CurrencyOfProducts { get; set; }

        public string CordobaLabel { get; set; } = "C";

        public string DollarLabel { get; set; } = "D";

        public void RecalculateCostByNullification(
            ref Sadara.Models.V1.POCO.Kardex currentPostItemKardex,
            ref Sadara.Models.V1.POCO.Kardex itemKardexToRemove,
            ref Sadara.Models.V1.Database.CodeFirst db,
            ref decimal accumulatedCostToDebit,
            ref decimal accumulatedCostToAcredit
        )
        {

            string serieId = currentPostItemKardex.IDSERIE;
            string nDocumento = currentPostItemKardex.N_DOCUMENTO;
            string existenciaId = currentPostItemKardex.IDEXISTENCIA;

            switch (currentPostItemKardex.OPERACION)
            {

                case "COMPRA CONTADO":
                case "COMPRA CREDITO":

                    this.RecalculateQuantityToDebit(ref currentPostItemKardex, ref itemKardexToRemove, ref accumulatedCostToDebit, ref accumulatedCostToAcredit);

                    break;

                case "VENTA CONTADO":
                case "VENTA CREDITO":

                    this.RecalculateQuantityToAcredit(ref currentPostItemKardex, ref itemKardexToRemove, ref accumulatedCostToDebit, ref accumulatedCostToAcredit, true);

                    var saleDetail = (from c in db.Ventas
                                      join d in db.VentasDetalles on c.IDVENTA equals d.IDVENTA
                                      where c.IDSERIE == serieId && c.CONSECUTIVO == nDocumento && d.IDEXISTENCIA == existenciaId
                                      select d).FirstOrDefault();

                    if (saleDetail != null)
                    {
                        //aquí se calcula el costo
                        if (saleDetail.CMONEDA.Equals(this.CordobaLabel))
                            saleDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO * currentPostItemKardex.TAZACAMBIO);
                        else
                            saleDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO / currentPostItemKardex.TAZACAMBIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO);

                        db.Entry(saleDetail).State = EntityState.Modified;

                    }

                    break;

                case "ENTRADA":

                    this.RecalculateQuantityToDebit(ref currentPostItemKardex, ref itemKardexToRemove, ref accumulatedCostToDebit, ref accumulatedCostToAcredit, true);

                    var entryDetail = (from c in db.Entradas
                                       join d in db.EntradasDetalles on c.IDENTRADA equals d.IDENTRADA
                                       where c.IDSERIE == serieId && c.CONSECUTIVO == nDocumento && d.IDEXISTENCIA == existenciaId
                                       select d).FirstOrDefault();

                    if (entryDetail != null)
                    {
                        //aquí se calcula el costo
                        if (entryDetail.CMONEDA.Equals(this.CordobaLabel))
                            entryDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO * currentPostItemKardex.TAZACAMBIO);
                        else
                            entryDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO / currentPostItemKardex.TAZACAMBIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO);

                        db.Entry(entryDetail).State = EntityState.Modified;

                    }

                    break;

                case "SALIDA":

                    this.RecalculateQuantityToAcredit(ref currentPostItemKardex, ref itemKardexToRemove, ref accumulatedCostToDebit, ref accumulatedCostToAcredit, true);

                    var outputDetail = (from c in db.Salidas
                                        join d in db.SalidasDetalles on c.IDSALIDA equals d.IDSALIDA
                                        where c.IDSERIE == serieId && c.CONSECUTIVO == nDocumento && d.IDEXISTENCIA == existenciaId
                                        select d).FirstOrDefault();

                    if (outputDetail != null)
                    {
                        //aquí se calcula el costo
                        if (outputDetail.CMONEDA.Equals(this.CordobaLabel))
                            outputDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO * currentPostItemKardex.TAZACAMBIO);
                        else
                            outputDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO / currentPostItemKardex.TAZACAMBIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO);

                        db.Entry(outputDetail).State = EntityState.Modified;

                    }

                    break;

                case "TRASLADO":

                    if (currentPostItemKardex.DEBER > 0)
                        this.RecalculateQuantityToDebit(ref currentPostItemKardex, ref itemKardexToRemove, ref accumulatedCostToDebit, ref accumulatedCostToAcredit, true);

                    if (currentPostItemKardex.HABER > 0)
                        this.RecalculateQuantityToAcredit(ref currentPostItemKardex, ref itemKardexToRemove, ref accumulatedCostToDebit, ref accumulatedCostToAcredit, true);

                    var transferDetail = (from c in db.Traslados
                                          join d in db.TrasladosDetalles on c.IDTRASLADO equals d.IDTRASLADO
                                          where c.IDSERIE == serieId && c.CONSECUTIVO == nDocumento && d.IDEXISTENCIA == existenciaId
                                          select d).FirstOrDefault();

                    if (transferDetail != null)
                    {
                        //aquí se calcula el costo
                        if (transferDetail.CMONEDA.Equals(this.CordobaLabel))
                            transferDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO * currentPostItemKardex.TAZACAMBIO);
                        else
                            transferDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO / currentPostItemKardex.TAZACAMBIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO);

                        db.Entry(transferDetail).State = EntityState.Modified;

                    }

                    break;

                case "DEVOLUCION VENTA":

                    this.RecalculateQuantityToDebit(ref currentPostItemKardex, ref itemKardexToRemove, ref accumulatedCostToDebit, ref accumulatedCostToAcredit, true);

                    var saleReturnDetail = (from c in db.VentasDevoluciones
                                            join d in db.VentasDevolucionesDetalles on c.IDDEVOLUCION equals d.IDDEVOLUCION
                                            where c.IDSERIE == serieId && c.CONSECUTIVO == nDocumento && d.IDEXISTENCIA == existenciaId
                                            select d).FirstOrDefault();

                    if (saleReturnDetail != null)
                    {
                        //aquí se calcula el costo
                        if (saleReturnDetail.CMONEDA.Equals(this.CordobaLabel))
                            saleReturnDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO * currentPostItemKardex.TAZACAMBIO);
                        else
                            saleReturnDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO / currentPostItemKardex.TAZACAMBIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO);

                        db.Entry(saleReturnDetail).State = EntityState.Modified;

                    }

                    break;

                case "DEVOLUCION COMPRA":

                    this.RecalculateQuantityToAcredit(ref currentPostItemKardex, ref itemKardexToRemove, ref accumulatedCostToDebit, ref accumulatedCostToAcredit, true);

                    var purchaseReturnDetail = (from c in db.ComprasDevoluciones
                                                join d in db.ComprasDevolucionesDetalles on c.IDDEVOLUCION equals d.IDDEVOLUCION
                                                where c.IDSERIE == serieId && c.CONSECUTIVO == nDocumento && d.IDEXISTENCIA == existenciaId
                                                select d).FirstOrDefault();

                    if (purchaseReturnDetail != null)
                    {
                        //aquí se calcula el costo
                        if (purchaseReturnDetail.CMONEDA.Equals(this.CordobaLabel))
                            purchaseReturnDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO * currentPostItemKardex.TAZACAMBIO);
                        else
                            purchaseReturnDetail.COSTO = (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ?
                                                  currentPostItemKardex.COSTO_PROMEDIO / currentPostItemKardex.TAZACAMBIO :
                                                  currentPostItemKardex.COSTO_PROMEDIO);

                        db.Entry(purchaseReturnDetail).State = EntityState.Modified;

                    }

                    break;

            }

        }

        private void RecalculateQuantityToDebit(
            ref Sadara.Models.V1.POCO.Kardex currentPostItemKardex,
            ref Sadara.Models.V1.POCO.Kardex itemKardexToRemove,
            ref decimal accumulatedCostToDebit,
            ref decimal accumulatedCostToAcredit,
            Boolean withAverageCost = false
        )
        {

            if (currentPostItemKardex.EXISTENCIA_ALMACEN == 0)
            {

                currentPostItemKardex.SALDO = 0;
                currentPostItemKardex.COSTO_PROMEDIO = 0;

            }
            else
            {

                var quantityOfMoney = itemKardexToRemove.DEBER > 0 ? itemKardexToRemove.DEBER * -1 : itemKardexToRemove.HABER;

                var typeMovement = currentPostItemKardex.DEBER > 0 ? true : false;

                if (CurrencyOfProducts.Equals(itemKardexToRemove.CMONEDA))
                {

                    if (withAverageCost)
                    {

                        currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + quantityOfMoney - currentPostItemKardex.DEBER;
                        currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / currentPostItemKardex.EXISTENCIA_ANTERIOR;
                        currentPostItemKardex.COSTO = currentPostItemKardex.COSTO_PROMEDIO;

                        currentPostItemKardex.DEBER = currentPostItemKardex.ENTRADA * currentPostItemKardex.COSTO_PROMEDIO;
                        currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + currentPostItemKardex.DEBER;

                        /*if (typeMovement)
                        {

                            currentPostItemKardex.DEBER = currentPostItemKardex.ENTRADA * currentPostItemKardex.COSTO_PROMEDIO;
                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + currentPostItemKardex.DEBER;

                        }
                        else
                        {

                            currentPostItemKardex.HABER = currentPostItemKardex.SALIDA * currentPostItemKardex.COSTO_PROMEDIO;
                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO - currentPostItemKardex.HABER;

                        }*/

                    }
                    else
                    {

                        currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + quantityOfMoney;
                        currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / currentPostItemKardex.EXISTENCIA_ALMACEN;

                    }

                }
                else
                {

                    if (itemKardexToRemove.CMONEDA.Equals(this.CordobaLabel))
                    {

                        if (withAverageCost)
                        {

                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (quantityOfMoney / itemKardexToRemove.TAZACAMBIO) - (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ? currentPostItemKardex.DEBER / currentPostItemKardex.TAZACAMBIO : currentPostItemKardex.DEBER);
                            currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / (currentPostItemKardex.EXISTENCIA_ANTERIOR);
                            currentPostItemKardex.COSTO = currentPostItemKardex.COSTO_PROMEDIO;

                            currentPostItemKardex.DEBER = (currentPostItemKardex.ENTRADA * currentPostItemKardex.COSTO_PROMEDIO) * currentPostItemKardex.TAZACAMBIO;
                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (currentPostItemKardex.DEBER / currentPostItemKardex.TAZACAMBIO);

                            /*if (typeMovement)
                            {

                                currentPostItemKardex.DEBER = (currentPostItemKardex.ENTRADA * currentPostItemKardex.COSTO_PROMEDIO) * currentPostItemKardex.TAZACAMBIO;
                                currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (currentPostItemKardex.DEBER / currentPostItemKardex.TAZACAMBIO);

                            }
                            else
                            {

                                currentPostItemKardex.HABER = (currentPostItemKardex.SALIDA * currentPostItemKardex.COSTO_PROMEDIO) * currentPostItemKardex.TAZACAMBIO;
                                currentPostItemKardex.SALDO = currentPostItemKardex.SALDO - (currentPostItemKardex.HABER / currentPostItemKardex.TAZACAMBIO);

                            }*/

                        }
                        else
                        {

                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (quantityOfMoney / itemKardexToRemove.TAZACAMBIO);
                            currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / currentPostItemKardex.EXISTENCIA_ALMACEN;

                        }

                    }
                    else
                    {

                        if (withAverageCost)
                        {

                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (itemKardexToRemove.DEBER * itemKardexToRemove.TAZACAMBIO) + (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ? currentPostItemKardex.DEBER : currentPostItemKardex.DEBER * currentPostItemKardex.TAZACAMBIO);
                            currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / currentPostItemKardex.EXISTENCIA_ANTERIOR;
                            currentPostItemKardex.COSTO = currentPostItemKardex.COSTO_PROMEDIO;

                            currentPostItemKardex.DEBER = (currentPostItemKardex.ENTRADA * currentPostItemKardex.COSTO_PROMEDIO) / currentPostItemKardex.TAZACAMBIO;
                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (quantityOfMoney * currentPostItemKardex.TAZACAMBIO);

                            /*if (typeMovement)
                            {

                                currentPostItemKardex.DEBER = (currentPostItemKardex.ENTRADA * currentPostItemKardex.COSTO_PROMEDIO) / currentPostItemKardex.TAZACAMBIO;
                                currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (quantityOfMoney * currentPostItemKardex.TAZACAMBIO);

                            }
                            else
                            {

                                currentPostItemKardex.HABER = (currentPostItemKardex.SALIDA * currentPostItemKardex.COSTO_PROMEDIO) / currentPostItemKardex.TAZACAMBIO;
                                currentPostItemKardex.SALDO = currentPostItemKardex.SALDO - (currentPostItemKardex.HABER * currentPostItemKardex.TAZACAMBIO);

                            }*/

                        }
                        else
                        {

                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (quantityOfMoney * itemKardexToRemove.TAZACAMBIO);
                            currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / currentPostItemKardex.EXISTENCIA_ALMACEN;

                        }

                    }

                }

            }

        }

        private void RecalculateQuantityToAcredit(
            ref Sadara.Models.V1.POCO.Kardex currentPostItemKardex,
            ref Sadara.Models.V1.POCO.Kardex itemKardexToRemove,
            ref decimal accumulatedCostToDebit,
            ref decimal accumulatedCostToAcredit,
            Boolean withAverageCost = false
        )
        {

            if (currentPostItemKardex.EXISTENCIA_ALMACEN == 0)
            {

                currentPostItemKardex.SALDO = 0;
                currentPostItemKardex.COSTO_PROMEDIO = 0;

            }
            else
            {

                var quantityOfMoney = itemKardexToRemove.DEBER > 0 ? itemKardexToRemove.DEBER * -1 : itemKardexToRemove.HABER;

                var typeMovement = currentPostItemKardex.DEBER > 0 ? true : false;

                if (CurrencyOfProducts.Equals(itemKardexToRemove.CMONEDA))
                {

                    if (withAverageCost)
                    {

                        currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + quantityOfMoney + currentPostItemKardex.HABER;
                        currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / currentPostItemKardex.EXISTENCIA_ANTERIOR;
                        currentPostItemKardex.COSTO = currentPostItemKardex.COSTO_PROMEDIO;

                        currentPostItemKardex.HABER = currentPostItemKardex.SALIDA * currentPostItemKardex.COSTO_PROMEDIO;
                        currentPostItemKardex.SALDO = currentPostItemKardex.SALDO - currentPostItemKardex.HABER;

                        /*if (typeMovement)
                        {

                            currentPostItemKardex.DEBER = currentPostItemKardex.ENTRADA * currentPostItemKardex.COSTO_PROMEDIO;
                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + currentPostItemKardex.DEBER;

                        }
                        else
                        {

                            currentPostItemKardex.HABER = currentPostItemKardex.SALIDA * currentPostItemKardex.COSTO_PROMEDIO;
                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO - currentPostItemKardex.HABER;

                        }*/

                    }
                    else
                    {

                        currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + quantityOfMoney;
                        currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / currentPostItemKardex.EXISTENCIA_ALMACEN;

                    }

                }
                else
                {

                    if (itemKardexToRemove.CMONEDA.Equals(this.CordobaLabel))
                    {

                        if (withAverageCost)
                        {

                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (quantityOfMoney / itemKardexToRemove.TAZACAMBIO) + (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ? currentPostItemKardex.HABER / currentPostItemKardex.TAZACAMBIO : currentPostItemKardex.HABER);
                            currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / (currentPostItemKardex.EXISTENCIA_ANTERIOR);
                            currentPostItemKardex.COSTO = currentPostItemKardex.COSTO_PROMEDIO;

                            currentPostItemKardex.HABER = (currentPostItemKardex.SALIDA * currentPostItemKardex.COSTO_PROMEDIO) * currentPostItemKardex.TAZACAMBIO;
                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO - (currentPostItemKardex.HABER / currentPostItemKardex.TAZACAMBIO);

                            /*if (typeMovement)
                            {

                                currentPostItemKardex.DEBER = (currentPostItemKardex.ENTRADA * currentPostItemKardex.COSTO_PROMEDIO) * currentPostItemKardex.TAZACAMBIO;
                                currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (currentPostItemKardex.DEBER / currentPostItemKardex.TAZACAMBIO);

                            }
                            else
                            {

                                currentPostItemKardex.HABER = (currentPostItemKardex.SALIDA * currentPostItemKardex.COSTO_PROMEDIO) * currentPostItemKardex.TAZACAMBIO;
                                currentPostItemKardex.SALDO = currentPostItemKardex.SALDO - (currentPostItemKardex.HABER / currentPostItemKardex.TAZACAMBIO);

                            }*/

                        }
                        else
                        {

                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (quantityOfMoney / itemKardexToRemove.TAZACAMBIO);
                            currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / currentPostItemKardex.EXISTENCIA_ALMACEN;

                        }

                    }
                    else
                    {

                        if (withAverageCost)
                        {

                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (itemKardexToRemove.HABER * itemKardexToRemove.TAZACAMBIO) + (currentPostItemKardex.CMONEDA.Equals(this.CordobaLabel) ? currentPostItemKardex.HABER : currentPostItemKardex.HABER * currentPostItemKardex.TAZACAMBIO);
                            currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / currentPostItemKardex.EXISTENCIA_ANTERIOR;
                            currentPostItemKardex.COSTO = currentPostItemKardex.COSTO_PROMEDIO;

                            currentPostItemKardex.HABER = (currentPostItemKardex.SALIDA * currentPostItemKardex.COSTO_PROMEDIO) / currentPostItemKardex.TAZACAMBIO;
                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO - (currentPostItemKardex.HABER * currentPostItemKardex.TAZACAMBIO);

                            /*if (typeMovement)
                            {

                                currentPostItemKardex.DEBER = (currentPostItemKardex.ENTRADA * currentPostItemKardex.COSTO_PROMEDIO) / currentPostItemKardex.TAZACAMBIO;
                                currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (quantityOfMoney * currentPostItemKardex.TAZACAMBIO);

                            }
                            else
                            {

                                currentPostItemKardex.HABER = (currentPostItemKardex.SALIDA * currentPostItemKardex.COSTO_PROMEDIO) / currentPostItemKardex.TAZACAMBIO;
                                currentPostItemKardex.SALDO = currentPostItemKardex.SALDO - (currentPostItemKardex.HABER * currentPostItemKardex.TAZACAMBIO);

                            }*/

                        }
                        else
                        {

                            currentPostItemKardex.SALDO = currentPostItemKardex.SALDO + (quantityOfMoney * itemKardexToRemove.TAZACAMBIO);
                            currentPostItemKardex.COSTO_PROMEDIO = currentPostItemKardex.SALDO / currentPostItemKardex.EXISTENCIA_ALMACEN;

                        }

                    }

                }

            }

        }

    }

}