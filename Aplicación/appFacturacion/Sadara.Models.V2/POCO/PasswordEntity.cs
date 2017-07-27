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
    public partial class PasswordEntity
    {

        public Guid PasswordId { get; set; }

        public string PasswordValue { get; set; }

        public Guid UserId { get; set; }

    }

    public partial class PasswordEntity
    {

        public virtual UserAccountEntity UserAccount { get; set; }

    }

    public class PasswordEntityMapping : EntityTypeConfiguration<PasswordEntity>
    {
        
        public PasswordEntityMapping()
        {

            this.ToTable("tblPasswords");

            this.HasKey(c => c.PasswordId);

            this.Property(c => c.PasswordValue)
                .HasColumnName("Password")
                .HasColumnType("varchar")
                .HasMaxLength(200);

        }

    }
}
