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
    public partial class UserAccountEntity
    {

        public Guid UserAccountId { get; set; }

        public string UserName { get; set; }

        public Nullable<Guid> PearsonId { get; set; }

        public Boolean IsActive { get; set; }

    }

    public partial class UserAccountEntity
    {

        public virtual ICollection<UserInGroupEntity> UsersInGroups { get; set; }

        public virtual ICollection<PasswordEntity> Passwords { get; set; }

    }

    public class UserAccountEntityMapping : EntityTypeConfiguration<UserAccountEntity>
    {

        public UserAccountEntityMapping()
        {

            this.ToTable("tblUsersAccounts");

            this.HasKey(c => c.UserAccountId);

            this.Property(c => c.UserName)
                .HasColumnType("varchar")
                .HasMaxLength(50);

        }

    }
}
