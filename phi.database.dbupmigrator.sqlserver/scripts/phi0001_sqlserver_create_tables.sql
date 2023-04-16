-- COPYRIGHT 2022 Anton Yarkov
-- Email: anton.yarkov@gmail.com
-- Skype: optiklab
-----------------------------------------------------------------


PRINT N'Creating Table [dbo].[EmailAccount]...';
GO

CREATE TABLE [dbo].[EmailAccount] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [Email]                 NVARCHAR (255) NOT NULL,
    [DisplayName]           NVARCHAR (255) NOT NULL,
    [Host]                  NVARCHAR (255) NOT NULL,
    [Port]                  INT            NOT NULL,
    [Username]              NVARCHAR (255) NOT NULL,
    [Password]              NVARCHAR (255) NOT NULL,
    [EnableSsl]             BIT            NOT NULL,
    [UseDefaultCredentials] BIT            NOT NULL
);
GO
ALTER TABLE EmailAccount
	ADD CONSTRAINT XPKEmailAccount PRIMARY KEY  CLUSTERED (Id ASC)
go

PRINT N'Creating Table [dbo].[PhiUsers]...';
GO
CREATE TABLE [dbo].[PhiUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [UserName]             NVARCHAR (256) NULL,
    [Password]             NVARCHAR (550) NULL,
    [ReminderQuestion]     NVARCHAR (255) NULL,
    [ReminderAnswer]       NVARCHAR (255) NULL,
    [PasswordSalt]         NVARCHAR (255) NULL,
    [PhoneNumber]          NVARCHAR (50)  NULL,
    [FirstName]            NVARCHAR (550) NULL,
    [LastName]             NVARCHAR (550) NULL,
    [Email]                NVARCHAR (256) NULL,
    [LastLoggedDate]       DATETIME       NULL,
    [DateTimeCreated]     DATETIME        NULL,
    [Active]               BIT            DEFAULT 0     NOT NULL,
    [UserType]             INT            NULL,
    [UserNameFormat]       INT            NULL,
    [PasswordFormat]       INT            NULL,
    [EmailConfirmed]       BIT            DEFAULT 0  NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            DEFAULT 0  NOT NULL,
    [TwoFactorEnabled]     BIT            DEFAULT 0  NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            DEFAULT 0  NOT NULL,
    [AccessFailedCount]    INT            DEFAULT 0  NOT NULL,
    CONSTRAINT [XPKPhiUser] PRIMARY KEY CLUSTERED ([Id] ASC)
);

PRINT N'Creating Table [dbo].[PhiUserAttribute]...';
GO
CREATE TABLE [dbo].[PhiUserAttribute] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (255) NULL,
    [Value]     NVARCHAR (255) NULL,
    [PhiUserId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [XPKPhiUserAttribute] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
ALTER TABLE [dbo].[PhiUserAttribute]
    ADD CONSTRAINT [R_234] FOREIGN KEY ([PhiUserId]) REFERENCES [dbo].[PhiUsers] ([Id]);
GO

PRINT N'Creating Table [dbo].[PhiUserClaims]...';
GO
CREATE TABLE [dbo].[PhiUserClaims] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    [PhiUserId]  NVARCHAR (128) NOT NULL,
    CONSTRAINT [XPKUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
ALTER TABLE [dbo].[PhiUserClaims]
    ADD CONSTRAINT [R_237] FOREIGN KEY ([PhiUserId]) REFERENCES [dbo].[PhiUsers] ([Id]);
GO

PRINT N'Creating Table [dbo].[PhiUserLogins]...';
GO
CREATE TABLE [dbo].[PhiUserLogins] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [PhiUserId]     NVARCHAR (128) NOT NULL,
    CONSTRAINT [XPKUserLogins] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
ALTER TABLE [dbo].[PhiUserLogins]
    ADD CONSTRAINT [R_236] FOREIGN KEY ([PhiUserId]) REFERENCES [dbo].[PhiUsers] ([Id]);
GO

PRINT N'Creating Table [dbo].[PhiUserProfile]...';
GO
-- ONE TO ONE
CREATE TABLE [dbo].[PhiUserProfile] (
    [PhiUserId]                        NVARCHAR (128)  NOT NULL,
    [Gender]                           BIT             NULL,
    [AvatarPictureUrl]                 NVARCHAR (255)  NULL,
    [IsCompany]                        BIT             NOT NULL,
    [MainCompanyUrl]                   NVARCHAR (255)  NULL,
    [CompanyName]                      NVARCHAR (255)  NULL,
    [CompanyCEO]                       NVARCHAR (255)  NULL,
    [CompanyEmail]                     NVARCHAR (255)  NULL,
    [CompanyPhone]                     NVARCHAR (50)   NULL,
    [CompanyFax]                       NVARCHAR (50)   NULL,
    [AdditionalInfo]                   NVARCHAR (2000) NULL,
    [SellCompanyUrl]                   NVARCHAR (255)  NULL,
    [NotifyMeAboutSuddenWeatherEvents] BIT             NOT NULL,
    CONSTRAINT [XPKPhiUserProfile] PRIMARY KEY CLUSTERED ([PhiUserId] ASC)
);
GO
ALTER TABLE [dbo].[PhiUserProfile]
    ADD CONSTRAINT [R_240] FOREIGN KEY ([PhiUserId]) REFERENCES [dbo].[PhiUsers] ([Id]) ON DELETE CASCADE;
GO

PRINT N'Creating Table [dbo].[Roles]...';
GO
-- ONE TO MANY
CREATE TABLE [dbo].[Roles] ( 
    [Id]      INT             IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (256)  NULL,
    [Active]  BIT             DEFAULT 0     NOT NULL
)
go
ALTER TABLE [dbo].[Roles]
  ADD CONSTRAINT [XPKRoles] PRIMARY KEY  CLUSTERED (Id ASC)
go

PRINT N'Creating Table [dbo].[PhiUserRoles]...';
GO
-- MANY TO MANY
CREATE TABLE [dbo].[PhiUserRoles] (
    [PhiUserId]         NVARCHAR (128) NOT NULL,
    [RoleId]            INT            NOT NULL,
    [DateTimeCreated]   DATETIME       NULL,
    CONSTRAINT [XPKUserRoles] PRIMARY KEY CLUSTERED ([PhiUserId] ASC, [RoleId] ASC)
);
GO
ALTER TABLE [dbo].[PhiUserRoles]
    ADD CONSTRAINT [R_238] FOREIGN KEY ([PhiUserId]) REFERENCES [dbo].[PhiUsers] ([Id]) ON DELETE CASCADE;
GO
ALTER TABLE [dbo].[PhiUserRoles]
    ADD CONSTRAINT [R_239] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]);
GO

PRINT N'Creating Table [dbo].[PhiUserStat]...';
GO
CREATE TABLE [dbo].[PhiUserStat] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [PhiUserId]   NVARCHAR (128)  NOT NULL,
    [Browser]     NVARCHAR (255)  NULL,
    [IPAddress]   NVARCHAR (255)  NULL,
    [UserName]    NVARCHAR (255)  NULL,
    [UserEmail]   NVARCHAR (255)  NULL,
    [DateTime]    DATETIME        NULL,
    [UrlReferrer] NVARCHAR (1000) NULL,
    [Action]      NVARCHAR (255)  NULL,
    [ActionPage]  NVARCHAR (255)  NULL,
    CONSTRAINT [XPKPhiUserStat] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
ALTER TABLE [dbo].[PhiUserStat]
    ADD CONSTRAINT [R_241] FOREIGN KEY ([PhiUserId]) REFERENCES [dbo].[PhiUsers] ([Id]) ON DELETE CASCADE;
GO

PRINT N'Creating Table [dbo].[QueuedEmail]...';
GO
CREATE TABLE [dbo].[QueuedEmail] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Priority]          INT             NOT NULL,
    [FromAddress]       NVARCHAR (255)  NOT NULL,
    [FromName]          NVARCHAR (255)  NOT NULL,
    [ToAddress]         NVARCHAR (255)  NOT NULL,
    [ToName]            NVARCHAR (255)  NOT NULL,
    [CC]                NVARCHAR (1000) NOT NULL,
    [Bcc]               NVARCHAR (1000) NOT NULL,
    [EmailSubject]      NVARCHAR (255)  NOT NULL,
    [Body]              NVARCHAR (1000) NOT NULL,
    [DateTimeCreated]  DATETIME        NULL,
    [SentTries]         INT             NOT NULL,
    [SentUTC]           DATETIME        NULL,
    [EmailAccountId]    INT             NOT NULL,
    CONSTRAINT [XPKQueuedEmail] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
ALTER TABLE [dbo].[QueuedEmail]
    ADD CONSTRAINT [R_162] FOREIGN KEY ([EmailAccountId]) REFERENCES [dbo].[EmailAccount] ([Id]);
GO

PRINT N'Creating Table [dbo].[Setting]...';
GO
CREATE TABLE [dbo].[Setting] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (255) NOT NULL,
    [Value] NVARCHAR (255) NOT NULL,
    CONSTRAINT [XPK_Settings] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO


PRINT N'Creating Table [dbo].[Language]...';
GO
CREATE TABLE [dbo].[Language] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Code]     NVARCHAR (10)  NULL,
    [Fullname] NVARCHAR (255) NULL,
    CONSTRAINT [XPKLanguage] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO


PRINT N'Creating Table [dbo].[Blog]...';
GO
CREATE TABLE [dbo].[Blog] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Theme]             NVARCHAR (1000) NULL,
    [Article]           NVARCHAR (MAX)  NULL,
    [Header]            NVARCHAR (1000) NULL,
    [Rating]            INT             NULL,
    [Tags]              NVARCHAR (1000) NULL,
    [PublishDate]       DATETIME        NULL,
    [DateTimeCreated]   DATETIME        NULL,
    [UniqueId]          NVARCHAR (100)  NULL,
    [SourceUrl]         NVARCHAR (500)  NULL,
    [LanguageId]        INT             NOT NULL,
    [ProviderName]      NVARCHAR (500)  NULL,
    CONSTRAINT [XPKBlog] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
ALTER TABLE [dbo].[Blog]
    ADD CONSTRAINT [R_170] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language] ([Id]);
GO


PRINT N'Creating Table [dbo].[BlogComments]...';
GO
CREATE TABLE [dbo].[BlogComments] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [BlogId]            INT             NOT NULL,
    [PhiUserId]         NVARCHAR (128)  NOT NULL,
    [Text]              NVARCHAR (4000) NULL,
    [DateTimeCreated]   DATETIME        NULL,
    CONSTRAINT [XPKBlogComments] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
ALTER TABLE [dbo].[BlogComments]
    ADD CONSTRAINT [R_257] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blog] ([Id]) ON DELETE CASCADE;
GO
ALTER TABLE [dbo].[BlogComments]
    ADD CONSTRAINT [R_256] FOREIGN KEY ([PhiUserId]) REFERENCES [dbo].[PhiUsers] ([Id]) ON DELETE CASCADE;
GO

PRINT N'Creating Table [dbo].[BlogLikes]...';
GO
CREATE TABLE [dbo].[BlogLikes] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [BlogId]            INT            NOT NULL,
    [PhiUserId]         NVARCHAR (128) NOT NULL,
    [IsWish]            BIT            NULL,
    [IsLike]            BIT            NULL,
    [DateTimeCreated]   DATETIME       NULL,
    CONSTRAINT [XPKBlogLikes] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
ALTER TABLE [dbo].[BlogLikes]
    ADD CONSTRAINT [R_265] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blog] ([Id]) ON DELETE CASCADE;
GO
ALTER TABLE [dbo].[BlogLikes]
    ADD CONSTRAINT [R_266] FOREIGN KEY ([PhiUserId]) REFERENCES [dbo].[PhiUsers] ([Id]) ON DELETE CASCADE;
GO

PRINT N'Creating Table [dbo].[Images]...';
GO
CREATE TABLE [dbo].[Images] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [PhiUserId]   NVARCHAR (128) NULL,
    [ImageUrl]    NVARCHAR (255) NULL,
    [Height]      INT            NULL,
    [Width]       INT            NULL,
    CONSTRAINT [XPKImages] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
ALTER TABLE [dbo].[Images]
    ADD CONSTRAINT [R_224] FOREIGN KEY ([PhiUserId]) REFERENCES [dbo].[PhiUsers] ([Id]) ON DELETE CASCADE;
GO


PRINT N'Creating Table [dbo].[MessageTemplate]...';
GO
CREATE TABLE [dbo].[MessageTemplate] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (255)  NOT NULL,
    [BccEmailAddresses] NVARCHAR (255)  NOT NULL,
    [Subject]           NVARCHAR (255)  NOT NULL,
    [Body]              NVARCHAR (4000) NOT NULL,
    [IsActive]          BIT             DEFAULT 0       NOT NULL,
    [EmailAccountId]    INT             NOT NULL,
    CONSTRAINT [XPKMessageTemplate] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO
ALTER TABLE [dbo].[MessageTemplate]
    ADD CONSTRAINT [R_163] FOREIGN KEY ([EmailAccountId]) REFERENCES [dbo].[EmailAccount] ([Id]);
GO

CREATE TABLE [dbo].[GoodThoughts]
( 
    [Id]                   INT                  IDENTITY ( 1,1 )    NOT NULL,
    [Description]          nvarchar(4000)       NULL,
    [Author]               nvarchar(255)        NULL,
    [LanguageId]           INT                  NOT NULL,
    CONSTRAINT [XPKGoodThoughts] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO
ALTER TABLE [dbo].[GoodThoughts]
    ADD CONSTRAINT [R_168] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Language] ([Id]);
GO
