using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class BlogLike
    {
        public long Id { get; set; }
        public long BlogId { get; set; }
        public long PhiUserId { get; set; }
        public byte[]? IsWish { get; set; }
        public byte[]? IsLike { get; set; }
        public byte[]? DateTimeCreated { get; set; }

        public virtual Blog Blog { get; set; } = null!;
        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
