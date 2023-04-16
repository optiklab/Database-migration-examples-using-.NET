using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUserLogin
    {
        public long Id { get; set; }
        public string ProviderKey { get; set; } = null!;
        public long PhiUserId { get; set; }

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
