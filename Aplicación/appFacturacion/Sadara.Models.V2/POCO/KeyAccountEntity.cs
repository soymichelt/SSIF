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
    public partial class KeyAccountEntity
    {

        public Guid KeyId { get; set; }

        public string KeyName { get; set; }

        public string KeyData { get; set; }

        public Boolean IsActive { get; set; }

    }

    public partial class KeyAccountEntity
    {



    }

    public class KeyAccountEntityMapping : EntityTypeConfiguration<KeyAccountEntity>
    {

        public KeyAccountEntityMapping()
        {

            this.ToTable("tblKeysAccounts");

            this.HasKey(c => c.KeyId);

            this.Property(c => c.KeyName)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            this.Property(c => c.KeyName)
                .HasColumnType("varchar")
                .HasMaxLength(20);

        }

    }
}
