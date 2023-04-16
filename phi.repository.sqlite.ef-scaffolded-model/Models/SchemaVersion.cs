using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class SchemaVersion
    {
        public long SchemaVersionId { get; set; }
        public string ScriptName { get; set; } = null!;
        public byte[] Applied { get; set; } = null!;
    }
}
