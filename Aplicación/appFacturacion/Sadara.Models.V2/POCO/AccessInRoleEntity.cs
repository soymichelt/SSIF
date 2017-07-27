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
    public partial class AccessInRoleEntity
    {

        [Column(Order = 0), Key(), ForeignKey("Access")]
        public Guid AccessId { get; set; }

        [Column(Order = 1), Key(), ForeignKey("Role")]
        public Guid RoleId { get; set; }

    }

    public partial class AccessInRoleEntity
    {

        public virtual AccessEntity Access { get; set; }

        public virtual RoleEntity Role { get; set; }

    }

    public class AccessInRoleEntityMapping : EntityTypeConfiguration<AccessInRoleEntity>
    {

        public AccessInRoleEntityMapping()
        {

            this.ToTable("tblAccessInRoles");

        }

    }
}
