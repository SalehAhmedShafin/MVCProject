use bachelorNeer
select * from PropertyDetails
create table Approvedproperty
(
ap_Id int primary key identity(1,1),
ap_Name varchar(30),
ap_Email varchar(30),
ap_Number varchar(30),
ap_Type varchar(30),
ap_Proaddress varchar(100),
ap_Thana varchar(30),
ap_Imfile varchar(100),
ap_Rent float(30),
ap_Bed int,
ap_Bath int,
ap_Kitchen int,
ap_Belcony int,
ap_Dining int
)

select * from Approvedproperty
SELECT COUNT(u_ID)  FROM  userinfo;