using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class EmailAccount
    {
        public EmailAccount()
        {
            MessageTemplates = new HashSet<MessageTemplate>();
            QueuedEmails = new HashSet<QueuedEmail>();
        }

        public long Id { get; set; }
        public string Email { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Host { get; set; } = null!;
        public long Port { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte[] EnableSsl { get; set; } = null!;
        public byte[] UseDefaultCredentials { get; set; } = null!;

        public virtual ICollection<MessageTemplate> MessageTemplates { get; set; }
        public virtual ICollection<QueuedEmail> QueuedEmails { get; set; }
    }
}
