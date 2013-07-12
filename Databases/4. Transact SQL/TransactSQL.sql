-- Problem 1 - Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN)
-- and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing.
-- Write a stored procedure that selects the full names of all persons.
CREATE DATABASE Company
USE Company

CREATE TABLE Persons(
	Id int IDENTITY,
	FirstName nvarchar(20),
	LastName nvarchar(20),
	SSN nvarchar(14),
	CONSTRAINT PK_Persons PRIMARY KEY(Id)
)

CREATE TABLE Accounts (
	Id int IDENTITY,
	PersonId int,
	Balance decimal,
	CONSTRAINT PK_Accounts PRIMARY KEY(Id),
	CONSTRAINT PK_Persons_Accounts FOREIGN KEY(PersonId)
		REFERENCES Persons(Id)
)

INSERT INTO Persons(FirstName, LastName, SSN)
	VALUES ('Svetlin', 'Nakov', '123-456-789-01'),
	('Niki', 'Kostov', '321-654-987-10'),
	('Georgi', 'Georgiev', '123-123-123-12'),
	('Doncho', 'Minkov', '111-222-333-44')
	
INSERT INTO Accounts(PersonId, Balance)
	VALUES(1, 1000),
	(2, 2000),
	(3, 3000),
	(4, 4000)
GO

CREATE PROC dbo.usp_SelectFullEmployeeName
AS
	SELECT a.FirstName + ' ' + a.LastName as [Employee Name] FROM Persons a
GO

EXEC usp_SelectFullEmployeeName

-- Problem 2 - Create a stored procedure that accepts a number as a parameter and returns all persons who have more money in their accounts than the supplied number.
GO
CREATE PROC dbo.usp_SelectPersonsWithBalanceMore(@amount int = 0)
AS
	SELECT * FROM Persons p
		JOIN Accounts a
			ON p.Id = a.PersonId
		WHERE a.Balance > @amount
GO

EXEC usp_SelectPersonsWithBalanceMore 2200

-- Problem 3 - Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
GO
CREATE PROC dbo.usp_CalculateAfterInterest(@sum decimal, @yearlyInterest decimal, @numberOfMonths int, @result decimal OUTPUT)
AS
	SET @result = @sum * (1 + (@yearlyInterest / 12) * @numberOfMonths)
	RETURN @result
GO

DECLARE @result decimal
SET @result = 0
EXEC usp_CalculateAfterInterest 100, 5, 12, @result OUTPUT
SELECT @result

-- Problem 4 - Create a stored procedure that uses the function from the previous example
-- to give an interest to a person's account for one month. It should take the AccountId
-- and the interest rate as parameters.
					

-- Problem Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money) that operate in transactions.
-- Problem Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
-- Problem Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's names that are comprised of given set of letters. Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
-- Problem Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of employees that live in the same town.
-- Problem * Write a T-SQL script that shows for each town a list of all employees that live in it.
-- Problem Define a .NET aggregate function StrConcat that takes as input a sequence of strings and return a single string that consists of the input strings separated by ','. For example the following SQL statement should return a single string: