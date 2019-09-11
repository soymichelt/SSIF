using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sadara.DataLayer.TransactionToDb;
using Sadara.Models.V1.POCO;
using Sadara.Models.V2;

namespace Sadara.DataLayer
{

    public class ProviderTransaction :
        TransactionToDb.TransactionBase<Proveedor>
    {

        private TransactionToDb.Transaction transaction;

        public TransactionToDb.Transaction TransactionToDb { set => transaction = value; }

        public override Proveedor Add(Proveedor provider)
        {

            this.transaction.Db.Proveedores.Add(provider);

            return provider;

        }

        public override void Remove(Proveedor provider)
        {

            this.transaction.Db.Proveedores.Remove(provider);

        }

        public override void Edit(Proveedor provider)
        {

            this.transaction.Db.Entry(provider).State = System.Data.Entity.EntityState.Modified;

        }

        public async override Task<Proveedor> FindAsync<U>(U providerId)
        {

            Proveedor provider = await this.transaction.Db.Proveedores.FindAsync(providerId);

            return provider;

        }

        public async override Task<List<Proveedor>> ListAsync()
        {

            return await this.transaction.Db.Proveedores.ToListAsync();

        }
        
        public async Task<List<Sadara.Models.V2.POCO.AccountToPayEntity>> GetListAccountsToPayAsync(
            string money,
            decimal exchangeRate,
            string providerCode = "",
            string providerName = "",
            string businessName = ""
        )
        {

            var accountsToPay = await this.transaction.Db.Database.SqlQuery<Sadara.Models.V2.POCO.AccountToPayEntity>
                (
                    "SpAccountsToPay @ProviderCode, @ProviderName, @BusinessName, @ExchangeRate",
                    new SqlParameter("@ProviderCode", providerCode),
                    new SqlParameter("@ProviderName", providerName),
                    new SqlParameter("@BusinessName", businessName),
                    new SqlParameter("@ExchangeRate", exchangeRate)
                )
                .ToListAsync();
            
            return accountsToPay;

        }

    }

}