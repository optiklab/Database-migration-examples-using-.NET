using System;
using System.Collections.Generic;

namespace Phi.Repository.SqlServer.Models
{
    public partial class PhiUserLogin
    {
        public int Id { get; set; }
        public string ProviderKey { get; set; } = null!;
        public string PhiUserId { get; set; } = null!;

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
