using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sadara.DataLayer.Transaction;
using Sadara.Models.V2.POCO;

namespace Sadara.DataLayer.TransactionToDb
{

    internal abstract class TransactionBase<T> :
        IAdd<T>,
        IEdit<T>,
        IRemove<T>,
        IFindAsync<T>,
        IListAsync<T>
    {

        public abstract T Add(T entity);

        public abstract void Edit(T entity);

        public abstract void Remove(T entity);

        public abstract Task<T> FindAsync<U>(U entityId);

        public abstract Task<List<T>> ListAsync();

    }

}