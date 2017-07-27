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
    public partial class UserInGroupEntity
    {

        [Column(Order = 0), Key(), ForeignKey("UserAccount")]
        public Guid UserId { get; set; }

        [Column(Order = 1), Key(), ForeignKey("GroupAccountEntity")]
        public Guid GroupId { get; set; }

    }

    public partial class UserInGroupEntity
    {

        public virtual UserAccountEntity UserAccount { get; set; }

        public virtual GroupAccountEntity GroupAccountEntity { get; set; }

    }

    public class UserInGroupEntityMapping : EntityTypeConfiguration<UserInGroupEntity>
    {

        public UserInGroupEntityMapping()
        {

            this.ToTable("tblUsersInGroups");

        }

    }
}
