using System;
using System.Data.Entity.ModelConfiguration;

namespace Sadara.Models.V2.POCO
{

    public class MovementLogEntity
    {

        public Guid movementId { get; set; }

        public DateTime movementDate { get; set; }

        public string tableName { get; set; }

        public string movementType { get; set; }

    }

    public class MovementLogEntityMapping : EntityTypeConfiguration<MovementLogEntity>
    {

        public MovementLogEntityMapping()
        {

            this.ToTable("tblMovementLogs");

            this.HasKey(c => c.movementId);

        }

    }

}
