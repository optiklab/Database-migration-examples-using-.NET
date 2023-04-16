using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUserRole
    {
        public long PhiUserId { get; set; }
        public long RoleId { get; set; }
        public byte[]? DateTimeCreated { get; set; }

        public virtual PhiUser PhiUser { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
