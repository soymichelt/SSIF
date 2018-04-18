using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sadara.DataLayer;
using Sadara.DataLayer.Transaction;
using Sadara.DataLayer.TransactionToDb;
using Sadara.Models.V1.Database;
using Sadara.Models.V2.POCO;

namespace Sadara.BusinessLayer
{

    public class Activity
    {

        private static Activity instance;

        private static bool InstanceIsInitialized()
        {

            return instance == null;

        }

        private static void InitializeInstance()
        {

            instance = new Activity();

        }

        public static Activity Instance {

            get {

                if (InstanceIsInitialized())
                    InitializeInstance();

                return instance;

            }

        }

        protected Activity() { }

        private Transaction transaction;

        private DataLayer.Activity activity;

        private CodeFirst db;

        private void Init()
        {

            this.db = new CodeFirst();
            this.transaction = new Transaction();
            this.transaction.Db = this.db;
            this.activity = new DataLayer.Activity();
            this.activity.TransactionToDb = this.transaction;

        }

        private Boolean IsTransactionInitialized()
        {

            return this.transaction != null;

        }

        private Boolean IsActivityInitialized()
        {

            return this.activity != null;

        }

        private void CloseTransaction()
        {

            if(this.IsTransactionInitialized())
                this.transaction = null;

        }

        private void CloseActivity()
        {

            if (this.IsActivityInitialized())

                this.activity = null;

        }

        private void Dispose()
        {

            this.CloseTransaction();

            this.CloseActivity();
                
        }

        public async Task<ActivityEntity> AddAsync(ActivityEntity activity)
        {

            this.activity.Add(activity);

            await this.transaction.CommitAsync();

            return activity;

        }

        public async Task EditAsync(ActivityEntity activity)
        {

            this.activity.Edit(activity);

            await this.transaction.CommitAsync();

        }

        public async Task<ActivityEntity> FindAsync(Guid activityId)
        {

            return await this.activity.FindAsync(activityId);

        }

        public async Task RemoveAsync(Guid activityId)
        {

            ActivityEntity activitySelected = await this.FindAsync(activityId);

            if (activitySelected != null)
            {

                this.activity.Remove(activitySelected);

                await this.transaction.CommitAsync();

            }

        }

    }

}