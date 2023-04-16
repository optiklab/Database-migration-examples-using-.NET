using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class Language
    {
        public Language()
        {
            Blogs = new HashSet<Blog>();
            GoodThoughts = new HashSet<GoodThought>();
        }

        public long Id { get; set; }
        public string? Code { get; set; }
        public string? Fullname { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<GoodThought> GoodThoughts { get; set; }
    }
}
