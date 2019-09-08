using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sadara.DataLayer.TransactionServer
{

    public class ExportDataForSyncApp
    {

        public string ExportToDatabase { get; set; }

        public string ExportFromDatabase { get; set; }

        public SqlConnection SqlConnection { get; set; }

        string GenerateQueryForExport(
            string fromDatabase,
            string toDatabase,
            string tableName,
            Dictionary<string, string> parameters
        )
        {

            StringBuilder queryStatement = new StringBuilder();

            queryStatement.AppendLine($"INSERT INTO [{toDatabase}].[dbo].[{tableName.Trim()}]");

            queryStatement.AppendLine("(");

            int i = 0;

            string separator;

            foreach (var param in parameters)
            {
                i++;
                separator = i != parameters.Count ? "," : "";
                queryStatement.AppendLine($"[{param.Key}]{separator}");
            }

            queryStatement.AppendLine(")");

            queryStatement.AppendLine("SELECT");

            i = 0;

            foreach (var param in parameters)
            {
                i++;
                separator = i != parameters.Count ? "," : "";
                queryStatement.AppendLine($"{param.Value}{separator}");
            }

            queryStatement.AppendLine($"FROM [{fromDatabase}].[dbo].[{tableName}]");

            return queryStatement.ToString();

        }

        private List<string> queries = new List<string>();

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

                queries.ForEach(query =>
                {
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                });

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
