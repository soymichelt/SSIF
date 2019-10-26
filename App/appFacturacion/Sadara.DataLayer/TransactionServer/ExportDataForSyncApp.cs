using Sadara.Models.V1.Database;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Sadara.DataLayer.TransactionServer
{

    public class ExportDataForSyncApp
    {

        public string ExportToDatabase { get; set; }

        public string ExportFromDatabase { get; set; }

        public SqlConnection SqlConnection { get; set; }

        private void CreateIfNotExistDatabaseToGetData()
        {

            using (CodeFirst dbToGetData = new CodeFirst(this.ExportFromDatabase))
            {

                dbToGetData.Database.CreateIfNotExists();

            }

        }


        
        private void ExecuteTransaction(SqlConnection sqlConnection)
        {

            sqlConnection.Open();
            SqlTransaction transaction = sqlConnection.BeginTransaction(
                System.Data.IsolationLevel.Serializable,
                "SyncApp"
            );
            SqlCommand command = sqlConnection.CreateCommand();
            command.Connection = sqlConnection;
            command.Transaction = transaction;

            try
            {

                //Ejecutar transaction

                transaction.Commit();

            }
            catch (Exception ex)
            {

                transaction.Rollback();
                throw ex;

            }
            finally
            {

                command.Dispose();
                transaction.Dispose();

            }

        }

        private void Validate()
        {

            if (SqlConnection == null) throw new Exception("Definir la conexión a SQL Server");

            if (ExportToDatabase == null)
            {
                throw new Exception($"El campo '{nameof(ExportToDatabase)}' no puede ser null");
            }
            else if (ExportToDatabase.Trim() == "")
            {
                throw new Exception($"El campo '{nameof(ExportToDatabase)}' no puede ser una cadena vacía");
            }

            if (ExportFromDatabase == null)
            {
                throw new Exception($"El campo '{nameof(ExportFromDatabase)}' no puede ser null");
            }
            else if (ExportFromDatabase.Trim() == "")
            {
                throw new Exception($"El campo '{nameof(ExportFromDatabase)}' no puede ser una cadena vacía");
            }

        }

        public Task ExportDataAsync()
        {

            Validate();
            
            return Task.Run(() => {

                

            });

        }

    }

}
