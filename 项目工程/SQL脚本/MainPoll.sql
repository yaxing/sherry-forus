USE [sherry]
GO
/****** 对象:  Table [dbo].[MainPoll]    脚本日期: 12/17/2009 09:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MainPoll](
	[mainPollID] [int] IDENTITY(1,1) NOT NULL,
	[topic] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[selectNum] [int] NULL,
	[singleMode] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[colMode] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
PRIMARY KEY CLUSTERED 
(
	[mainPollID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF