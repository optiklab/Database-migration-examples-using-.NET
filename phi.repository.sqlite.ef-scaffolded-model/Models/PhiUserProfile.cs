using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUserProfile
    {
        public long PhiUserId { get; set; }
        public byte[]? Gender { get; set; }
        public string? AvatarPictureUrl { get; set; }
        public byte[] IsCompany { get; set; } = null!;
        public string? MainCompanyUrl { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyCeo { get; set; }
        public string? CompanyEmail { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyFax { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? SellCompanyUrl { get; set; }
        public byte[] NotifyMeAboutSuddenWeatherEvents { get; set; } = null!;

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
