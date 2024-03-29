SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[category]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[category](
	[ID] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
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
	[goodsNum] [varchar](30) NOT NULL CONSTRAINT [UQ__goodsInfo__goodsNum] UNIQUE,
	[goodsName] [varchar](50) NOT NULL CONSTRAINT [UQ__goodsInfo__goodsName] UNIQUE,
	[goodsDescribe] [varchar](500) NOT NULL,
	[goodsCategory] [int] NOT NULL,
	[goodsImg] [varchar](100) NOT NULL CONSTRAINT [DF__goodsInfo__goods__0F975522]  DEFAULT ((0)),
	[goodsPrice] [money] NOT NULL,
    [goodsAddTime] [datetime] NOT NULL,
	[goodsValidity] [datetime] NOT NULL,
	[goodsAvailable] [bit] NOT NULL CONSTRAINT [DF__goodsInfo__goods__117F9D94]  DEFAULT ((0)),
	[goodsStorage] [int] NOT NULL CONSTRAINT [DF__goodsInfo__goods__1367E606]  DEFAULT ((0)),
	[goodsVolume] [int] NOT NULL CONSTRAINT [DF__goodsInfo__goods__145C0A3F]  DEFAULT ((0)),
	[goodsSpecialOffer] [int] NOT NULL,
	[goodsGC] [int] NOT NULL CONSTRAINT [DF__goodsInfo__goods__15502E78]  DEFAULT ((0)),
	[goodsMC] [int] NOT NULL CONSTRAINT [DF__goodsInfo__goods__164452B1]  DEFAULT ((0)),
	[goodsBC] [int] NOT NULL CONSTRAINT [DF__goodsInfo__goods__173876EA]  DEFAULT ((0)),
 CONSTRAINT [PK__goodsInfo__0EA330E9] PRIMARY KEY CLUSTERED 
(
	[goodsID] ASC
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
