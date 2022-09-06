
Create database bachelorNeer
use bachelorNeer
create table userinfo
(
u_ID int PRIMARY KEY Identity(1,1),
u_Name varchar(25),
u_Number varchar(15) unique,
u_Email varchar(30) unique,
u_Adress varchar(200),
u_NID varchar(25) unique,
u_Password varchar(25) check(len(u_Password)>5),
constraint u_Email check(u_Email like '%_@__%.__%'),
)

select * from userinfo
TRUNCATE TABLE userinfo

create table admininfo
(
o_ID int PRIMARY KEY Identity(1,1),
o_Name varchar(25),
o_Number varchar(15) unique,
o_Email varchar(25) unique,
o_Adress varchar(200),
o_NID varchar(25) unique,
o_Password varchar(25) check(len(o_Password)>5),
constraint o_Email check(o_Email like '%_@__%.__%'),
)
 
select * from admininfo

create table PropertyDetails
(
up_ID int PRIMARY KEY identity(1,1),
up_Name varchar(25),
up_Email varchar(50),
up_Number varchar(25),
constraint up_Email check(up_Email like '%_@__%.__%'),
up_Type varchar(25),
up_Proaddress varchar(25),
up_Thana varchar(25),
up_Imfile varchar(25),
up_Rent float,
up_Bed int,
up_Bath int,
up_Kitchen int,
up_Belcony int,
up_Dining int,
)

select * from PropertyDetails
TRUNCATE TABLE PropertyDetails
