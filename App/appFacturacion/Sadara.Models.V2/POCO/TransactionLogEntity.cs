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

    public partial class TransactionLogEntity
    {

        public Guid LogId { get; set; }

        public Guid TransactionId { get; set; }

        public string ColumnName { get; set; }

        public Guid RegisterId { get; set; }

        public string RegisterValue { get; set; }

    }

    public partial class TransactionLogEntity
    {

        public virtual TransactionEntity Transaction { get; set; }

    }

    public class TransactionLogEntityMapping : EntityTypeConfiguration<TransactionLogEntity>
    {

        public TransactionLogEntityMapping()
        {

            this.ToTable("tblTransactionsLogs");

            this.HasKey(c => c.LogId);

        }

    }

}