using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class GoodThought
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public long LanguageId { get; set; }

        public virtual Language Language { get; set; } = null!;
    }
}
