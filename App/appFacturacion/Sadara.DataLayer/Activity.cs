using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sadara.DataLayer.Transaction;
using Sadara.DataLayer.TransactionToDb;
using Sadara.Models.V2.POCO;

namespace Sadara.DataLayer
{

    public class Activity :
        TransactionBase<ActivityEntity>
    {

        private TransactionToDb.Transaction transaction;

        public TransactionToDb.Transaction TransactionToDb {

            set { this.transaction = value; }

        }

        public override ActivityEntity Add(ActivityEntity activity)
        {

            //this.transaction.Db.Activities.Add(activity);

            return activity;

        }

        public override void Edit(ActivityEntity activity)
        {

            //this.transaction.Db.Entry(activity).State = EntityState.Modified;

        }

        public override void Remove(ActivityEntity activity)
        {

            //this.transaction.Db.Activities.Remove(activity);

        }

        public async override Task<ActivityEntity> FindAsync<Guid>(Guid ActivityId)
        {

            /*ActivityEntity activity = await this.transaction.Db.Activities.FindAsync(ActivityId);

            return activity;*/

            return null;

        }

        public async override Task<List<ActivityEntity>> ListAsync()
        {

            /*List<ActivityEntity> list = await this.transaction.Db.Activities.ToListAsync();

            return list;*/

            return null;

        }

    }

}