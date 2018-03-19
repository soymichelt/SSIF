using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sadara.Models.V1.Database;
using Sadara.Models.V1.POCO;

namespace Sadara.DataLayer.Transaction
{

    class QueryDb
    {

        public int ExecuteQuery(string query)
        {

            using (var db = new CodeFirst())
            {

                return db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, query);

            }

        }

        public async Task<int> ExecuteQueryAsync(string query)
        {

            using (var db = new CodeFirst())
            {

                return await db.Database.ExecuteSqlCommandAsync(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, query);

            }

        }

    }

}
