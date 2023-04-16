using System;
using System.Collections.Generic;

namespace Phi.Repository.SqlServer.Models
{
    public partial class Language
    {
        public Language()
        {
            Blogs = new HashSet<Blog>();
            GoodThoughts = new HashSet<GoodThought>();
        }

        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Fullname { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<GoodThought> GoodThoughts { get; set; }
    }
}
