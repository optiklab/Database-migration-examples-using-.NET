using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
