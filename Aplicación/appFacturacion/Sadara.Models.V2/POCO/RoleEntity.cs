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
    public partial class RoleEntity
    {

        public Guid RolId { get; set; }

        public string RolName { get; set; }

        public Boolean IsActive { get; set; }

    }

    public partial class RolEntity
    {

        public virtual ICollection<AccessInRoleEntity> AccessInRoles { get; set; }

    }

    public class RoleEntityMapping : EntityTypeConfiguration<RoleEntity>
    {

        public RoleEntityMapping()
        {

            this.ToTable("tblRoles");

            this.HasKey(c => c.RolId);

            this.Property(c => c.RolName)
                .HasColumnType("varchar")
                .HasMaxLength(50);

        }

    }
}
