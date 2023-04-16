using System;
using System.Collections.Generic;

namespace Phi.Repository.SqlServer.Models
{
    public partial class PhiUserRole
    {
        public string PhiUserId { get; set; } = null!;
        public int RoleId { get; set; }
        public DateTime? DateTimeCreated { get; set; }

        public virtual PhiUser PhiUser { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
