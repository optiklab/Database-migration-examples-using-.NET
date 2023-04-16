using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUserAttribute
    {
        public int Id { get; set; }
        public int PhiUserId { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
