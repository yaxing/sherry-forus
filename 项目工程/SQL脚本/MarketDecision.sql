use sherry;

/*MemberReport*/
--totalMoney from 
Select sum(orderPrice) from mainorderInfo where userID 
in (select userID from userInfo where userage > =@startingAge and userage<= @endingAge);



/*GoodsSalesReport,by Category */

-- totalMoney from online sales by Category ����mainOrder�����û����¼��������
--TABLES: mainOrderInfo(userID,mainOrderID)*subOrderInfo(mainOrderID,goodsID)
--*goodsInfo(goodsID,goodsCategory)*category(category);
select sum(mainorderInfo.orderPrice) as 'total' from mainOrderInfo 
where orderTime>= @startingDate and ordertime<= @endingDate and mainOrderID 
in (Select mainOrderID from mainOrderInfo where mainOrderID 
in (select mainOrderID from subOrderInfo where goodsID 
in (Select goodsID from goodsInfo where goodsCategory 
in (select ID from category where name=@categoryName))));

--totalMoney from phone sales by Category ����mainUpload����м�¼����������
--TABLES: mainupload(mainuploadID)*subupload(mainuploadID,goodsID)
--*goodsInfo(goodsID,goodsCategory)*category(category);
select sum(totalValue) as 'total' from MainUpload 
where soldType=@soldType and sellTime >= @startingDate and sellTime<=@endingDate and mainUploadID
in (select mainUploadID from subUpload where goodsID 
in (Select goodsID from goodsInfo where goodsCategory 
in (select ID from category where name=@categoryName)));


--totalMoney from shop sales by Category
--TABLES: SAME WITH ABOVE
select sum(totalValue) as 'total' from MainUpload 
where soldType=@soldType and sellTime >= @startingDate and sellTime<=@endingDate and mainUploadID
in (select mainUploadID from subUpload where goodsID 
in (Select goodsID from goodsInfo where goodsCategory 
in (select ID from category where name=@categoryName)));


/*MemberSalesReport, by Age Group*/

--totalMoney from online sales by Age Group
--TABLES: mainOrderInfo(orderPrice)::  
--mainOrderInfo(userID,mainOrderID)*userInfo(userID,userAge)
select sum(orderPrice)  as 'total' from mainOrderInfo
where orderTime>= @startingDate and ordertime<= @endingDate and userID
in (select userID from userInfo where userAge>=@startingDate and userAge<=@endingDate );

--totalMoney from shop sales by Age Group
--TABLES: mainUpload(totalValue):: mainupload(userID)*userInfo(userID,userAge)

select sum(totalValue) as 'total' from mainUpload 
where sellTime>= @startingDate and sellTime<= @endingDate 
and age>=@startingAge and age<=@endingAge;


/*ûȷ���绰�������Ǹ���˵�� phone sales by Age group ûʵ��*/



