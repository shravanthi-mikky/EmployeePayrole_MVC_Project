create Database Employ_mvc

create table EmployTable (
EmployeeId int Identity(1,1) PRIMARY KEY,
Name varchar(200),
Profile varchar(200),
Gender varchar(200),
Department varchar(200),
Salary varchar(200),
StartDate date
)

select * from EmployTable;

--Sp --- Add Employee ---------------

Create or ALTER PROCEDURE Sp_AddEmployee
@Name varchar(200),
@Profile varchar(200),@Gender varchar(200),@Department varchar(200),@Salary varchar(200),
@StartDate date

AS
BEGIN
insert into EmployTable(Name,Profile,Gender,Department,Salary,StartDate)
values(@Name,@Profile,@Gender,@Department,@Salary,@StartDate);
SELECT * from EmployTable
END

--Sp --- Delete Employee ---------------

create or ALTER PROCEDURE [dbo].[Sp_Delete]
	@EmployeeId int
AS
BEGIN
delete from EmployTable where EmployeeId=@EmployeeId

	SELECT * from EmployTable
END

--Sp --- Update ---------------------

Create procedure spUpdateEmployee          
(  
@EmpId int,
@Name varchar(200),
@Profile varchar(200),@Gender varchar(200),@Department varchar(200),@Salary varchar(200),
@StartDate date        
)          
as          
begin          
   Update EmployTable           
   set Name=@Name, 
   profile=@Profile, 
   Gender=@Gender,
   Department=@Department,        
   Salary=@Salary,
   StartDate=@StartDate
   where EmployeeId=@EmpId          
End    

--Sp -- Get All Employees -----

Create or alter procedure spGetAllEmployees      
as      
Begin      
    select * from EmployTable      
End

--Sp -- Get Employee By Employee Id-----

create or ALTER procedure [dbo].[Retrive_1_EmployeeDetails]
(
	@EmployeeId int
)
as
begin
select * from EmployTable where EmployeeId=@EmployeeId
END