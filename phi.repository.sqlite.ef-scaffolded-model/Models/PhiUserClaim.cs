using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUserClaim
    {
        public long Id { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
        public long PhiUserId { get; set; }

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
