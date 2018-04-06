using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sadara.DataLayer.Transaction
{

    interface IValid<T>
    {

        Boolean IsValid(T entity);

    }

}
