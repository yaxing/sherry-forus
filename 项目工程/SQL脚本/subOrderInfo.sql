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
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__subOrderI__goods__22AA2996]') AND parent_object_id = OBJECT_ID(N'[dbo].[subOrderInfo]'))
ALTER TABLE [dbo].[subOrderInfo]  WITH CHECK ADD FOREIGN KEY([goodsID])
REFERENCES [dbo].[goodsInfo] ([goodsID])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__subOrderI__mainO__21B6055D]') AND parent_object_id = OBJECT_ID(N'[dbo].[subOrderInfo]'))
ALTER TABLE [dbo].[subOrderInfo]  WITH CHECK ADD  CONSTRAINT [FK__subOrderI__mainO__21B6055D] FOREIGN KEY([mainOrderID])
REFERENCES [dbo].[mainOrderInfo] ([mainOrderID])
