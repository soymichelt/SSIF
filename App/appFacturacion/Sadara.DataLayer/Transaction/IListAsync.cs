using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadara.DataLayer.Transaction
{
    public interface IListAsync<T>
    {

        Task<List<T>> ListAsync();

    }
}
