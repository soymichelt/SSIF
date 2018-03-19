using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Sadara.DataLayer;

namespace Sadara.BusinessLayer
{

    public class Security
    {

        private async Task AddBackupAsync(string path)
        {

            Backup backup = new Backup();

            this.ValidatePath(path);

            await backup.AddAsync(path);

        }

        private Boolean IsExistsPath(string path)
        {

            return Directory.Exists(path);

        }

        private void ValidatePath(string path)
        {

            if (!this.IsExistsPath(path))
                throw new Exception("No se encuentra el directorio: '" + path + "'");

        }

        public async Task CreateBackupOfDbAsync(string path)
        {

            await this.AddBackupAsync(path);

        }
        
    }

}