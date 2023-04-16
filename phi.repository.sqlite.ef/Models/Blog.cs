using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class Blog
    {
        public Blog()
        {
            BlogComments = new HashSet<BlogComment>();
            BlogLikes = new HashSet<BlogLike>();
        }

        public int Id { get; set; }
        public string? Theme { get; set; }
        public string? Article { get; set; }
        public string? Header { get; set; }
        public int? Rating { get; set; }
        public string? Tags { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? DateTimeCreated { get; set; }
        public string? UniqueId { get; set; }
        public string? SourceUrl { get; set; }
        public int LanguageId { get; set; }
        public string? ProviderName { get; set; }

        public virtual Language Language { get; set; } = null!;
        public virtual ICollection<BlogComment> BlogComments { get; set; }
        public virtual ICollection<BlogLike> BlogLikes { get; set; }
    }
}
