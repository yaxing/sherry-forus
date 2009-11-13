create database sherry;
go

use sherry;

create table userInfo(
	userID int identity(1,1) primary key not null,
	userName varchar(15) not null,
	userPwd varchar(50) not null,
	userRealName varchar(50) not null,
	emailAdd varchar(50) not null,
	postAdd varchar(200) not null,
	phoneNum varchar(20) not null,
	userScore int not null default(0),
	userLv int not null default(0),
	constraint CK_userLv check (userLv=1 or userLv=0),
	userBirth datetime default(1979-01-01),
	userGender int default(0),
	constraint CK_userGender check (userGender=0 or userGender=1 or userGender=2),
	userAge int default(30),
	IDCardNum varchar(18) default(000000000000000000),
	activeState bit not null default(1),
	regTime datetime not null default(getdate()),
)

--adminInfo
create table adminInfo(
	adminID int not null primary key identity(1,1),
	adminName varchar(15) not null,
	adminPwd varchar(50) not null,
	adminRealName varchar(50)  not null,
	emailAdd varchar(50) not null,
	phoneMun varchar(20) not null,
	adminLv int default(0) not null,
	constraint CK_adminLv check (adminLv=0 or adminLv=1 or adminLv=2),
	activeState bit default(1) not null,
	constraint CK_activeState_2 check (activeState=0 or activeState=1),
	regTime datetime default(getdate()) not null,

)



create table goodsInfo(
	goodsID int not null primary key identity(1,1),
	goodsNum varchar(30) not null,
	goodsName varchar(50) not null,
	goodsDescribe varchar(500),
	goosCategory int not null,
	goodsImg varchar(100) not null default (0),
	goodsPrice money,
	goodsValidity datetime not null default(dateadd(year,3,getdate())),
	goodsAvailable bit not null default(0),
	constraint CK_goodsAvailable check (goodsAvailable=0 or goodsAvailable=1),
	goodsStorage int not null default(0),
	goodsVolume int not null default(0),
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
	userID int not null foreign key references userInfo(userID),
	postAdd varchar(200) not null,-- default ( select postAdd from userInfo where userInfo.userID=new.userID),
	userRealName varchar(50) not null,
	phoneNum varchar(20) not null, --default (select * from )...
	orderTime datetime not null,
	orderPrice money not null,
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

--customService 
--getdate() 函数返回的是什么？

create table customService(
	CSID int primary key identity(1,1),
	userID int not null foreign key references userInfo(userID),
	comment varchar(500) not null,
	time datetime not null default(getdate()),
	status int not null default (0),
	constraint CK_customservice_status check (status=0 or status=1 or status=2),
	reply varchar(500) 
)



--vote info
create table voteInfo(
	voteID int primary key identity(1,1),
	adminID int not null foreign key references adminInfo(adminID),
	voteTitle varchar(50) not null,
	createTime Datetime not null default(getdate()),
	voteStatus int not null default(1),
	constraint CK_voteinfo_votestatus check (votestatus=0 or votestatus=1),
)


--voteItem
create table voteItem(
	voteItemID int primary key identity(1,1),
	voteID int not null foreign key references voteInfo(voteID),
	voteItemText varchar(50) not null,
	selectCount int not null default(0),
)

create table voteUser(
	voteUserID int primary key identity(1,1),
	voteID int foreign key references voteInfo(voteID),
	userID int not null foreign key references userInfo(userID),
	voteItemID int not null foreign key references voteItem(voteItemID),
)

create table shopInfo(
	shopID int not null primary key identity(1,1),
	shopName varchar(50) not null,
	shopAdd varchar(100) not null,
	shopDescribe varchar(500),
)


create table workerInfo(
	workerID int identity(1,1),
	workerNum int,
	Constraint PK_workerinfo primary key(workerID,workerNum),
	shopID int not null foreign key references shopInfo(shopID),
	workerName varchar(15) not null,
	workerPwd varchar(50) not null,
	workerRealName varchar(50) not null,
	manageID int not null,   --即为负责人的工号，若本人为负责人则为0
	emailAdd varchar(50) not null,
	phoneNum varchar(20) not null,
	workerLv int not null ,
	constraint CK_workerInfo_workerLv check (workerLv=0 or workerLv=1),
	userBirth datetime default(1979-01-01),
	userGender int default (0) ,
	constraint CK_workerinfo_userGender check(usergender=0 or usergender=1 or usergender=2),
	userAge int default 30,
	constraint CK_workerinfo check(userAge>=0 and userAge<=100),
	workerstate int default(0) not null ,
	constraint CK_workerinfo_workerstate check(workerstate=0 or workerstate=1),
	activestate bit default(1) not null,
	regTime datetime not null
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

/*
create table mainStat(
mainStatID int primary key identity(1,1),
time datetime 
)
*/


go