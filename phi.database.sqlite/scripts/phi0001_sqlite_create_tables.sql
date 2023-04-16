-- COPYRIGHT 2022 Anton Yarkov
-- Email: anton.yarkov@gmail.com
-- Skype: optiklab
-----------------------------------------------------------------

CREATE TABLE [EmailAccount] (
    [Id]                    INTEGER PRIMARY KEY,
    [Email]                 NVARCHAR (255) NOT NULL,
    [DisplayName]           NVARCHAR (255) NOT NULL,
    [Host]                  NVARCHAR (255) NOT NULL,
    [Port]                  INTEGER        NOT NULL,
    [Username]              NVARCHAR (255) NOT NULL,
    [Password]              NVARCHAR (255) NOT NULL,
    [EnableSsl]             BIT            NOT NULL,
    [UseDefaultCredentials] BIT            NOT NULL
);

CREATE TABLE [PhiUsers] (
    [Id]                   INTEGER PRIMARY KEY AUTOINCREMENT, -- Restricted use of deleted User Ids (avoid security flaw), adds performance hit :(
    [UserName]             NVARCHAR (256)       NULL,
    [Password]             NVARCHAR (550)       NULL,
    [ReminderQuestion]     NVARCHAR (255)       NULL,
    [ReminderAnswer]       NVARCHAR (255)       NULL,
    [PasswordSalt]         NVARCHAR (255)       NULL,
    [PhoneNumber]          NVARCHAR (50)        NULL,
    [FirstName]            NVARCHAR (550)       NULL,
    [LastName]             NVARCHAR (550)       NULL,
    [Email]                NVARCHAR (256)       NULL,
    [LastLoggedDate]       DATETIME             NULL,    -- TODO think about having 2 fields: TEXT and INTEGER (which is a real datatype in SQLite)
    [DateTimeCreated]      DATETIME DEFAULT CURRENT_TIMESTAMP NULL, 
    [Active]               BIT                  DEFAULT 0       NOT NULL,
    [UserType]             INTEGER              NULL,
    [UserNameFormat]       INTEGER              NULL,
    [PasswordFormat]       INTEGER              NULL,
    [EmailConfirmed]       BIT      DEFAULT 0   NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)       NULL,
    [SecurityStamp]        NVARCHAR (MAX)       NULL,
    [PhoneNumberConfirmed] BIT      DEFAULT 0   NOT NULL,
    [TwoFactorEnabled]     BIT      DEFAULT 0   NOT NULL,
    [LockoutEndDateUtc]    DATETIME             NULL,
    [LockoutEnabled]       BIT      DEFAULT 0   NOT NULL,
    [AccessFailedCount]    INTEGER  DEFAULT 0   NOT NULL
);

-- ONE TO MANY
CREATE TABLE [PhiUserAttribute] (
    [Id]        INTEGER PRIMARY KEY,
    [Name]      NVARCHAR (255)  NULL,
    [Value]     NVARCHAR (255)  NULL,
    [PhiUserId] INTEGER         NOT NULL    REFERENCES [PhiUsers] ([Id]) ON DELETE CASCADE
);

-- ONE TO MANY
CREATE TABLE [PhiUserClaims] (
    [Id]                INTEGER PRIMARY KEY,
    [ClaimType]         NVARCHAR (MAX)  NULL,
    [ClaimValue]        NVARCHAR (MAX)  NULL,
    [PhiUserId]         INTEGER         NOT NULL    REFERENCES [PhiUsers] ([Id]) ON DELETE CASCADE
);


-- ONE TO MANY
CREATE TABLE [PhiUserLogins] (
    [Id]                INTEGER PRIMARY KEY,
    [ProviderKey]       NVARCHAR (128)  NOT NULL,
    [PhiUserId]         INTEGER         NOT NULL    REFERENCES [PhiUsers] ([Id]) ON DELETE CASCADE
);

-- ONE TO ONE
CREATE TABLE [PhiUserProfile] (
    [PhiUserId]                        INTEGER         NOT NULL        PRIMARY KEY      REFERENCES [PhiUsers] ON DELETE CASCADE,
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
    [NotifyMeAboutSuddenWeatherEvents] BIT             NOT NULL
);

-- ONE TO MANY
CREATE TABLE [Roles] ( 
    [Id]     INTEGER            PRIMARY KEY,
    [Name]   NVARCHAR (256)     NULL ,
    [Active] BIT                DEFAULT 0   NOT NULL
);

-- MANY TO MANY
CREATE TABLE [PhiUserRoles] (
    [PhiUserId]         INTEGER     NOT NULL    REFERENCES [PhiUsers] ([Id]) ON DELETE CASCADE,
    [RoleId]            INTEGER     NOT NULL    REFERENCES [Roles] ([Id]),
    [DateTimeCreated]   DATETIME    DEFAULT     CURRENT_TIMESTAMP NULL, 
    PRIMARY KEY ([PhiUserId] ASC, [RoleId] ASC)
);

CREATE TABLE [PhiUserStat] (
    [Id]          INTEGER PRIMARY KEY,
    [PhiUserId]   INTEGER         NOT NULL    REFERENCES [PhiUsers] ([Id]) ON DELETE CASCADE,
    [Browser]     NVARCHAR (255)  NULL,
    [IPAddress]   NVARCHAR (255)  NULL,
    [UserName]    NVARCHAR (255)  NULL,
    [UserEmail]   NVARCHAR (255)  NULL,
    [DateTime]    DATETIME        NULL,
    [UrlReferrer] NVARCHAR (1000) NULL,
    [Action]      NVARCHAR (255)  NULL,
    [ActionPage]  NVARCHAR (255)  NULL
);

CREATE TABLE [QueuedEmail] (
    [Id]                INTEGER         PRIMARY KEY,
    [Priority]          INTEGER         NOT NULL,
    [FromAddress]       NVARCHAR (255)  NOT NULL,
    [FromName]          NVARCHAR (255)  NOT NULL,
    [ToAddress]         NVARCHAR (255)  NOT NULL,
    [ToName]            NVARCHAR (255)  NOT NULL,
    [CC]                NVARCHAR (1000) NOT NULL,
    [Bcc]               NVARCHAR (1000) NOT NULL,
    [EmailSubject]      NVARCHAR (255)  NOT NULL,
    [Body]              NVARCHAR (1000) NOT NULL,
    [DateTimeCreated]   DATETIME        DEFAULT CURRENT_TIMESTAMP NULL, 
    [SentTries]         INTEGER         NOT NULL,
    [SentUTC]           DATETIME        NULL,
    [EmailAccountId]    INTEGER         NOT NULL    REFERENCES [EmailAccount] ([Id])
);

CREATE TABLE [Setting] (
    [Id]    INTEGER         PRIMARY KEY,
    [Name]  NVARCHAR (255)  NOT NULL,
    [Value] NVARCHAR (255)  NOT NULL
);


CREATE TABLE [Language] (
    [Id]        INTEGER         PRIMARY KEY,
    [Code]      NVARCHAR (10)   NULL,
    [Fullname]  NVARCHAR (255)  NULL
);

CREATE TABLE [Blog] (
    [Id]                INTEGER         PRIMARY KEY,
    [Theme]             NVARCHAR (1000) NULL,
    [Article]           NVARCHAR (MAX)  NULL,
    [Header]            NVARCHAR (1000) NULL,
    [Rating]            INTEGER         NULL,
    [Tags]              NVARCHAR (1000) NULL,
    [PublishDate]       DATETIME        NULL,
    [DateTimeCreated]   DATETIME DEFAULT CURRENT_TIMESTAMP NULL, 
    [UniqueId]          NVARCHAR (100)  NULL, -- Generated by application (to be used for url's, for example)
    [SourceUrl]         NVARCHAR (500)  NULL,
    [LanguageId]        INTEGER         NOT NULL    REFERENCES [Language] ([Id]),
    [ProviderName]      NVARCHAR (500)  NULL
);

CREATE TABLE [BlogComments] (
    [Id]                INTEGER         PRIMARY KEY,
    [BlogId]            INTEGER         NOT NULL    REFERENCES [Blog] ([Id])     ON DELETE CASCADE,
    [PhiUserId]         INTEGER         NOT NULL    REFERENCES [PhiUsers] ([Id]) ON DELETE CASCADE,
    [Text]              NVARCHAR (4000) NULL,    
    [DateTimeCreated]   DATETIME        DEFAULT CURRENT_TIMESTAMP NULL
);

CREATE TABLE [BlogLikes] (
    [Id]                INTEGER     PRIMARY KEY,
    [BlogId]            INTEGER     NOT NULL    REFERENCES [Blog] ([Id])     ON DELETE CASCADE,
    [PhiUserId]         INTEGER     NOT NULL    REFERENCES [PhiUsers] ([Id]) ON DELETE CASCADE,
    [IsWish]            BIT         NULL,
    [IsLike]            BIT         NULL,
    [DateTimeCreated]   DATETIME    DEFAULT CURRENT_TIMESTAMP NULL
);

CREATE TABLE [Images] (
    [Id]          INTEGER           PRIMARY KEY,
    [PhiUserId]   INTEGER           NULL    REFERENCES [PhiUsers] ([Id]) ON DELETE CASCADE,
    [ImageUrl]    NVARCHAR (255)    NULL,
    [Height]      INTEGER           NULL,
    [Width]       INTEGER           NULL
);

CREATE TABLE [MessageTemplate] (
    [Id]                INTEGER         PRIMARY KEY,
    [Name]              NVARCHAR (255)  NOT NULL,
    [BccEmailAddresses] NVARCHAR (255)  NOT NULL,
    [Subject]           NVARCHAR (255)  NOT NULL,
    [Body]              NVARCHAR (4000) NOT NULL,
    [IsActive]          BIT             DEFAULT 0   NOT NULL,
    [EmailAccountId]    INTEGER         NOT NULL    REFERENCES [EmailAccount] ([Id])
);

CREATE TABLE [GoodThoughts] ( 
    [Id]                INTEGER         PRIMARY KEY,
    [Description]       NVARCHAR (4000) NULL,
    [Author]            NVARCHAR (255)  NULL,    
    [LanguageId]        INTEGER         NOT NULL    REFERENCES [Language] ([Id])
);
