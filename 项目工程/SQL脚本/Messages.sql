USE [sherry]
GO
/****** 对象:  Table [dbo].[Messages]    脚本日期: 12/17/2009 09:05:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Messages](
	[messageID] [int] IDENTITY(1,1) NOT NULL,
	[topic] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[messages] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[reply] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
PRIMARY KEY CLUSTERED 
(
	[messageID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF