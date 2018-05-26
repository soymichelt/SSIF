using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sadara.DataLayer;
using Sadara.DataLayer.TransactionToDb;
using Sadara.Models.V1.Database;
using Sadara.Models.V2.POCO;

namespace Sadara.BusinessLayer
{

    public class Activity
    {

        private static Activity instance;

        private static readonly object padlock = new object();

        private static bool InstanceIsInitialized()
        {

            return instance != null;

        }

        private static void InitializeInstance()
        {

            instance = new Activity();

        }

        public static Activity Instance {

            get {

                lock (padlock)
                {

                    if (!InstanceIsInitialized())
                        InitializeInstance();

                    return instance;

                }

            }

        }

        protected Activity() { }

        private Transaction transaction;

        private DataLayer.ActivityTransaction activityTransaction;

        private CodeFirst db;

        private void InitializeTransactionComponents()
        {

            this.db = new CodeFirst();

            this.transaction = new Transaction { Db = this.db };

            this.activityTransaction = new DataLayer.ActivityTransaction { TransactionToDb = this.transaction };

        }

        private Boolean IsTransactionInitialized()
        {

            return this.transaction != null;

        }

        private Boolean IsActivityInitialized()
        {

            return this.activityTransaction != null;

        }

        private void CloseTransaction()
        {

            if(this.IsTransactionInitialized())
                this.transaction = null;

        }

        private void CloseActivity()
        {

            if (this.IsActivityInitialized())

                this.activityTransaction = null;

        }

        private void Dispose()
        {

            this.CloseTransaction();

            this.CloseActivity();
                
        }

        public async Task<ActivityEntity> AddAsync(ActivityEntity activityEntity)
        {

            this.InitializeTransactionComponents();

            activityEntity.ActivityId = Guid.NewGuid();

            activityEntity.ActivityDate = DateTime.Now;

            this.activityTransaction.Add(activityEntity);

            await this.transaction.CommitAsync();

            return activityEntity;

        }

        public async Task EditAsync(ActivityEntity activityEntity)
        {

            this.activityTransaction.Edit(activityEntity);

            await this.transaction.CommitAsync();

        }

        public async Task<ActivityEntity> FindAsync(Guid activityId)
        {

            return await this.activityTransaction.FindAsync(activityId);

        }

        public async Task RemoveAsync(Guid activityId)
        {

            ActivityEntity activitySelected = await this.FindAsync(activityId);

            if (activitySelected != null)
            {

                this.activityTransaction.Remove(activitySelected);

                await this.transaction.CommitAsync();

            }

        }

    }

}