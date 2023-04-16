using System;
using System.Collections.Generic;

namespace Phi.Repository.SqlServer.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string? PhiUserId { get; set; }
        public string? ImageUrl { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }

        public virtual PhiUser? PhiUser { get; set; }
    }
}
