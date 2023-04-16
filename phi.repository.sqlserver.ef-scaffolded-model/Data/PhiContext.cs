using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Phi.Repository.SqlServer.Models;

namespace Phi.Repository.SqlServer.Data
{
    public partial class PhiContext : DbContext
    {
        public PhiContext()
        {
        }

        public PhiContext(DbContextOptions<PhiContext> options)
            : base(options)
        {
        }

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
                optionsBuilder.UseSqlServer("Server=ANTONPC; Database=Phi; Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.DateTimeCreated).HasColumnType("datetime");

                entity.Property(e => e.Header).HasMaxLength(1000);

                entity.Property(e => e.ProviderName).HasMaxLength(500);

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.SourceUrl).HasMaxLength(500);

                entity.Property(e => e.Tags).HasMaxLength(1000);

                entity.Property(e => e.Theme).HasMaxLength(1000);

                entity.Property(e => e.UniqueId).HasMaxLength(100);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_170");
            });

            modelBuilder.Entity<BlogComment>(entity =>
            {
                entity.Property(e => e.DateTimeCreated).HasColumnType("datetime");

                entity.Property(e => e.PhiUserId).HasMaxLength(128);

                entity.Property(e => e.Text).HasMaxLength(4000);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogComments)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("R_257");

                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.BlogComments)
                    .HasForeignKey(d => d.PhiUserId)
                    .HasConstraintName("R_256");
            });

            modelBuilder.Entity<BlogLike>(entity =>
            {
                entity.Property(e => e.DateTimeCreated).HasColumnType("datetime");

                entity.Property(e => e.PhiUserId).HasMaxLength(128);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.BlogLikes)
                    .HasForeignKey(d => d.BlogId)
                    .HasConstraintName("R_265");

                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.BlogLikes)
                    .HasForeignKey(d => d.PhiUserId)
                    .HasConstraintName("R_266");
            });

            modelBuilder.Entity<EmailAccount>(entity =>
            {
                entity.ToTable("EmailAccount");

                entity.Property(e => e.DisplayName).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Host).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(255);
            });

            modelBuilder.Entity<GoodThought>(entity =>
            {
                entity.Property(e => e.Author).HasMaxLength(255);

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.GoodThoughts)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_168");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageUrl).HasMaxLength(255);

                entity.Property(e => e.PhiUserId).HasMaxLength(128);

                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.PhiUserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("R_224");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.Fullname).HasMaxLength(255);
            });

            modelBuilder.Entity<MessageTemplate>(entity =>
            {
                entity.ToTable("MessageTemplate");

                entity.Property(e => e.BccEmailAddresses).HasMaxLength(255);

                entity.Property(e => e.Body).HasMaxLength(4000);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Subject).HasMaxLength(255);

                entity.HasOne(d => d.EmailAccount)
                    .WithMany(p => p.MessageTemplates)
                    .HasForeignKey(d => d.EmailAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_163");
            });

            modelBuilder.Entity<PhiUser>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.DateTimeCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(550);

                entity.Property(e => e.LastLoggedDate).HasColumnType("datetime");

                entity.Property(e => e.LastName).HasMaxLength(550);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(550);

                entity.Property(e => e.PasswordSalt).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.ReminderAnswer).HasMaxLength(255);

                entity.Property(e => e.ReminderQuestion).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<PhiUserAttribute>(entity =>
            {
                entity.ToTable("PhiUserAttribute");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PhiUserId).HasMaxLength(128);

                entity.Property(e => e.Value).HasMaxLength(255);

                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.PhiUserAttributes)
                    .HasForeignKey(d => d.PhiUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_234");
            });

            modelBuilder.Entity<PhiUserClaim>(entity =>
            {
                entity.Property(e => e.PhiUserId).HasMaxLength(128);

                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.PhiUserClaims)
                    .HasForeignKey(d => d.PhiUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_237");
            });

            modelBuilder.Entity<PhiUserLogin>(entity =>
            {
                entity.Property(e => e.PhiUserId).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.PhiUserLogins)
                    .HasForeignKey(d => d.PhiUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_236");
            });

            modelBuilder.Entity<PhiUserProfile>(entity =>
            {
                entity.HasKey(e => e.PhiUserId)
                    .HasName("XPKPhiUserProfile");

                entity.ToTable("PhiUserProfile");

                entity.Property(e => e.PhiUserId).HasMaxLength(128);

                entity.Property(e => e.AdditionalInfo).HasMaxLength(2000);

                entity.Property(e => e.AvatarPictureUrl).HasMaxLength(255);

                entity.Property(e => e.CompanyCeo)
                    .HasMaxLength(255)
                    .HasColumnName("CompanyCEO");

                entity.Property(e => e.CompanyEmail).HasMaxLength(255);

                entity.Property(e => e.CompanyFax).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.CompanyPhone).HasMaxLength(50);

                entity.Property(e => e.MainCompanyUrl).HasMaxLength(255);

                entity.Property(e => e.SellCompanyUrl).HasMaxLength(255);

                entity.HasOne(d => d.PhiUser)
                    .WithOne(p => p.PhiUserProfile)
                    .HasForeignKey<PhiUserProfile>(d => d.PhiUserId)
                    .HasConstraintName("R_240");
            });

            modelBuilder.Entity<PhiUserRole>(entity =>
            {
                entity.HasKey(e => new { e.PhiUserId, e.RoleId })
                    .HasName("XPKUserRoles");

                entity.Property(e => e.PhiUserId).HasMaxLength(128);

                entity.Property(e => e.DateTimeCreated).HasColumnType("datetime");

                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.PhiUserRoles)
                    .HasForeignKey(d => d.PhiUserId)
                    .HasConstraintName("R_238");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PhiUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_239");
            });

            modelBuilder.Entity<PhiUserStat>(entity =>
            {
                entity.ToTable("PhiUserStat");

                entity.Property(e => e.Action).HasMaxLength(255);

                entity.Property(e => e.ActionPage).HasMaxLength(255);

                entity.Property(e => e.Browser).HasMaxLength(255);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(255)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.PhiUserId).HasMaxLength(128);

                entity.Property(e => e.UrlReferrer).HasMaxLength(1000);

                entity.Property(e => e.UserEmail).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.HasOne(d => d.PhiUser)
                    .WithMany(p => p.PhiUserStats)
                    .HasForeignKey(d => d.PhiUserId)
                    .HasConstraintName("R_241");
            });

            modelBuilder.Entity<QueuedEmail>(entity =>
            {
                entity.ToTable("QueuedEmail");

                entity.Property(e => e.Bcc).HasMaxLength(1000);

                entity.Property(e => e.Body).HasMaxLength(1000);

                entity.Property(e => e.Cc)
                    .HasMaxLength(1000)
                    .HasColumnName("CC");

                entity.Property(e => e.DateTimeCreated).HasColumnType("datetime");

                entity.Property(e => e.EmailSubject).HasMaxLength(255);

                entity.Property(e => e.FromAddress).HasMaxLength(255);

                entity.Property(e => e.FromName).HasMaxLength(255);

                entity.Property(e => e.SentUtc)
                    .HasColumnType("datetime")
                    .HasColumnName("SentUTC");

                entity.Property(e => e.ToAddress).HasMaxLength(255);

                entity.Property(e => e.ToName).HasMaxLength(255);

                entity.HasOne(d => d.EmailAccount)
                    .WithMany(p => p.QueuedEmails)
                    .HasForeignKey(d => d.EmailAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_162");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<SchemaVersion>(entity =>
            {
                entity.Property(e => e.Applied).HasColumnType("datetime");

                entity.Property(e => e.ScriptName).HasMaxLength(255);
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Value).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
