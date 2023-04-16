using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class BlogComment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int PhiUserId { get; set; }
        public string? Text { get; set; }
        public DateTime? DateTimeCreated { get; set; }

        public virtual Blog Blog { get; set; } = null!;
        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
