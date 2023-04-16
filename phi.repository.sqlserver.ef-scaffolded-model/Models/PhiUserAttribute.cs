using System;
using System.Collections.Generic;

namespace Phi.Repository.SqlServer.Models
{
    public partial class PhiUserAttribute
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string PhiUserId { get; set; } = null!;

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
