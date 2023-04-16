using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class Image
    {
        public long Id { get; set; }
        public long? PhiUserId { get; set; }
        public string? ImageUrl { get; set; }
        public long? Height { get; set; }
        public long? Width { get; set; }

        public virtual PhiUser? PhiUser { get; set; }
    }
}
