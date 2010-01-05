create database sherry;
go

use sherry;

--以下为创建数据库表

create table userInfo(
	userID uniqueidentifier primary key not null,
	userRealName varchar(50) not null,
	postAdd varchar(200) not null,
	postNum varcahr(6) not null,
	phoneNum varchar(20) not null,
	userScore int not null default(0),
	userLv int not null default(0),
	constraint CK_userLv check (userLv=1 or userLv=0),
	userBirth datetime default(1979-01-01),
	userGender int default(0),
	constraint CK_userGender check (userGender=0 or userGender=1 or userGender=2),
	userAge int default(30),
	IDCardNum varchar(18) default(000000000000000000),
)

--adminInfo
create table adminInfo(
	adminID uniqueidentifier not null primary key identity(1,1),
	adminRealName varchar(50)  not null,
	emailAdd varchar(50) not null,
	phoneMun varchar(20) not null,
	adminLv int default(0) not null,
	constraint CK_adminLv check (adminLv=0 or adminLv=1 or adminLv=2),
)



create table goodsInfo(
	goodsID int not null primary key identity(1,1),
	goodsNum varchar(30) not null,
	goodsName varchar(50) not null,
	goodsDescribe varchar(500),
	goosCategory int not null,
	goodsImg varchar(100) not null default (0),
	goodsPrice money not null,
	goodsAddTime datetime not null default(getdate()),
	goodsValidity datetime not null default(dateadd(year,3,getdate())),
	goodsAvailable bit not null default(0),
	constraint CK_goodsAvailable check (goodsAvailable=0 or goodsAvailable=1),
	goodsStorage int not null default(0),
	goodsVolume int not null default(0),
	goodsSpecialOffer int not null default(0),
	constraint CK_goodsSpecialOffer check (goodsSpecialOffer=0 or goodsSpecialOffer=1),
	goodsGC int not null default(0),
	goodsMC int not null default(0),
	goodsBC int not null default(0),
)


--goodsComment

create table goodsComment(
	commentID int not null primary key identity(1,1),
	goodsID int not null foreign key references goodsInfo(goodsID),
	userID int not null foreign key references userInfo(userID),
	goodsComment varchar(500) not null,
	commentLevel int not null,
	constraint CK_commentLevel check (commentLevel=0 or commentLevel=1 or commentLevel=2),

)



--main order info 有问题 就是那些default不知该怎么写表达式
create table mainOrderInfo(
	mainOrderID int not null primary key identity(1,1),
	userID uniqueidentifier not null foreign key references userInfo(userID),
	postAdd varchar(200) not null,-- ??default ( select postAdd from userInfo where userInfo.userID=new.userID),
	userRealName varchar(50) not null,
	phoneNum varchar(20) not null, --?? default (select * from )...
	province varchar(20) not null,
	invoiceHead varchar(100),
	invoiceContent varchar(500),	
	orderTime datetime not null,
	orderPrice money not null,
	orderState int not null,
	Constraint CK_orderState check (orderState=0 or orderState=1 or orderState=2 orderState=3 orderState=4),
	isPaid int not null default(0),
	Constraint CK_isPaid check (isPaid=0 or isPaid=1),
)

--suborder info
create table subOrderInfo(
	subOrderID int primary key identity(1,1),
	mainOrderID int not null foreign key references mainOrderInfo(mainOrderID),
	goodsID int not null foreign key references goodsInfo(goodsID),
	goddsName varchar(50) not null,
	goodsPrice money not null,
	goodsNum int not null
)

create table logisticsInfo(
	logisticsID int not null primary key identity(1,1),
	workerID uniqueidentifier not null,
	mainOrderID int foreign key references mainOrderInfo(mainOrderID),
	logisticsType int not null default (0),
	constraint CK_logisticsType check (logisticsType=0 or logisticsType=1 or logisticsType=2 ),
)

--customService 
/*
create table customService(
	CSID int primary key identity(1,1),
	userID int not null foreign key references userInfo(userID),
	comment varchar(500) not null,
	time datetime not null default(getdate()),
	status int not null default (0),
	constraint CK_customservice_status check (status=0 or status=1 or status=2),
	reply varchar(500) 
)

*/

--message表 客户留言 
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


--MainPoll表 投票主表
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

--SubPoll表 投票辅表
CREATE TABLE [dbo].[SubPoll](
	[subPollID] [int] IDENTITY(1,1) NOT NULL ,
	[mainPollID] [int] NOT NULL references MainPoll(mainPollID),
	[description] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
	[num] [int] NOT NULL,
	[color] [varchar](255) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_SubPoll] PRIMARY KEY CLUSTERED 
(
	[subPollID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]



/*
create table voteUser(
	voteUserID int primary key identity(1,1),
	voteID int foreign key references voteInfo(voteID),
	userID int not null foreign key references userInfo(userID),
	voteItemID int not null foreign key references voteItem(voteItemID),
)

*/

create table shopInfo(
	shopID int not null primary key identity(1,1),
	shopName varchar(100) not null,
	shopAdd varchar(100) not null,
	shopDescribe varchar(500),
	area varchar (50) not null,
)


create table workerInfo(
	workerID uniqueidentifier,
	workerNum int,
	Constraint PK_workerinfo primary key(workerID,workerNum),
	shopID int not null foreign key references shopInfo(shopID),
	workerRealName varchar(50) not null,
	manageID int not null,   --即为负责人的工号，若本人为负责人则为0
	emailAdd varchar(50) not null,
	phoneNum varchar(20) not null,
	workerLv int not null default(0),
	constraint CK_workerInfo_workerLv check (workerLv=0 or workerLv=1),
	userBirth datetime default(1979-01-01),
	userGender int default (0) ,
	constraint CK_workerinfo_userGender check(usergender=0 or usergender=1 or usergender=2),
	userAge int default 30,
	constraint CK_workerinfo check(userAge>=0 and userAge<=100),
	workerstate int default(0) not null ,
	constraint CK_workerinfo_workerstate check(workerstate=0 or workerstate=1),
)

create table mainStat(
	mainStatID int primary key identity(1,1),
	time datetime default (getdate()) not null,
	value int not null,
	gender int default(0) not null,
	constraint CK_mainStat_gender check(gender=0 or gender=1 or gender=2),
	age int not null,
	constraint CK_mainStat_age check (age<=100 and age>=0),
	shopID int not null foreign key references shopinfo(shopID),
	province int not null ,
	soldType int not null,
	constraint CK_mainStat_soldType check(soldType=0 or soldType=1 or soldType=2),

)

create table subStat(
	subStatID int not null primary key identity(1,1),
	mainStadID int not null foreign key references mainstat(mainstatID),
	goodsID int not null foreign key references goodsInfo(goodsID),
	goodsName varchar(100) not null,
	number int not null,
	price money not null,
	value money not null,
)

create table areaInfo(
	areaID int not null primary key identity(1,1),
	area varchar(50) not null,
	province varchar(50) not null,
)

create table category(
	ID int primary key not null identity(1,1),
	name varchar(50) not null,
)

go

--以下是插入必要数据

--插入category表的数据
INSERT INTO [sherry].[dbo].[category]
           (ID, name)
     VALUES
           (1, '面部护理')

INSERT INTO [sherry].[dbo].[category]
           (ID, name)
     VALUES
           (2, '手部护理')

INSERT INTO [sherry].[dbo].[category]
           (ID, name)
     VALUES
           (3, '身体护理')

INSERT INTO [sherry].[dbo].[category]
           (ID, name)
     VALUES
           (4, '秀发护理')

INSERT INTO [sherry].[dbo].[category]
           (ID, name)
     VALUES
           (5, '眼部护理')

INSERT INTO [sherry].[dbo].[category]
           (ID, name)
     VALUES
           (6, '颈部护理')

INSERT INTO [sherry].[dbo].[category]
           (ID, name)
     VALUES
           (7, '唇部')
INSERT INTO [sherry].[dbo].[category]
           (ID, name)
     VALUES
           (8, '香水')
INSERT INTO [sherry].[dbo].[category]
           (ID, name)
     VALUES
           (9, '彩妆')
INSERT INTO [sherry].[dbo].[category]
           (ID, name)
     VALUES
           (10, '香精/精油/花水')

INSERT INTO [sherry].[dbo].[category]
           (ID, name)
     VALUES
           (11, '瘦身美体')

