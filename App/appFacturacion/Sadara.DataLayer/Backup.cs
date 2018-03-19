using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadara.DataLayer
{

    public class Backup : Transaction.IAddAsync<string>
    {

        private async Task AddBackup(string path)
        {

            Transaction.QueryDb cmd = new Transaction.QueryDb();

            string nameBackup = "BACKUP-" + DateTime.Now.ToString("dd-MM-yyyy-HH-MM-ss") + "-" + Guid.NewGuid().ToString() + ".bak";

            path += @"\" + nameBackup;

            string query = (
                "BACKUP DATABASE " +
                "[" + Sadara.Models.V1.Config.InitialCatalog + "] " +
                "TO DISK = '" + path + "' " +
                "WITH " +
                "FORMAT, " +
                "MEDIANAME = 'SIF_Backups', " +
                "NAME = '" + nameBackup + "'"
            );

            await cmd.ExecuteQueryAsync(query);

        }

        public async Task<string> AddAsync(string path)
        {

            await this.AddBackup(path);

            return path;

        }

    }

}