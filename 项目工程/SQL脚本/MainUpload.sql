USE [sherry]
GO
/****** 对象:  Table [dbo].[MainUpload]    脚本日期: 12/24/2009 09:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MainUpload](
	[mainUploadID] [int] IDENTITY(1,1) NOT NULL,
	[sellTime] [datetime] NULL,
	[totalValue] [float] NULL,
	[gender] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[age] [int] NULL,
	[shopID] [int] NULL,
	[province] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[soldType] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF