using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sadara.Models.V2.POCO
{
    public partial class TransactionEntity
    {

        public Guid TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public Guid UserId { get; set; }

        public Nullable<Guid> AccessId { get; set; }

        public byte TransactionType { get; set; }

        public string TableName { get; set; }

    }

    public partial class TransactionEntity
    {

        public virtual UserAccountEntity UserAccount { get; set; }

        public virtual AccessEntity Access { get; set; }

        public virtual ICollection<TransactionLogEntity> TransactionsLogs { get; set; }

    }

    public class TransactionEntity : EntityTypeConfiguration<TransactionEntity>
    {

        public TransactionEntity()
        {

            this.ToTable("tblTransactions");

            this.HasKey(c => c.TransactionId);

        }

    }
}
