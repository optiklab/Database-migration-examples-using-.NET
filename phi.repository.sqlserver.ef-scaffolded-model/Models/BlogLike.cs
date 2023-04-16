using System;
using System.Collections.Generic;

namespace Phi.Repository.SqlServer.Models
{
    public partial class BlogLike
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string PhiUserId { get; set; } = null!;
        public bool? IsWish { get; set; }
        public bool? IsLike { get; set; }
        public DateTime? DateTimeCreated { get; set; }

        public virtual Blog Blog { get; set; } = null!;
        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
