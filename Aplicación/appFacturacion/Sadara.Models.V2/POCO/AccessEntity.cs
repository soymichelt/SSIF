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
    
    public partial class AccessEntity
    {

        public Guid AccessId { get; set; }
        
        public byte AccessType { get; set; }

        public Guid AccountId { get; set; }

        public Boolean IsActive { get; set; }

    }

    public partial class AccessEntity
    {

        public virtual ICollection<AccessInRoleEntity> AccessInRoles { get; set; }

    }

    public class AccessEntityMapping : EntityTypeConfiguration<AccessEntity>
    {

        public AccessEntityMapping()
        {

            this.ToTable("tblAccess");

            this.HasKey(c => c.AccessId);

        }

    }

}
