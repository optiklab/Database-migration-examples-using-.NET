using System;
using System.Collections.Generic;

namespace Phi.Repository.Sqlite.Models
{
    public partial class PhiUser
    {
        public PhiUser()
        {
            BlogComments = new HashSet<BlogComment>();
            BlogLikes = new HashSet<BlogLike>();
            Images = new HashSet<Image>();
            PhiUserAttributes = new HashSet<PhiUserAttribute>();
            PhiUserClaims = new HashSet<PhiUserClaim>();
            PhiUserLogins = new HashSet<PhiUserLogin>();
            PhiUserRoles = new HashSet<PhiUserRole>();
            PhiUserStats = new HashSet<PhiUserStat>();
        }

        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ReminderQuestion { get; set; }
        public string? ReminderAnswer { get; set; }
        public string? PasswordSalt { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public byte[]? LastLoggedDate { get; set; }
        public byte[]? DateTimeCreated { get; set; }
        public byte[] Active { get; set; }
        public long? UserType { get; set; }
        public long? UserNameFormat { get; set; }
        public long? PasswordFormat { get; set; }
        public byte[] EmailConfirmed { get; set; } = null!;
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public byte[] PhoneNumberConfirmed { get; set; } = null!;
        public byte[] TwoFactorEnabled { get; set; } = null!;
        public byte[]? LockoutEndDateUtc { get; set; }
        public byte[] LockoutEnabled { get; set; } = null!;
        public long AccessFailedCount { get; set; }

        public virtual PhiUserProfile PhiUserProfile { get; set; } = null!;
        public virtual ICollection<BlogComment> BlogComments { get; set; }
        public virtual ICollection<BlogLike> BlogLikes { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<PhiUserAttribute> PhiUserAttributes { get; set; }
        public virtual ICollection<PhiUserClaim> PhiUserClaims { get; set; }
        public virtual ICollection<PhiUserLogin> PhiUserLogins { get; set; }
        public virtual ICollection<PhiUserRole> PhiUserRoles { get; set; }
        public virtual ICollection<PhiUserStat> PhiUserStats { get; set; }
    }
}
