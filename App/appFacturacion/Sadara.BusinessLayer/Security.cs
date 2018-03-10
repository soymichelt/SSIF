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

        private void AddBackup(string path)
        {

            Backup backup = new Backup();

            this.ValidatePath(path);

            backup.Add(path);

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

        public void CreateBackupOfDb(string path)
        {

            this.AddBackup(path);

        }
        
    }

}