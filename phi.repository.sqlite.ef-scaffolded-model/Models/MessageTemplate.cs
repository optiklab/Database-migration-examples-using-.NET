using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class MessageTemplate
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string BccEmailAddresses { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public byte[] IsActive { get; set; } = null!;
        public long EmailAccountId { get; set; }

        public virtual EmailAccount EmailAccount { get; set; } = null!;
    }
}
