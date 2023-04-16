using System;
using System.Collections.Generic;

namespace Phi.Repository.SqlServer.Models
{
    public partial class MessageTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string BccEmailAddresses { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public bool IsActive { get; set; }
        public int EmailAccountId { get; set; }

        public virtual EmailAccount EmailAccount { get; set; } = null!;
    }
}
