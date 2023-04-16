using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class QueuedEmail
    {
        public long Id { get; set; }
        public long Priority { get; set; }
        public string FromAddress { get; set; } = null!;
        public string FromName { get; set; } = null!;
        public string ToAddress { get; set; } = null!;
        public string ToName { get; set; } = null!;
        public string Cc { get; set; } = null!;
        public string Bcc { get; set; } = null!;
        public string EmailSubject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public byte[]? DateTimeCreated { get; set; }
        public long SentTries { get; set; }
        public byte[]? SentUtc { get; set; }
        public long EmailAccountId { get; set; }

        public virtual EmailAccount EmailAccount { get; set; } = null!;
    }
}
