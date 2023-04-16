using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUserStat
    {
        public long Id { get; set; }
        public long PhiUserId { get; set; }
        public string? Browser { get; set; }
        public string? Ipaddress { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public byte[]? DateTime { get; set; }
        public string? UrlReferrer { get; set; }
        public string? Action { get; set; }
        public string? ActionPage { get; set; }

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
