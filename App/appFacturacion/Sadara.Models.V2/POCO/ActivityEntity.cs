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

    public class ActivityEntity
    {

        public Guid ActivityId { get; set; }

        public DateTime ActivityDate { get; set; }

        public Guid BusinessId { get; set; }

        public string Type { get; set; }

        public string Tag { get; set; }

        public string ActivityValue { get; set; }

        public string OptionalMessage { get; set; }

        public Nullable<Guid> UserId { get; set; }

        public Boolean IsSended { get; set; }

    }

    public class ActivityEntityMapping : EntityTypeConfiguration<ActivityEntity>
    {

        public ActivityEntityMapping()
        {

            this.ToTable("tblActivities");

            this.HasKey(c => c.ActivityId);

            this.Property(c => c.BusinessId)
                .IsRequired();

            this.Property(c => c.ActivityDate)
                .IsRequired();

            this.Property(c => c.Type)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.ActivityValue)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.UserId)
                .IsOptional();

            this.Property(c => c.IsSended)
                .IsRequired();

        }

    }

}