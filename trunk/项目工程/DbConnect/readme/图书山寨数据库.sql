CREATE DATABASE shanzhai
GO

use shanzhai


CREATE TABLE users (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	userName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	passWord varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	trueName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	address varchar (300) COLLATE Chinese_PRC_CI_AS NULL,
	postcode varchar (30) COLLATE Chinese_PRC_CI_AS NULL,
	tel varchar (30) COLLATE Chinese_PRC_CI_AS NULL ,
	email varchar (128) COLLATE Chinese_PRC_CI_AS NULL ,
	grade int DEFAULT 0,
	freeze int DEFAULT 0
)
GO

CREATE TABLE bookClass (
	ID int primary key IDENTITY (1, 1) NOT NULL,
	className varchar (128) NOT NULL,
	bookCount int DEFAULT 0
)
GO

CREATE TABLE bookInfo (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	ISBN varchar (45) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	classID int NULL,
	bookName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	publisher varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	author varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	introduce text COLLATE Chinese_PRC_CI_AS NULL ,
	price money NOT NULL ,
	pubDatetime datetime NULL,
	inDatetime datetime DEFAULT getdate(),
	coverPath varchar (128) COLLATE Chinese_PRC_CI_AS DEFAULT 'cover\default.gif' ,--图片路径
	available int DEFAULT 10 ,
	sale int DEFAULT 0 ,--销量
	good int DEFAULT 0 ,--好评
	middle int DEFAULT 0 ,
	bad int DEFAULT 0,
	discount float DEFAULT 1 ,
	constraint fk_classID foreign key(classID) references bookClass(ID)
)
GO

CREATE TABLE comment (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	bookID int NOT NULL,
	userID int NOT NULL,
	comment text COLLATE Chinese_PRC_CI_AS NULL ,
	commDatetime datetime DEFAULT getdate() ,
	score int DEFAULT 0 ,
	constraint fk_bookInfo foreign key(bookID) references bookInfo(ID),
	constraint fk_users foreign key(userID) references users(ID),
)
GO

CREATE TABLE admin (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	userName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	passWord varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	email varchar (128) NULL,
	level int DEFAULT 1
)
GO


CREATE TABLE orders (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	userID int NOT NULL,
	orderDatetime datetime DEFAULT getdate() ,
	amount money DEFAULT 0,
	trueName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	address varchar (300) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	postcode varchar (30) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	tel varchar (30) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	email varchar (128) NOT NULL ,
	dealMethod varchar (128) NOT NULL , --运送方式
	pay int DEFAULT 1, --是否付款
) 
GO

CREATE TABLE orderDetail (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	orderID int NOT NULL ,
	bookID int NOT NULL ,
	price money NOT NULL ,
	number int DEFAULT 1 ,
	discount float DEFAULT 1,
	constraint fk_orders foreign key(orderID) references orders(ID),
	constraint fk_bookDetail foreign key(bookID) references bookInfo(ID),
)
GO

CREATE TABLE bbs (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	content text COLLATE Chinese_PRC_CI_AS NOT NULL ,
	postTime datetime DEFAULT getdate() ,
)
GO


CREATE TABLE poll (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	theme varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	introduce text COLLATE Chinese_PRC_CI_AS NULL ,
	available int DEFAULT 0
)
GO

CREATE TABLE pollDetail (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	pollID int NOT NULL ,
	optionName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	counts int DEFAULT 0,
	constraint fk_poll foreign key(pollID) references poll(ID),
)
GO

go
CREATE TABLE orders_done (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	userID int NOT NULL,
	orderDatetime datetime DEFAULT getdate() ,
	amount money DEFAULT 0,
	trueName varchar (128) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	address varchar (300) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	postcode varchar (30) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	tel varchar (30) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	email varchar (128) NOT NULL ,
	dealMethod varchar (128) NOT NULL , --运送方式
	pay int DEFAULT 1, --是否付款
) 
GO

CREATE TABLE orderDetail_done (
	ID int primary key IDENTITY (1, 1) NOT NULL ,
	orderID int NOT NULL ,
	bookID int NOT NULL ,
	price money NOT NULL ,
	number int DEFAULT 1 ,
	discount float DEFAULT 1,
	constraint fk_orders_done foreign key(orderID) references orders_done(ID),
	constraint fk_bookDetail_done foreign key(bookID) references bookInfo(ID),
)
GO

CREATE VIEW v_orderManage
AS
SELECT orders.*,users.userName from orders
inner join users on orders.userID=users.ID
GO

create view v_orderManage_done
as
select orders_done.*,users.userName from orders_done
inner join users on orders_done.userID=users.ID
go

create view v_orderDetailManage
as
select orderDetail.*,
		bookInfo.ISBN,
		bookInfo.bookName,
		bookInfo.publisher
from orderDetail inner join bookInfo on bookInfo.ID=orderDetail.bookID
go

create view v_orderDetailManage_done
as
select orderDetail_done.*,
		bookInfo.ISBN,
		bookInfo.bookName,
		bookInfo.publisher
from orderDetail_done inner join bookInfo on bookInfo.ID=orderDetail_done.bookID
go

CREATE PROCEDURE pro_deal_orders
	@counter int=0,
	@orderID int =-1,
	@orderID_new int=-1
AS
BEGIN
	/*已完成订单的数量*/
	select @counter=count(*)  from orders where pay!=1
	/*从表orders,orderDetail中逐个取出，放入orders_done,orderDetail_done中*/
	while(@counter>0)
	begin
		select top 1 @orderID=ID from orders where pay!=1
		/*转移orders中的一个记录*/
		insert into orders_done select userID,orderdatetime,amount,trueName,address,postcode,tel,email,dealMethod,pay from orders where ID=@orderID
		/*转移相应的orderDetail中的记录*/
		select @orderID_new=max(ID) from orders_done
		insert into orderDetail_done select @orderID_new,bookID,price,number,discount from orderDetail where orderID=@orderID
		delete orderDetail where orderID=@orderID
		delete orders where ID=@orderID
		/*@counter 减 1*/
		set @counter=@counter-1
	end
END
GO