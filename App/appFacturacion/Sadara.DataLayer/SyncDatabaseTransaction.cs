using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadara.DataLayer
{

    public class SyncDatabaseTransaction
    {

        public string composeQueryForExport(string tableName)
        {

            return $@"INSERT INTO {tableName}";

        }
        

        public void SyncDatabase(
            string databaseName,
            string databaseSyncName
        )
        {

        }

    }

}
