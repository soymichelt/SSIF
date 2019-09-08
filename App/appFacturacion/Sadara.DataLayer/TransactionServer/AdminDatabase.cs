using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Sadara.DataLayer.TransactionServer
{

    public class AdminDatabase
    {

        public void DetachDatabase(
            string databaseName,
            SqlConnection sqlConnection
        )
        {

            ServerConnection serverConnection = new ServerConnection(sqlConnection);

            Server server = new Server(serverConnection);

            server.DetachDatabase(databaseName, false);

        }

        public void AttachDatabase(
            string databaseName,
            StringCollection files,
            SqlConnection sqlConnection
        )
        {

            ServerConnection serverConnection = new ServerConnection(sqlConnection);

            Server server = new Server(serverConnection);

            server.AttachDatabase(
                databaseName,
                files
            );

        }

        public void KillAllConnectionsToDatabase(
            string databaseName,
            SqlConnection sqlConnection
        )
        {

            ServerConnection serverConnection = new ServerConnection(sqlConnection);

            Server server = new Server(serverConnection);

            server.KillAllProcesses(databaseName);

        }

    }

}
