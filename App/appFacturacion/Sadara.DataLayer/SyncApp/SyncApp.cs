using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using Sadara.Models.V1.Database;

namespace Sadara.DataLayer.SyncApp
{

    public class SyncApp
    {

        private string connectStringToTempDatabase;

        public string ConnectionStringToTempDatabase { set => connectStringToTempDatabase = value; }

        CodeFirst db;

        private void CreateIfNotExistTempDatabase()
        {

            db = new CodeFirst(this.connectStringToTempDatabase);

            db.Database.CreateIfNotExists();

        }

        private void ExecuteStoredProcedureForSync()
        {

            using (SqlConnection connection = new SqlConnection(this.connectStringToTempDatabase))
            {

                using (SqlTransaction transaction = connection.BeginTransaction(
                    System.Data.IsolationLevel.Serializable,
                    "SyncApp"
                ))
                {

                    SqlCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.Transaction = transaction;

                    try
                    {

                        command.CommandText = "SpSyncApp";
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        throw ex;

                    }

                }

            }

        }

        public void Export()
        {

            this.CreateIfNotExistTempDatabase();

            

        }

    }

}
