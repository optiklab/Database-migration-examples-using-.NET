using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class QueuedEmail
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public string FromAddress { get; set; } = null!;
        public string FromName { get; set; } = null!;
        public string ToAddress { get; set; } = null!;
        public string ToName { get; set; } = null!;
        public string Cc { get; set; } = null!;
        public string Bcc { get; set; } = null!;
        public string EmailSubject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public DateTime? DateTimeCreated { get; set; }
        public int SentTries { get; set; }
        public DateTime? SentUtc { get; set; }
        public int EmailAccountId { get; set; }

        public virtual EmailAccount EmailAccount { get; set; } = null!;
    }
}
