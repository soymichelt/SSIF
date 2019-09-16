using System;
using System.Data.Entity.ModelConfiguration;

namespace Sadara.Models.V2.POCO
{

    public class DataForSyncEntity
    {

        public Guid DataId { get; set; }

        public DateTime Date { get; set; }

        public string TableName { get; set; }

        public string TransactionType { get; set; }

        public Guid ValueId { get; set; }

        public bool IsApplied { get; set; }

    }

    public partial class DataForSyncEntityConfiguration : EntityTypeConfiguration<DataForSyncEntity>
    {

        public DataForSyncEntityConfiguration()
        {

            this.ToTable("tblDataForSync");

            this.HasKey(c => c.DataId);

        }

    }

}