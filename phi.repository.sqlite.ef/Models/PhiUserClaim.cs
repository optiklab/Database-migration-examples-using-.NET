using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUserClaim
    {
        public int Id { get; set; }
        public int PhiUserId { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
