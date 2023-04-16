using System;
using System.Collections.Generic;

namespace Phi.Repository.SqlServer.Models
{
    public partial class PhiUserClaim
    {
        public int Id { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
        public string PhiUserId { get; set; } = null!;

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
