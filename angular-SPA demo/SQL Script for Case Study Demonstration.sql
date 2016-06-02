create database AditiTrainingDB
go

use AditiTrainingDB
go

create table Customers (
	CustomerId int identity primary key,
	CustomerName nvarchar(50),
	Address national character varying(255),
	CreditLimit int,
	ActiveStatus bit,
	EmailId nvarchar(60),
	PhoneNumber character varying(20),
	Remarks nvarchar(255)
)

insert into Customers values
	( N'Northwind Traders', 'Bangalore', 12000, 1, 'info@nwt.com', '080-98343433', 'Simple Customer Record' ),
	( N'Southwind Traders', 'Bangalore', 12000, 1, 'info@nwt.com', '080-98343433', 'Simple Customer Record' ),
	( N'Westwind Traders', 'Chennai', 22000, 1, 'info@nwt.com', '080-98343433', 'Simple Customer Record' ),
	( N'Eastwind Traders', 'Bangalore', 32000, 1, 'info@nwt.com', '080-98343433', 'Simple Customer Record' ),
	( N'Oxyrich Traders', 'Bangalore', 12000, 0, 'info@nwt.com', '080-98343433', 'Simple Customer Record' ),
	( N'Adventureworks', 'Mysore', 12000, 1, 'info@nwt.com', '080-98343433', 'Simple Customer Record' ),
	( N'Footmart', 'Mangalore', 12000, 1, 'info@nwt.com', '080-98343433', 'Simple Customer Record' );

select * from Customers;
go

create procedure dbo.uspGetCustomers(@customerName nvarchar(50))
as
begin
	if(@customerName is null)
		select * from Customers;
	else select * from Customers
		where CustomerName like '%' + @customerName + '%';
end;
go

execute dbo.uspGetCustomers 'wind';
go
