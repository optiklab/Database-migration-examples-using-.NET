using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class Role
    {
        public Role()
        {
            PhiUserRoles = new HashSet<PhiUserRole>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public byte[] Active { get; set; } = null!;

        public virtual ICollection<PhiUserRole> PhiUserRoles { get; set; }
    }
}
