using Sadara.DataLayer;
using Sadara.DataLayer.TransactionToDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadara.BusinessLayer
{

    public class Provider
    {
        
        private static Provider instance;

        private static readonly object padlock = new object();

        private static bool InstanceIsInitialized()
        {

            return instance != null;

        }

        private static void InitializeInstance()
        {

            instance = new Provider();

        }

        public static Provider Instance
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

        protected Provider()
        { }

        private Transaction transaction;

        private ProviderTransaction providerTransaction;

        private Sadara.Models.V1.Database.CodeFirst db;

        private void InitializeTransactionComponents()
        {

            this.db = new Models.V1.Database.CodeFirst();

            this.transaction = new Transaction() { Db = this.db };

            this.providerTransaction = new ProviderTransaction() { TransactionToDb = this.transaction };

        }

        public async Task<List<Sadara.Models.V2.POCO.AccountToPayEntity>> GetListAccountsToPayAsync(string money, string customerCode = "", string customerName = "", string businessName = "")
        {

            this.InitializeTransactionComponents();

            return await this.providerTransaction.GetListAccountsToPayAsync(money, customerCode, customerName, businessName);

        }

    }

}