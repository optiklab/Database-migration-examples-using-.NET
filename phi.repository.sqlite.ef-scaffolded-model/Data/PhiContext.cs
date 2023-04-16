using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Phi.Repository.Sqlite.Models;

namespace Phi.Repository.Sqlite.Data
{
    public partial class PhiContext : DbContext
    {
        public PhiContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "phi.db");
        }

        public PhiContext(DbContextOptions<PhiContext> options)
            : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "phi.db");
        }
        
        public string DbPath { get; }
    
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<BlogComment> BlogComments { get; set; } = null!;
        public virtual DbSet<BlogLike> BlogLikes { get; set; } = null!;
        public virtual DbSet<EmailAccount> EmailAccounts { get; set; } = null!;
        public virtual DbSet<GoodThought> GoodThoughts { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;
        public virtual DbSet<MessageTemplate> MessageTemplates { get; set; } = null!;
        public virtual DbSet<PhiUser> PhiUsers { get; set; } = null!;
        public virtual DbSet<PhiUserAttribute> PhiUserAttributes { get; set; } = null!;
        public virtual DbSet<PhiUserClaim> PhiUserClaims { get; set; } = null!;
        public virtual DbSet<PhiUserLogin> PhiUserLogins { get; set; } = null!;
        public virtual DbSet<PhiUserProfile> PhiUserProfiles { get; set; } = null!;
        public virtual DbSet<PhiUserRole> PhiUserRoles { get; set; } = null!;
        public virtual DbSet<PhiUserStat> PhiUserStats { get; set; } = null!;
        public virtual DbSet<QueuedEmail> QueuedEmails { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SchemaVersion> SchemaVersions { get; set; } = null!;
        public virtual DbSet<Setting> Settings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=" + DbPath); //C:\\Users\\anton\\AppData\\Local\\phi.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");
                entity.Property(e => e.Id);
                entity.Property(e => e.Article).HasColumnType("text");
                entity.Property(e => e.DateTimeCreated)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.Header).HasColumnType("NVARCHAR (1000)");
                entity.Property(e => e.ProviderName).HasColumnType("NVARCHAR (500)");
                entity.Property(e => e.PublishDate).HasColumnType("DATETIME");
                entity.Property(e => e.SourceUrl).HasColumnType("NVARCHAR (500)");
                entity.Property(e => e.Tags).HasColumnType("NVARCHAR (1000)");
                entity.Property(e => e.Theme).HasColumnType("NVARCHAR (1000)");
                entity.Property(e => e.UniqueId).HasColumnType("NVARCHAR (100)");
                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<BlogComment>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.DateTimeCreated)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.Text).HasColumnType("NVARCHAR (4000)");
                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogComments)
                    .HasForeignKey(d => d.BlogId);
                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.BlogComments)
                    .HasForeignKey(d => d.PhiUserId);
            });

            modelBuilder.Entity<BlogLike>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.DateTimeCreated)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.IsLike).HasColumnType("BIT");
                entity.Property(e => e.IsWish).HasColumnType("BIT");
                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogLikes)
                    .HasForeignKey(d => d.BlogId);
                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.BlogLikes)
                    .HasForeignKey(d => d.PhiUserId);
            });

            modelBuilder.Entity<EmailAccount>(entity =>
            {
                entity.ToTable("EmailAccount");
                entity.Property(e => e.Id);
                entity.Property(e => e.DisplayName).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.Email).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.EnableSsl).HasColumnType("BIT");
                entity.Property(e => e.Host).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.Password).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.UseDefaultCredentials).HasColumnType("BIT");
                entity.Property(e => e.Username).HasColumnType("NVARCHAR (255)");
            });

            modelBuilder.Entity<GoodThought>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Author).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.Description).HasColumnType("NVARCHAR (4000)");
                entity.HasOne(d => d.Language)
                    .WithMany(p => p.GoodThoughts)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.ImageUrl).HasColumnType("NVARCHAR (255)");
                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.PhiUserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");
                entity.Property(e => e.Id);
                entity.Property(e => e.Code).HasColumnType("NVARCHAR (10)");
                entity.Property(e => e.Fullname).HasColumnType("NVARCHAR (255)");
            });

            modelBuilder.Entity<MessageTemplate>(entity =>
            {
                entity.ToTable("MessageTemplate");
                entity.Property(e => e.Id);
                entity.Property(e => e.BccEmailAddresses).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.Body).HasColumnType("NVARCHAR (4000)");
                entity.Property(e => e.IsActive)
                    .HasColumnType("BIT")
                    .HasDefaultValueSql("0");
                entity.Property(e => e.Name).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.Subject).HasColumnType("NVARCHAR (255)");
                entity.HasOne(d => d.EmailAccount)
                    .WithMany(p => p.MessageTemplates)
                    .HasForeignKey(d => d.EmailAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PhiUser>(entity =>
            {
                entity.Property(e => e.Active).HasColumnType("BIT");
                entity.Property(e => e.DateTimeCreated)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.Email).HasColumnType("NVARCHAR (256)");
                entity.Property(e => e.EmailConfirmed)
                    .HasColumnType("BIT")
                    .HasDefaultValueSql("0");
                entity.Property(e => e.FirstName).HasColumnType("NVARCHAR (550)");
                entity.Property(e => e.LastLoggedDate).HasColumnType("DATETIME");
                entity.Property(e => e.LastName).HasColumnType("NVARCHAR (550)");
                entity.Property(e => e.LockoutEnabled)
                    .HasColumnType("BIT")
                    .HasDefaultValueSql("0");
                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("DATETIME");
                entity.Property(e => e.Password).HasColumnType("NVARCHAR (550)");
                entity.Property(e => e.PasswordHash).HasColumnType("text");
                entity.Property(e => e.PasswordSalt).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.PhoneNumber).HasColumnType("NVARCHAR (50)");
                entity.Property(e => e.PhoneNumberConfirmed)
                    .HasColumnType("BIT")
                    .HasDefaultValueSql("0");
                entity.Property(e => e.ReminderAnswer).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.ReminderQuestion).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.SecurityStamp).HasColumnType("text");
                entity.Property(e => e.TwoFactorEnabled)
                    .HasColumnType("BIT")
                    .HasDefaultValueSql("0");
                entity.Property(e => e.UserName).HasColumnType("NVARCHAR (256)");
            });

            modelBuilder.Entity<PhiUserAttribute>(entity =>
            {
                entity.ToTable("PhiUserAttribute");
                entity.Property(e => e.Id);
                entity.Property(e => e.Name).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.Value).HasColumnType("NVARCHAR (255)");
                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.PhiUserAttributes)
                    .HasForeignKey(d => d.PhiUserId);
            });

            modelBuilder.Entity<PhiUserClaim>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.ClaimType).HasColumnType("text");
                entity.Property(e => e.ClaimValue).HasColumnType("text");
                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.PhiUserClaims)
                    .HasForeignKey(d => d.PhiUserId);
            });

            modelBuilder.Entity<PhiUserLogin>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.ProviderKey).HasColumnType("NVARCHAR (128)");
                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.PhiUserLogins)
                    .HasForeignKey(d => d.PhiUserId);
            });

            modelBuilder.Entity<PhiUserProfile>(entity =>
            {
                entity.HasKey(e => e.PhiUserId);
                entity.ToTable("PhiUserProfile");
                entity.Property(e => e.PhiUserId);
                entity.Property(e => e.AdditionalInfo).HasColumnType("NVARCHAR (2000)");
                entity.Property(e => e.AvatarPictureUrl).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.CompanyCeo)
                    .HasColumnType("NVARCHAR (255)")
                    .HasColumnName("CompanyCEO");
                entity.Property(e => e.CompanyEmail).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.CompanyFax).HasColumnType("NVARCHAR (50)");
                entity.Property(e => e.CompanyName).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.CompanyPhone).HasColumnType("NVARCHAR (50)");
                entity.Property(e => e.Gender).HasColumnType("BIT");
                entity.Property(e => e.IsCompany).HasColumnType("BIT");
                entity.Property(e => e.MainCompanyUrl).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.NotifyMeAboutSuddenWeatherEvents).HasColumnType("BIT");
                entity.Property(e => e.SellCompanyUrl).HasColumnType("NVARCHAR (255)");
                entity.HasOne(d => d.PhiUser)
                    .WithOne(p => p.PhiUserProfile)
                    .HasForeignKey<PhiUserProfile>(d => d.PhiUserId);
            });

            modelBuilder.Entity<PhiUserRole>(entity =>
            {
                entity.HasKey(e => new { e.PhiUserId, e.RoleId });
                entity.Property(e => e.DateTimeCreated)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.PhiUserRoles)
                    .HasForeignKey(d => d.PhiUserId);
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PhiUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PhiUserStat>(entity =>
            {
                entity.ToTable("PhiUserStat");
                entity.Property(e => e.Id);
                entity.Property(e => e.Action).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.ActionPage).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.Browser).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.DateTime).HasColumnType("DATETIME");
                entity.Property(e => e.Ipaddress)
                    .HasColumnType("NVARCHAR (255)")
                    .HasColumnName("IPAddress");
                entity.Property(e => e.UrlReferrer).HasColumnType("NVARCHAR (1000)");
                entity.Property(e => e.UserEmail).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.UserName).HasColumnType("NVARCHAR (255)");
                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.PhiUserStats)
                    .HasForeignKey(d => d.PhiUserId);
            });
            
            modelBuilder.Entity<QueuedEmail>(entity =>
            {
                entity.ToTable("QueuedEmail");
                entity.Property(e => e.Id);
                entity.Property(e => e.Bcc).HasColumnType("NVARCHAR (1000)");
                entity.Property(e => e.Body).HasColumnType("NVARCHAR (1000)");
                entity.Property(e => e.Cc)
                    .HasColumnType("NVARCHAR (1000)")
                    .HasColumnName("CC");
                entity.Property(e => e.DateTimeCreated)
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.EmailSubject).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.FromAddress).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.FromName).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.SentUtc)
                    .HasColumnType("DATETIME")
                    .HasColumnName("SentUTC");
                entity.Property(e => e.ToAddress).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.ToName).HasColumnType("NVARCHAR (255)");
                entity.HasOne(d => d.EmailAccount)
                    .WithMany(p => p.QueuedEmails)
                    .HasForeignKey(d => d.EmailAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Active).HasColumnType("BIT");
                entity.Property(e => e.Name).HasColumnType("NVARCHAR (256)");
            });

            modelBuilder.Entity<SchemaVersion>(entity =>
            {
                entity.Property(e => e.SchemaVersionId).HasColumnName("SchemaVersionID");
                entity.Property(e => e.Applied).HasColumnType("DATETIME");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting");
                entity.Property(e => e.Id);
                entity.Property(e => e.Name).HasColumnType("NVARCHAR (255)");
                entity.Property(e => e.Value).HasColumnType("NVARCHAR (255)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
