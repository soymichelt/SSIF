using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sadara.Models.V1.POCO;

namespace Sadara.DataLayer
{

    public class CustomerTransaction :
        TransactionToDb.TransactionBase<Sadara.Models.V1.POCO.Cliente>
    {

        private TransactionToDb.Transaction transaction;

        public TransactionToDb.Transaction TransactionToDb
        {

            set { this.transaction = value; }

        }

        public override Cliente Add(Cliente customer)
        {

            this.transaction.Db.Clientes.Add(customer);

            return customer;

        }

        public override void Edit(Cliente customer)
        {

            this.transaction.Db.Entry(customer).State = System.Data.Entity.EntityState.Modified;

        }

        public override void Remove(Cliente customer)
        {

            this.transaction.Db.Clientes.Remove(customer);

        }

        public async override Task<Cliente> FindAsync<U>(U customerId)
        {

            Cliente customer = await this.transaction.Db.Clientes.FindAsync(customerId);

            return customer;

        }

        public async override Task<List<Cliente>> ListAsync()
        {

            List<Cliente> list = await this.transaction.Db.Clientes.ToListAsync();

            return list;

        }

        public List<Sadara.Models.V2.POCO.AccountReceivableEntity> GetListAccountsReceivable(string money, string customerCode = "", string customerName = "", string businessName = "")
        {
            
            var list = this.transaction.Db.Database.SqlQuery<Sadara.Models.V2.POCO.AccountReceivableEntity>("SpAccountsReceivable @CustomerCode, @CustomerName, @BusinessName, @Money", new SqlParameter("@CustomerCode", customerCode), new SqlParameter("@CustomerName", customerName), new SqlParameter("@BusinessName", businessName), new SqlParameter("@Money", money)).ToList();

            return list;

        }

    }
    
}