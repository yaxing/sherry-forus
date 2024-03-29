USE [sherry]
GO
/****** 对象:  Table [dbo].[SubPoll]    脚本日期: 12/17/2009 09:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubPoll](
	[subPollID] [int] IDENTITY(1,1) NOT NULL,
	[mainPollID] [int] NOT NULL,
	[description] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[num] [int] NOT NULL,
	[color] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_SubPoll] PRIMARY KEY CLUSTERED 
(
	[subPollID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF