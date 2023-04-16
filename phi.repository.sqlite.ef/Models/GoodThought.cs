using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class GoodThought
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; } = null!;
    }
}
