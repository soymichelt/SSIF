using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadara.DataLayer.Transaction
{

    public interface IFind<T, V>
    {

        T Find(V entity);

    }

}
