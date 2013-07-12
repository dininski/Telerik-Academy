USE TelerikAcademy

-- Problem 1 - Write a SQL query to find the names and salaries of the employees
-- that take the minimal salary in the company. Use a nested SELECT statement.
SELECT e.FirstName, e.LastName, e.Salary
	FROM Employees e WHERE e.Salary = 
		(SELECT MIN(Salary) From Employees)

-- Problem 2 - Write a SQL query to find the names and salaries of the employees
-- that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT e.FirstName, e.LastName, e.Salary FROM Employees e
	WHERE e.Salary < (SELECT MIN(Salary) From Employees) * 1.1

-- Problem 3 - Write a SQL query to find the full name, salary and department of the
-- employees that take the minimal salary in their department. Use a nested SELECT statement.
SELECT FirstName, LastName, DepartmentID, Salary
FROM Employees e
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID)
ORDER BY DepartmentID

-- Problem 4 - Write a SQL query to find the average salary in the department #1.
SELECT AVG(e.Salary) AS [Average Salary] FROM Employees e
	WHERE e.DepartmentID = 1

-- Problem 5 - Write a SQL query to find the average salary in the "Sales" department.
SELECT AVG(e.Salary) AS [Average Salary] FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'

-- Problem 6 - Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(*) AS [Number of people in Sales] FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'

-- Problem 7 - Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(ManagerID) AS [Employees with managers] FROM Employees e

-- Problem 8 - Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(*) AS [Employess without managers] FROM Employees e
	WHERE e.ManagerID IS NULL

-- Problem 9 - Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name AS Department, AVG(e.Salary) FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	GROUP BY d.Name

-- Problem 10 - Write a SQL query to find the count of all employees in each department and for each town.
SELECT d.Name AS Department, t.Name AS Town, COUNT(*) FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	GROUP BY t.Name, d.Name

-- Problem 11 - Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.firstName, m.LastName FROM Employees m
	JOIN Employees e ON e.ManagerID = m.EmployeeID
	GROUP BY m.FirstName, m.LastName
	HAVING COUNT(e.ManagerID) = 5

-- Problem 12 - Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.EmployeeID, (e.firstName + ' ' + e.LastName) AS [Employee Name], 
	ISNULL((m.FirstName + ' ' + m.LastName), '(no manager)') AS [Manager]
FROM Employees e
	LEFT OUTER JOIN Employees m
		ON e.ManagerID = m.EmployeeID

-- Problem 13 - Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT e.FirstName, e.LastName FROM Employees e
	WHERE LEN(e.lastName) = 5

-- Problem 14 - Write a SQL query to display the current date and time in the following format
-- "day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.
SELECT CONVERT(varchar, GETDATE(), 113)

-- Problem 15 - Write a SQL statement to create a table Users.
-- Users should have username, password, full name and last login time.
-- Choose appropriate data types for the table fields.
-- Define a primary key column with a primary key constraint.
-- Define the primary key column as identity to facilitate inserting records.
-- Define unique constraint to avoid repeating usernames.
-- Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users(
	Id int IDENTITY,
	UserName nvarchar(20) UNIQUE NOT NULL,
	UserPassword nvarchar(20),
	FullName nvarchar(40) NOT NULL,
	LastLogin datetime,
	CONSTRAINT PK_Users PRIMARY KEY(Id),
	CONSTRAINT PasswordMinLength CHECK (DATALENGTH([UserPassword]) > 4)
)

INSERT INTO Users(UserName, UserPassword, FullName, LastLogin)
	VALUES ('stamat', 'parolata', 'Pesho Peshov', GETDATE()),
		('pesho', 'parolata', 'Pesho Peshov', GETDATE() - 2),
		('pesho2', 'parolata', 'Pesho Peshov', GETDATE() - 4)
GO

-- Problem 16 - Write a SQL statement to create a view that displays the users from the
-- Users table that have been in the system today. Test if the view works correctly.
CREATE VIEW [Logged in today]
	AS SELECT * FROM Users u
		WHERE DATEDIFF(DAY, u.LastLogin, GETDATE()) = 0
GO

-- Problem 17 - Write a SQL statement to create a table Groups.
-- Groups should have unique name (use unique constraint).
-- Define primary key and identity column.
CREATE TABLE Groups (
	Id int IDENTITY,
	Name nvarchar(20) UNIQUE,
	CONSTRAINT PK_Groups PRIMARY KEY(Id)
)

-- Problem 18 - Write a SQL statement to add a column GroupID to the table Users.
-- Fill some data in this new column and as well in the Groups table.
-- Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
ALTER TABLE Users  
	ADD GroupId int

ALTER TABLE Users
	ADD CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupId)
		REFERENCES Groups(Id)

-- Problem 19 - Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Groups(Name)
	VALUES ('Administrators'), ('Moderators'), ('Users')

INSERT INTO Users(UserName, UserPassword, FullName, GroupId)
	VALUES
		('nakov', '123456', 'Svetlin Nakov', 1),
		('niki', '654321', 'Nikolay Kostov', 1),
		('doncho', '111111', 'Doncho Minkov', 1),
		('kurtev', '999999', 'Teodor Kurtev', 2),
		('jasssonpet', 'abvabv', 'Jasson Petrov', 2),
		('a user', 'userpass', 'User Userov', 3)

-- Problem 20 - Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users SET UserName = 'a forum user'
	WHERE UserName = 'a user'

UPDATE Users SET UserPassword = 'umna_parola'
	WHERE Id = 1

UPDATE Groups SET Name = 'Forum users'
	WHERE Name = 'Users'

-- Problem 21 - Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Groups
	WHERE Name = 'Extra'

DELETE FROM Users
	WHERE Id = 1 OR Id = 2

-- Problem 22 - Write SQL statements to insert in the Users table the names of all employees from the Employees table.
-- Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase).
-- Use the same for the password, and NULL for last login time.
INSERT INTO Users(FullName, UserName, UserPassword)
	SELECT (e.FirstName + ' ' + e.LastName),
		(SUBSTRING(e.FirstName, 0, 4) + LOWER(e.LastName)),
		(SUBSTRING(e.FirstName, 0, 2) + LOWER(e.LastName))
	FROM Employees e

-- Problem 23 - Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users SET UserPassword = NULL
	WHERE DATEDIFF(day, LastLogin, CAST('2010-03-10' AS DATE)) > 0

-- Problem 24 - Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
	WHERE UserPassword IS NULL

-- Problem 25 - Write a SQL query to display the average employee salary by department and job title.
SELECT AVG(e.Salary) as AvgSalary, e.JobTitle, d.Name FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	GROUP BY e.JobTitle, e.Salary, d.Name
	ORDER BY AvgSalary DESC

-- Problem 26 - Write a SQL query to display the minimal employee salary by department
-- and job title along with the name of some of the employees that take it.
SELECT MIN(e.Salary) as MinSalary, e.JobTitle, d.Name FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	GROUP BY e.JobTitle, e.Salary, d.Name
	ORDER BY MinSalary DESC

-- Problem 27 - Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name, COUNT(t.Name) as [Number of employees] FROM Towns t
	JOIN Addresses a ON t.TownID = a.TownID
	JOIN Employees e ON a.AddressID = e.AddressID
	GROUP BY t.Name
	ORDER BY [Number of employees] DESC

-- Problem 28 - Write a SQL query to display the number of managers from each town.
SELECT t.Name, COUNT(*) as [Number of managers] FROM Towns t
	JOIN Addresses a ON t.TownID = a.TownID
	JOIN Employees e ON a.AddressID = e.AddressID
	WHERE e.EmployeeID IN 
	(SELECT DISTINCT ManagerID FROM Employees)
	GROUP BY t.Name
	ORDER BY [Number of managers] DESC

-- Problem 29 - Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
-- Don't forget to define identity, primary key and appropriate foreign key.
CREATE TABLE WorkHours(
	Id int IDENTITY,
	EmployeeID int NOT NULL,
	[Date] date,
	Task nvarchar(20),
	[Hours] int,
	Comments nvarchar(30),
	CONSTRAINT PK_WorkHours PRIMARY KEY(Id),
	CONSTRAINT FK_Employees_WorkHours FOREIGN KEY(EmployeeId)
		REFERENCES Employees(EmployeeId)
	)

-- Problem 30 - Issue few SQL statements to insert, update and delete of some data in the table.


-- Problem Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
-- For each change keep the old record data, the new record data and the command (insert / update / delete).

-- Problem Start a database transaction, delete all employees from the 'Sales' department along with
-- all dependent records from the pother tables. At the end rollback the transaction.

-- Problem Start a database transaction and drop the table EmployeesProjects.
-- Now how you could restore back the lost table data?

-- Problem Find how to use temporary tables in SQL Server.
-- Using temporary tables backup all records from EmployeesProjects and restore
-- them back after dropping and re-creating the table.
