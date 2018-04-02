using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sadara.DataLayer.Transaction;
using Sadara.Models.V1.Database;

namespace Sadara.DataLayer.TransactionToDb
{

    class Transaction
    {

        private CodeFirst db;

        public CodeFirst Db { get; }

        private void closeTransaction()
        {

            this.db.Dispose();

            this.db = null;

        }

        private Boolean isDbStarted()
        {

            return this.db != null;

        }

        private void beginTransaction()
        {

            if(this.isDbStarted())
                this.db = new CodeFirst();

        }

        private int commit()
        {

            return this.db.SaveChanges();

        }

        private async Task<int> commitAsync()
        {

            return await this.db.SaveChangesAsync();

        }

    }

}