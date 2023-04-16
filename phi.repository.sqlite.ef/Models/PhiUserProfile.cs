using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUserProfile
    {
        public int PhiUserId { get; set; }
        public bool? Gender { get; set; }
        public string? AvatarPictureUrl { get; set; }
        public bool IsCompany { get; set; }
        public string? MainCompanyUrl { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyCeo { get; set; }
        public string? CompanyEmail { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyFax { get; set; }
        public string? AdditionalInfo { get; set; }
        public string? SellCompanyUrl { get; set; }
        public bool NotifyMeAboutSuddenWeatherEvents { get; set; }

        public virtual PhiUser PhiUser { get; set; } = null!;
    }
}
