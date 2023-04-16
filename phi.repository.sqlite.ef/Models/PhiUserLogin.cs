using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUserLogin
    {
        public int Id { get; set; }
        public int PhiUserId { get; set; }
        public string ProviderKey { get; set; } = null!;

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
