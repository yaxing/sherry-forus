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
	[isPaid] [int] NOT NULL CONSTRAINT [DF_mainOrderInfo_isPaid]  DEFAULT ((0)),
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[goodsInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[goodsInfo](
	[goodsID] [int] IDENTITY(1,1) NOT NULL,
	[goodsNum] [varchar](30) NOT NULL,
	[goodsName] [varchar](50) NOT NULL,
	[goodsDescribe] [varchar](500) NOT NULL,
	[goodsCategory] [int] NOT NULL,
	[goodsImg] [varchar](100) NOT NULL CONSTRAINT [DF__goodsInfo__goods__0F975522]  DEFAULT ((0)),
	[goodsPrice] [money] NOT NULL,
	[goodsValidity] [datetime] NOT NULL CONSTRAINT [DF__goodsInfo__goods__108B795B]  DEFAULT (dateadd(year,(3),getdate())),
	[goodsAvailable] [bit] NOT NULL CONSTRAINT [DF__goodsInfo__goods__117F9D94]  DEFAULT ((0)),
	[goodsStorage] [int] NOT NULL CONSTRAINT [DF__goodsInfo__goods__1367E606]  DEFAULT ((0)),
	[goodsVolume] [int] NOT NULL CONSTRAINT [DF__goodsInfo__goods__145C0A3F]  DEFAULT ((0)),
	[goodsSpecialOffer] [int] NOT NULL,
	[goodsGC] [int] NOT NULL CONSTRAINT [DF__goodsInfo__goods__15502E78]  DEFAULT ((0)),
	[goodsMC] [int] NOT NULL CONSTRAINT [DF__goodsInfo__goods__164452B1]  DEFAULT ((0)),
	[goodsBC] [int] NOT NULL CONSTRAINT [DF__goodsInfo__goods__173876EA]  DEFAULT ((0)),
	[goodsAddTime] [datetime] NOT NULL,
 CONSTRAINT [PK__goodsInfo__0EA330E9] PRIMARY KEY CLUSTERED 
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
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_goodsInfo_category]') AND parent_object_id = OBJECT_ID(N'[dbo].[goodsInfo]'))
ALTER TABLE [dbo].[goodsInfo]  WITH CHECK ADD  CONSTRAINT [FK_goodsInfo_category] FOREIGN KEY([goodsCategory])
REFERENCES [dbo].[category] ([ID])
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_goodsAvailable]') AND parent_object_id = OBJECT_ID(N'[dbo].[goodsInfo]'))
ALTER TABLE [dbo].[goodsInfo]  WITH CHECK ADD  CONSTRAINT [CK_goodsAvailable] CHECK  (([goodsAvailable]=(0) OR [goodsAvailable]=(1)))
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__subOrderI__goods__22AA2996]') AND parent_object_id = OBJECT_ID(N'[dbo].[subOrderInfo]'))
ALTER TABLE [dbo].[subOrderInfo]  WITH CHECK ADD  CONSTRAINT [FK__subOrderI__goods__22AA2996] FOREIGN KEY([goodsID])
REFERENCES [dbo].[goodsInfo] ([goodsID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__subOrderI__mainO__21B6055D]') AND parent_object_id = OBJECT_ID(N'[dbo].[subOrderInfo]'))
ALTER TABLE [dbo].[subOrderInfo]  WITH CHECK ADD  CONSTRAINT [FK__subOrderI__mainO__21B6055D] FOREIGN KEY([mainOrderID])
REFERENCES [dbo].[mainOrderInfo] ([mainOrderID])
