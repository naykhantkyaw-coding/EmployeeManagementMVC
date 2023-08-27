CREATE TABLE Employee 
(
Id int PRIMARY KEY,
EmployeeName VARCHAR(50), 
Position VARCHAR(50), 
Office VARCHAR(50), 
Salary int
)

===========================================

Create Stored Procedure
CREATE PROCEDURE InsertUpdatedEmployee
@id int,
@employeename VARCHAR(50), 
@position VARCHAR(50), 
@office VARCHAR(50), 
@salary int,
@action varchar(10) 
AS 
BEGIN 
 IF @action='Insert' 
 BEGIN
INSERT INTO employee (,Id,EmployeeName,Position,Office,Salary) 
VALUES (@id,@employeename,@position,@office,@salary)
 END
 IF @action='Update'
 BEGIN
UPDATE employee SET EmployeeName=@employeename,Position=@position,Office=@office,Salary=@salary 
WHERE Id=@id
 END
 
END 

===========================================

CREATE PROCEDURE SelectEmployee 
AS 
 BEGIN 
 SELECT * FROM employee order by Id; 
 END

===========================================

CREATE PROCEDURE DeleteEmployee
@id integer
AS
 BEGIN
DELETE FROM Employee WHERE Id=@id
 END

===========================================

