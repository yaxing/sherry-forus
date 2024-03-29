USE [sherry]
GO
/****** 对象:  Table [dbo].[SubUpload]    脚本日期: 12/24/2009 09:27:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubUpload](
	[subUploadID] [int] IDENTITY(1,1) NOT NULL,
	[mainUploadID] [int] NULL,
	[goodsID] [int] NULL,
	[goodsName] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[number] [int] NULL,
	[price] [float] NULL,
	[totalValue] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF