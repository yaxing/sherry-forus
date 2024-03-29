SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[adminInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[adminInfo](
	[adminID] [int] IDENTITY(1,1) NOT NULL,
	[adminName] [varchar](15) NOT NULL,
	[adminPwd] [varchar](50) NOT NULL,
	[adminRealName] [varchar](50) NOT NULL,
	[emailAdd] [varchar](50) NOT NULL,
	[phoneMun] [varchar](20) NOT NULL,
	[adminLv] [int] NOT NULL DEFAULT ((0)),
	[activeState] [bit] NOT NULL DEFAULT ((1)),
	[regTime] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[adminID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[goodsInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[goodsInfo](
	[goodsID] [int] IDENTITY(1,1) NOT NULL,
	[goodsNum] [varchar](30) NOT NULL,
	[goodsName] [varchar](50) NOT NULL,
	[goodsDescribe] [varchar](500) NULL,
	[goodsCategory] [int] NOT NULL,
	[goodsImg] [varchar](100) NOT NULL DEFAULT ((0)),
	[goodsPrice] [money] NULL,
	[goodsValidity] [datetime] NOT NULL DEFAULT (dateadd(year,(3),getdate())),
	[goodsAvailable] [bit] NOT NULL DEFAULT ((0)),
	[goodsStorage] [int] NOT NULL DEFAULT ((0)),
	[goodsVolume] [int] NOT NULL DEFAULT ((0)),
	[goodsGC] [int] NOT NULL DEFAULT ((0)),
	[goodsMC] [int] NOT NULL DEFAULT ((0)),
	[goodsBC] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[goodsID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[customService]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[customService](
	[CSID] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NOT NULL,
	[comment] [varchar](500) NOT NULL,
	[time] [datetime] NOT NULL DEFAULT (getdate()),
	[status] [int] NOT NULL DEFAULT ((0)),
	[reply] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[CSID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_Events]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_WebEvent_Events](
	[EventId] [char](32) NOT NULL,
	[EventTimeUtc] [datetime] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[EventType] [nvarchar](256) NOT NULL,
	[EventSequence] [decimal](19, 0) NOT NULL,
	[EventOccurrence] [decimal](19, 0) NOT NULL,
	[EventCode] [int] NOT NULL,
	[EventDetailCode] [int] NOT NULL,
	[Message] [nvarchar](1024) NULL,
	[ApplicationPath] [nvarchar](256) NULL,
	[ApplicationVirtualPath] [nvarchar](256) NULL,
	[MachineName] [nvarchar](256) NOT NULL,
	[RequestUrl] [nvarchar](1024) NULL,
	[ExceptionType] [nvarchar](256) NULL,
	[Details] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[shopInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[shopInfo](
	[shopID] [int] IDENTITY(1,1) NOT NULL,
	[shopName] [varchar](50) NOT NULL,
	[shopAdd] [varchar](100) NOT NULL,
	[shopDescribe] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[shopID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[userInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[userInfo](
	[userID] [uniqueidentifier] NOT NULL,
	[userRealName] [varchar](50) NOT NULL,
	[postAdd] [varchar](200) NOT NULL,
	[postNum] [varchar](8) NOT NULL,
	[phoneNum] [varchar](20) NOT NULL,
	[userScore] [int] NOT NULL CONSTRAINT [DF__userInfo__userSc__7D78A4E7]  DEFAULT ((0)),
	[userLv] [int] NOT NULL CONSTRAINT [DF__userInfo__userLv__7E6CC920]  DEFAULT ((0)),
	[userBirth] [datetime] NULL CONSTRAINT [DF__userInfo__userBi__00551192]  DEFAULT (((1979)-(1))-(1)),
	[userGender] [int] NULL CONSTRAINT [DF__userInfo__userGe__014935CB]  DEFAULT ((0)),
	[userAge] [int] NULL CONSTRAINT [DF__userInfo__userAg__03317E3D]  DEFAULT ((30)),
	[IDCardNum] [varchar](18) NULL CONSTRAINT [DF__userInfo__IDCard__0425A276]  DEFAULT ((0.0)),
 CONSTRAINT [PK_userInfo] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_SchemaVersions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_SchemaVersions](
	[Feature] [nvarchar](128) NOT NULL,
	[CompatibleSchemaVersion] [nvarchar](128) NOT NULL,
	[IsCurrentVersion] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Feature] ASC,
	[CompatibleSchemaVersion] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Applications]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Applications](
	[ApplicationName] [nvarchar](256) NOT NULL,
	[LoweredApplicationName] [nvarchar](256) NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Description] [nvarchar](256) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[ApplicationId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[LoweredApplicationName] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ApplicationName] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mainOrderInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[mainOrderInfo](
	[mainOrderID] [int] IDENTITY(1,1) NOT NULL,
	[userID] [uniqueidentifier] NOT NULL,
	[postAdd] [varchar](200) NOT NULL,
	[postNum] [varchar](20) NOT NULL,
	[userRealName] [varchar](50) NOT NULL,
	[phoneNum] [varchar](20) NOT NULL,
	[province] [varchar](20) NOT NULL,
	[invoiceHead] [nvarchar](50) NULL,
	[invoiceContent] [nvarchar](50) NULL,
	[orderTime] [datetime] NOT NULL,
	[orderPrice] [money] NOT NULL,
	[orderState] [int] NOT NULL,
 CONSTRAINT [PK__mainOrderInfo__1DE57479] PRIMARY KEY CLUSTERED 
(
	[mainOrderID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_UsersInRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[voteInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[voteInfo](
	[voteID] [int] IDENTITY(1,1) NOT NULL,
	[adminID] [int] NOT NULL,
	[voteTitle] [varchar](50) NOT NULL,
	[createTime] [datetime] NOT NULL DEFAULT (getdate()),
	[voteStatus] [int] NOT NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[voteID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[goodsComment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[goodsComment](
	[commentID] [int] IDENTITY(1,1) NOT NULL,
	[goodsID] [int] NOT NULL,
	[userID] [int] NOT NULL,
	[goodsComment] [varchar](500) NOT NULL,
	[commentLevel] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[commentID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subOrderInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[subOrderInfo](
	[subOrderID] [int] IDENTITY(1,1) NOT NULL,
	[mainOrderID] [int] NOT NULL,
	[goodsID] [int] NOT NULL,
	[goodsName] [varchar](50) NOT NULL,
	[goodsPrice] [money] NOT NULL,
	[goodsNum] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[subOrderID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[subStat]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[subStat](
	[subStatID] [int] IDENTITY(1,1) NOT NULL,
	[mainStadID] [int] NOT NULL,
	[goodsID] [int] NOT NULL,
	[goodsName] [varchar](100) NOT NULL,
	[number] [int] NOT NULL,
	[price] [money] NOT NULL,
	[value] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[subStatID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_PersonalizationPerUser](
	[Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[PathId] [uniqueidentifier] NULL,
	[UserId] [uniqueidentifier] NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_PersonalizationAllUsers](
	[PathId] [uniqueidentifier] NOT NULL,
	[PageSettings] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PathId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[voteItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[voteItem](
	[voteItemID] [int] IDENTITY(1,1) NOT NULL,
	[voteID] [int] NOT NULL,
	[voteItemText] [varchar](50) NOT NULL,
	[selectCount] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[voteItemID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[voteUser]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[voteUser](
	[voteUserID] [int] IDENTITY(1,1) NOT NULL,
	[voteID] [int] NULL,
	[userID] [int] NOT NULL,
	[voteItemID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[voteUserID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[workerInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[workerInfo](
	[workerID] [int] IDENTITY(1,1) NOT NULL,
	[workerNum] [int] NOT NULL,
	[shopID] [int] NOT NULL,
	[workerName] [varchar](15) NOT NULL,
	[workerPwd] [varchar](50) NOT NULL,
	[workerRealName] [varchar](50) NOT NULL,
	[manageID] [int] NOT NULL,
	[emailAdd] [varchar](50) NOT NULL,
	[phoneNum] [varchar](20) NOT NULL,
	[workerLv] [int] NOT NULL,
	[userBirth] [datetime] NULL DEFAULT (((1979)-(1))-(1)),
	[userGender] [int] NULL DEFAULT ((0)),
	[userAge] [int] NULL DEFAULT ((30)),
	[workerstate] [int] NOT NULL DEFAULT ((0)),
	[activestate] [bit] NOT NULL DEFAULT ((1)),
	[regTime] [datetime] NOT NULL,
 CONSTRAINT [PK_workerinfo] PRIMARY KEY CLUSTERED 
(
	[workerID] ASC,
	[workerNum] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[mainStat]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[mainStat](
	[mainStatID] [int] IDENTITY(1,1) NOT NULL,
	[time] [datetime] NOT NULL DEFAULT (getdate()),
	[value] [int] NOT NULL,
	[gender] [int] NOT NULL DEFAULT ((0)),
	[age] [int] NOT NULL,
	[shopID] [int] NOT NULL,
	[province] [int] NOT NULL,
	[soldType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mainStatID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Membership](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL DEFAULT ((0)),
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[MobilePIN] [nvarchar](16) NULL,
	[Email] [nvarchar](256) NULL,
	[LoweredEmail] [nvarchar](256) NULL,
	[PasswordQuestion] [nvarchar](256) NULL,
	[PasswordAnswer] [nvarchar](128) NULL,
	[IsApproved] [bit] NOT NULL,
	[IsLockedOut] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastPasswordChangedDate] [datetime] NOT NULL,
	[LastLockoutDate] [datetime] NOT NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
	[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
	[FailedPasswordAnswerAttemptWindowStart] [datetime] NOT NULL,
	[Comment] [ntext] NULL,
PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Users](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[UserName] [nvarchar](256) NOT NULL,
	[LoweredUserName] [nvarchar](256) NOT NULL,
	[MobileAlias] [nvarchar](16) NULL DEFAULT (NULL),
	[IsAnonymous] [bit] NOT NULL DEFAULT ((0)),
	[LastActivityDate] [datetime] NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Roles](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[RoleName] [nvarchar](256) NOT NULL,
	[LoweredRoleName] [nvarchar](256) NOT NULL,
	[Description] [nvarchar](256) NULL,
PRIMARY KEY NONCLUSTERED 
(
	[RoleId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Paths](
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[PathId] [uniqueidentifier] NOT NULL DEFAULT (newid()),
	[Path] [nvarchar](256) NOT NULL,
	[LoweredPath] [nvarchar](256) NOT NULL,
PRIMARY KEY NONCLUSTERED 
(
	[PathId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[aspnet_Profile](
	[UserId] [uniqueidentifier] NOT NULL,
	[PropertyNames] [ntext] NOT NULL,
	[PropertyValuesString] [ntext] NOT NULL,
	[PropertyValuesBinary] [image] NOT NULL,
	[LastUpdatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_activeState_2]') AND parent_object_id = OBJECT_ID(N'[dbo].[adminInfo]'))
ALTER TABLE [dbo].[adminInfo]  WITH CHECK ADD  CONSTRAINT [CK_activeState_2] CHECK  (([activeState]=(0) OR [activeState]=(1)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_adminLv]') AND parent_object_id = OBJECT_ID(N'[dbo].[adminInfo]'))
ALTER TABLE [dbo].[adminInfo]  WITH CHECK ADD  CONSTRAINT [CK_adminLv] CHECK  (([adminLv]=(0) OR [adminLv]=(1) OR [adminLv]=(2)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_goodsAvailable]') AND parent_object_id = OBJECT_ID(N'[dbo].[goodsInfo]'))
ALTER TABLE [dbo].[goodsInfo]  WITH CHECK ADD  CONSTRAINT [CK_goodsAvailable] CHECK  (([goodsAvailable]=(0) OR [goodsAvailable]=(1)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_customservice_status]') AND parent_object_id = OBJECT_ID(N'[dbo].[customService]'))
ALTER TABLE [dbo].[customService]  WITH CHECK ADD  CONSTRAINT [CK_customservice_status] CHECK  (([status]=(0) OR [status]=(1) OR [status]=(2)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_userGender]') AND parent_object_id = OBJECT_ID(N'[dbo].[userInfo]'))
ALTER TABLE [dbo].[userInfo]  WITH CHECK ADD  CONSTRAINT [CK_userGender] CHECK  (([userGender]=(0) OR [userGender]=(1) OR [userGender]=(2)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_userLv]') AND parent_object_id = OBJECT_ID(N'[dbo].[userInfo]'))
ALTER TABLE [dbo].[userInfo]  WITH CHECK ADD  CONSTRAINT [CK_userLv] CHECK  (([userLv]=(1) OR [userLv]=(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Us__RoleI__0C85DE4D]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]'))
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[aspnet_Roles] ([RoleId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Us__UserI__0B91BA14]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]'))
ALTER TABLE [dbo].[aspnet_UsersInRoles]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__voteInfo__adminI__2B3F6F97]') AND parent_object_id = OBJECT_ID(N'[dbo].[voteInfo]'))
ALTER TABLE [dbo].[voteInfo]  WITH CHECK ADD FOREIGN KEY([adminID])
REFERENCES [dbo].[adminInfo] ([adminID])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_voteinfo_votestatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[voteInfo]'))
ALTER TABLE [dbo].[voteInfo]  WITH CHECK ADD  CONSTRAINT [CK_voteinfo_votestatus] CHECK  (([votestatus]=(0) OR [votestatus]=(1)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__goodsComm__goods__1A14E395]') AND parent_object_id = OBJECT_ID(N'[dbo].[goodsComment]'))
ALTER TABLE [dbo].[goodsComment]  WITH CHECK ADD FOREIGN KEY([goodsID])
REFERENCES [dbo].[goodsInfo] ([goodsID])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_commentLevel]') AND parent_object_id = OBJECT_ID(N'[dbo].[goodsComment]'))
ALTER TABLE [dbo].[goodsComment]  WITH CHECK ADD  CONSTRAINT [CK_commentLevel] CHECK  (([commentLevel]=(0) OR [commentLevel]=(1) OR [commentLevel]=(2)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__subOrderI__goods__22AA2996]') AND parent_object_id = OBJECT_ID(N'[dbo].[subOrderInfo]'))
ALTER TABLE [dbo].[subOrderInfo]  WITH CHECK ADD FOREIGN KEY([goodsID])
REFERENCES [dbo].[goodsInfo] ([goodsID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__subOrderI__mainO__21B6055D]') AND parent_object_id = OBJECT_ID(N'[dbo].[subOrderInfo]'))
ALTER TABLE [dbo].[subOrderInfo]  WITH CHECK ADD  CONSTRAINT [FK__subOrderI__mainO__21B6055D] FOREIGN KEY([mainOrderID])
REFERENCES [dbo].[mainOrderInfo] ([mainOrderID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__subStat__goodsID__4F7CD00D]') AND parent_object_id = OBJECT_ID(N'[dbo].[subStat]'))
ALTER TABLE [dbo].[subStat]  WITH CHECK ADD FOREIGN KEY([goodsID])
REFERENCES [dbo].[goodsInfo] ([goodsID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__subStat__mainSta__4E88ABD4]') AND parent_object_id = OBJECT_ID(N'[dbo].[subStat]'))
ALTER TABLE [dbo].[subStat]  WITH CHECK ADD FOREIGN KEY([mainStadID])
REFERENCES [dbo].[mainStat] ([mainStatID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pe__PathI__245D67DE]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]'))
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pe__UserI__25518C17]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]'))
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pe__PathI__208CD6FA]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]'))
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers]  WITH CHECK ADD FOREIGN KEY([PathId])
REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__voteItem__voteID__30F848ED]') AND parent_object_id = OBJECT_ID(N'[dbo].[voteItem]'))
ALTER TABLE [dbo].[voteItem]  WITH CHECK ADD FOREIGN KEY([voteID])
REFERENCES [dbo].[voteInfo] ([voteID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__voteUser__voteID__34C8D9D1]') AND parent_object_id = OBJECT_ID(N'[dbo].[voteUser]'))
ALTER TABLE [dbo].[voteUser]  WITH CHECK ADD FOREIGN KEY([voteID])
REFERENCES [dbo].[voteInfo] ([voteID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__voteUser__voteIt__36B12243]') AND parent_object_id = OBJECT_ID(N'[dbo].[voteUser]'))
ALTER TABLE [dbo].[voteUser]  WITH CHECK ADD FOREIGN KEY([voteItemID])
REFERENCES [dbo].[voteItem] ([voteItemID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__workerInf__shopI__3B75D760]') AND parent_object_id = OBJECT_ID(N'[dbo].[workerInfo]'))
ALTER TABLE [dbo].[workerInfo]  WITH CHECK ADD FOREIGN KEY([shopID])
REFERENCES [dbo].[shopInfo] ([shopID])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_workerinfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[workerInfo]'))
ALTER TABLE [dbo].[workerInfo]  WITH CHECK ADD  CONSTRAINT [CK_workerinfo] CHECK  (([userAge]>=(0) AND [userAge]<=(100)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_workerinfo_userGender]') AND parent_object_id = OBJECT_ID(N'[dbo].[workerInfo]'))
ALTER TABLE [dbo].[workerInfo]  WITH CHECK ADD  CONSTRAINT [CK_workerinfo_userGender] CHECK  (([usergender]=(0) OR [usergender]=(1) OR [usergender]=(2)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_workerInfo_workerLv]') AND parent_object_id = OBJECT_ID(N'[dbo].[workerInfo]'))
ALTER TABLE [dbo].[workerInfo]  WITH CHECK ADD  CONSTRAINT [CK_workerInfo_workerLv] CHECK  (([workerLv]=(0) OR [workerLv]=(1)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_workerinfo_workerstate]') AND parent_object_id = OBJECT_ID(N'[dbo].[workerInfo]'))
ALTER TABLE [dbo].[workerInfo]  WITH CHECK ADD  CONSTRAINT [CK_workerinfo_workerstate] CHECK  (([workerstate]=(0) OR [workerstate]=(1)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__mainStat__shopID__4AB81AF0]') AND parent_object_id = OBJECT_ID(N'[dbo].[mainStat]'))
ALTER TABLE [dbo].[mainStat]  WITH CHECK ADD FOREIGN KEY([shopID])
REFERENCES [dbo].[shopInfo] ([shopID])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_mainStat_age]') AND parent_object_id = OBJECT_ID(N'[dbo].[mainStat]'))
ALTER TABLE [dbo].[mainStat]  WITH CHECK ADD  CONSTRAINT [CK_mainStat_age] CHECK  (([age]<=(100) AND [age]>=(0)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_mainStat_gender]') AND parent_object_id = OBJECT_ID(N'[dbo].[mainStat]'))
ALTER TABLE [dbo].[mainStat]  WITH CHECK ADD  CONSTRAINT [CK_mainStat_gender] CHECK  (([gender]=(0) OR [gender]=(1) OR [gender]=(2)))
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_mainStat_soldType]') AND parent_object_id = OBJECT_ID(N'[dbo].[mainStat]'))
ALTER TABLE [dbo].[mainStat]  WITH CHECK ADD  CONSTRAINT [CK_mainStat_soldType] CHECK  (([soldType]=(0) OR [soldType]=(1) OR [soldType]=(2)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Me__Appli__693CA210]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]'))
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Me__UserI__6A30C649]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]'))
ALTER TABLE [dbo].[aspnet_Membership]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Us__Appli__59063A47]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Users]'))
ALTER TABLE [dbo].[aspnet_Users]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Ro__Appli__07C12930]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]'))
ALTER TABLE [dbo].[aspnet_Roles]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pa__Appli__1AD3FDA4]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]'))
ALTER TABLE [dbo].[aspnet_Paths]  WITH CHECK ADD FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__aspnet_Pr__UserI__7E37BEF6]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Profile]'))
ALTER TABLE [dbo].[aspnet_Profile]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])
