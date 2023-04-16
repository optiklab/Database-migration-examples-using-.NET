using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUserRole
    {
        public int PhiUserId { get; set; }
        public int RoleId { get; set; }
        public DateTime? DateTimeCreated { get; set; }

        public virtual PhiUser PhiUser { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
