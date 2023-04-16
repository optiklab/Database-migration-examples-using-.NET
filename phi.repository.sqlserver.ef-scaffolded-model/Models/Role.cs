using System;
using System.Collections.Generic;

namespace Phi.Repository.SqlServer.Models
{
    public partial class Role
    {
        public Role()
        {
            PhiUserRoles = new HashSet<PhiUserRole>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<PhiUserRole> PhiUserRoles { get; set; }
    }
}
