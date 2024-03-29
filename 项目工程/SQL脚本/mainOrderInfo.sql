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
