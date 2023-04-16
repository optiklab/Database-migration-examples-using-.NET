using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUserAttribute
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public long PhiUserId { get; set; }

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
