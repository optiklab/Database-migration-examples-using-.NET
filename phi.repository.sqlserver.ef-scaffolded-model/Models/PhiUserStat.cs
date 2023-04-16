using System;
using System.Collections.Generic;

namespace Phi.Repository.SqlServer.Models
{
    public partial class PhiUserStat
    {
        public int Id { get; set; }
        public string PhiUserId { get; set; } = null!;
        public string? Browser { get; set; }
        public string? Ipaddress { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public DateTime? DateTime { get; set; }
        public string? UrlReferrer { get; set; }
        public string? Action { get; set; }
        public string? ActionPage { get; set; }

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
