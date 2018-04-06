using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sadara.DataLayer.Transaction;
using Sadara.Models.V1.Database;

namespace Sadara.DataLayer.TransactionToDb
{

    public class Transaction
    {

        private CodeFirst db;

        public CodeFirst Db {

            get { return this.db; }

        }

        public void CloseTransaction()
        {

            this.db.Dispose();

            this.db = null;

        }

        public Boolean IsDbStarted()
        {

            return this.db != null;

        }

        public void BeginTransaction()
        {

            if(this.IsDbStarted())
                this.db = new CodeFirst();

        }

        public int Commit()
        {

            return this.db.SaveChanges();

        }

        public async Task<int> CommitAsync()
        {

            return await this.db.SaveChangesAsync();

        }

    }

}