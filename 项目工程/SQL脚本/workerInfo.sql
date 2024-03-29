if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[workerInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[workerInfo]
GO

CREATE TABLE [dbo].[workerInfo] (
	[workerID] [uniqueidentifier] NOT NULL ,
	[workerNum] [int] NOT NULL ,
	[shopID] [int] NOT NULL ,
	[workerRealName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[manageID] [uniqueidentifier] NOT NULL ,
	[emailAdd] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[phoneNum] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[workerLv] [int] NOT NULL ,
	[workerState] [int] NOT NULL 
) ON [PRIMARY]
GO

