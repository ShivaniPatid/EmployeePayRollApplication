create database EmployeePayRollDB;

create table EmployeePayRoll
(
	EmployeeId int primary key identity(1,1),
	EmployeeName varchar(255),
	ProfileImage varchar(255),
	Gender varchar(5),
	Department varchar(255),
	Salary float,
	StartDate Date,
	Notes varchar(255)
)


--------- create procedure for AddEmployee--------

create procedure AddEmployee
(
	@EmployeeName varchar(255),
	@ProfileImage varchar(255),
	@Gender varchar(5),
	@Department varchar(255),
	@Salary float,
	@Notes varchar(255)
)
as 
begin
Insert into EmployeePayRoll(EmployeeName, ProfileImage, Gender, Department, Salary, StartDate, Notes)
values (@EmployeeName, @ProfileImage, @Gender, @Department, @Salary, GETDATE(), @Notes);
end


--------- create procedure for UpdateEmployee-------

create procedure UpdateEmployee
(
	@EmployeeId int,
	@EmployeeName varchar(255),
	@ProfileImage varchar(255),
	@Gender varchar(5),
	@Department varchar(255),
	@Salary float,
	@Notes varchar(255)
)
as 
begin
update EmployeePayRoll set EmployeeName = @EmployeeName,
ProfileImage = @ProfileImage,
Gender = @Gender,
Department = @Department,
Salary = @Salary,
StartDate = GETDATE(),
Notes = @Notes
where EmployeeId = @EmployeeId
end


------- create procedure for DeleteEmployee----

create procedure DeleteEmployee
(
	@EmployeeId int
)
as 
begin
delete from EmployeePayRoll 
where EmployeeId = @EmployeeId
end;

-------- create procedure for GetAllEmployee-----

create procedure GetAllEmployee
as
begin
	select * from EmployeePayRoll
end;


-------- create procedure for GetEmployeeById-----

create procedure GetEmployeeById
(
	@EmployeeId int
)
as
begin
	select * from EmployeePayRoll
	where EmployeeId = @EmployeeId
end;
