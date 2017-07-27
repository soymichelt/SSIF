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
    public partial class GroupAccountEntity
    {

        public Guid GroupId { get; set; }

        public string GroupName { get; set; }

        public Boolean IsActive { get; set; }

    }

    public partial class GroupAccountEntity
    {

        public virtual ICollection<UserInGroupEntity> UsersInGroups { get; set; }

    }

    public class GroupAccountEntityMapping : EntityTypeConfiguration<GroupAccountEntity>
    {

        public GroupAccountEntityMapping()
        {

            this.ToTable("tblGroupsAccounts");

            this.HasKey(c => c.GroupId);

            this.Property(c => c.GroupName)
                .HasColumnType("varchar")
                .HasMaxLength(50);

        }

    }
}
