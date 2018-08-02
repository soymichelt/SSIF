using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sadara.DataLayer;
using Sadara.DataLayer.TransactionToDb;

namespace Sadara.BusinessLayer
{

    public class Customer
    {

        #region Abstracción en Singleton

        private static Customer instance;

        private static readonly object padlock = new object();

        private static bool InstanceIsInitialized()
        {

            return instance != null;

        }

        private static void InitializeInstance()
        {

            instance = new Customer();

        }

        public static Customer Instance
        {

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

        #endregion

        protected Customer()
        { }

        private Transaction transaction;

        private CustomerTransaction customerTransaction;

        private Sadara.Models.V1.Database.CodeFirst db;

        private void InitializeTransactionComponents()
        {

            this.db = new Models.V1.Database.CodeFirst();

            this.transaction = new Transaction() { Db = this.db };

            this.customerTransaction = new CustomerTransaction() { TransactionToDb = this.transaction };

        }

        public async Task<List<Sadara.Models.V2.POCO.AccountReceivableEntity>> GetListAccountsReceivableAsync(
            string money,
            decimal exchangeRate,
            string customerCode = "",
            string customerName = "",
            string businessName = ""
        )
        {

            this.InitializeTransactionComponents();

            return await this.customerTransaction.GetListAccountsReceivableAsync(
                money, exchangeRate, customerCode, customerName, businessName
            );

        }

    }

}