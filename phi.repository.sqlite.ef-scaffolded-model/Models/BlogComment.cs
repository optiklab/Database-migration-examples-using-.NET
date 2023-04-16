using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class BlogComment
    {
        public long Id { get; set; }
        public long BlogId { get; set; }
        public long PhiUserId { get; set; }
        public string? Text { get; set; }
        public byte[]? DateTimeCreated { get; set; }

        public virtual Blog Blog { get; set; } = null!;
        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
