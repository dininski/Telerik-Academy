--1.
 
CREATE TABLE Persons (
        PersonsID INT IDENTITY,
        FirstName NVARCHAR(50),
        LastName NVARCHAR(50),
        SSN NVARCHAR(50)
        CONSTRAINT PK_PersonsID PRIMARY KEY(PersonsID)
)
 
CREATE TABLE Accounts (
        AccountID INT IDENTITY,
        PersonID INT,
        Balance money
        CONSTRAINT PK_AccountID PRIMARY KEY(AccountID)
        CONSTRAINT FK_PersonID FOREIGN KEY(PersonID)
                REFERENCES Persons(PersonID)
)
 
CREATE PROC dbo.usp_SelectPersonsNames
AS
        SELECT p.FirstName + ' ' + p.LastName
        FROM dbo.Persons p
GO
 
EXEC dbo.usp_SelectPersonsNames
 
 
--2.
 
ALTER PROC dbo.usp_SelectMoreMoney (@leverageBalance INT = 200)
AS
        SELECT p.FirstName + ' ' + p.LastName
        FROM dbo.Persons p INNER JOIN dbo.Accounts a
        ON p.PersonID = a.PersonID
        WHERE a.Balance >= @leverageBalance
GO
 
EXEC usp_SelectMoreMoney 400
 
 
--3.
 
CREATE PROC dbo.usp_CalculateNewSum (
        @SUM INT = 200,
        @interest INT = 10,
        @monthsN INT = 24,
        @RESULT INT OUTPUT
        )
AS
        SET @RESULT = @SUM + (@monthsN/12)*((@interest*@SUM)/100)
GO
 
DECLARE @answer INT
EXEC usp_CalculateNewSum 200, 10, 24, @answer OUTPUT
SELECT @answer
 
 
--4.
 
CREATE PROC dbo.usp_GiveInterest (
        @id INT = 4,
        @interest INT,
        @RESULT money OUTPUT
        )
 
        AS
 
        DECLARE @sumz money
        SET @sumz = (SELECT a.Balance
                        FROM dbo.Accounts a
                                INNER JOIN dbo.Persons p
                                ON p.PersonID = a.PersonID
                                        AND p.PersonID = @id)
   
        EXEC usp_CalculateNewSum
                @sumz,
                @interest,
                24,
                @RESULT OUTPUT         
        GO
       
DECLARE @final money
EXEC usp_GiveInterest 1, 10, @final OUTPUT
SELECT @final
 
 
--5.
 
CREATE PROC dbo.usp_WithdrawMoney (
        @AccountID INT,
        @money money,
        @RESULT money OUTPUT
)
AS
        DECLARE @curBalance money
        SET @curBalance = (
                SELECT a.Balance
                FROM dbo.Accounts a
                WHERE a.AccountID = @AccountID
                )
        SET @RESULT = @curBalance - @money
        UPDATE dbo.Accounts
                SET Balance = @RESULT
                WHERE(Accounts.AccountID = @AccountID)
GO
 
DECLARE @answer money
EXEC usp_WithdrawMoney 1, 50, @answer OUTPUT
SELECT @answer
 
------------------
 
CREATE PROC dbo.usp_DepositMoney (
        @AccountID INT,
        @money money,
        @RESULT money OUTPUT
)
AS
        DECLARE @curBalance money
        SET @curBalance = (
                SELECT a.Balance
                FROM dbo.Accounts a
                WHERE a.AccountID = @AccountID
                )
        SET @RESULT = @curBalance + @money
        UPDATE dbo.Accounts
                SET Balance = @RESULT
                WHERE(Accounts.AccountID = @AccountID)
GO
 
DECLARE @answer money
EXEC usp_DepositMoney 1, 50, @answer OUTPUT
SELECT @answer
 
 
--6.
 
CREATE TABLE Logs(
        LogID INT IDENTITY,
        AccountID INT,
        NewSum money,
        CONSTRAINT PK_LogID PRIMARY KEY(LogID),
        CONSTRAINT FK_AccountID FOREIGN KEY(AccountID)
                REFERENCES Accounts(AccountID)
)
 
CREATE TRIGGER tr_AccountsUpdate ON dbo.Accounts FOR UPDATE
AS
        BEGIN
        INSERT INTO dbo.Logs
                SELECT a.AccountID AS AccountID,
                a.Balance AS NewSum
        FROM inserted a
        END
GO
DECLARE @answer money
EXEC usp_WithdrawMoney 4, 50, @answer OUTPUT
SELECT @answer
 
 
--7.
 
--Divided the searches into different, each selecting a distinct tale of results,
--instead of one table for all. Can easily combine them all if one needs to.
-- Procedure to search through First Names
CREATE PROC [dbo].[usp_FindNames](
        @lettersToSearch NVARCHAR(50)
        )
        AS
                DECLARE @valid bit
                SET @valid = 0
                                       
                        SELECT e.FirstName AS [FIRST Names]
                        FROM Employees e
                        WHERE
                                1 = (SELECT [dbo].[fn_NameContainingLetters](
                                        e.FirstName,
                                        @lettersToSearch)
                                        )
        GO
 
--Procedure to search through Middle Names
CREATE PROC [dbo].[usp_FindMiddleNames](
        @lettersToSearch NVARCHAR(50)
        )
        AS
                DECLARE @valid bit
                SET @valid = 0
                                       
                        SELECT e.MiddleName AS [Middle Names]
                        FROM Employees e
                        WHERE
                                1 = (SELECT [dbo].[fn_NameContainingLetters](
                                        e.MiddleName,
                                        @lettersToSearch)
                                        )
        GO
 
--Procedure to search through Last Names
CREATE PROC [dbo].[usp_FindLastNames](
        @lettersToSearch NVARCHAR(50)
        )
        AS
                DECLARE @valid bit
                SET @valid = 0
                                       
                        SELECT e.LastName AS [LAST Names]
                        FROM Employees e
                        WHERE
                                1 = (SELECT [dbo].[fn_NameContainingLetters](
                                        e.LastName,
                                        @lettersToSearch)
                                        )
        GO
 
 
--Procedure to search through Towns
CREATE PROC [dbo].[usp_FindTowns](
        @lettersToSearch NVARCHAR(50)
        )
        AS
                DECLARE @valid bit
                SET @valid = 0
                                       
                        SELECT t.Name AS [Towns]
                        FROM Towns t
                        WHERE
                                1 = (SELECT [dbo].[fn_NameContainingLetters](
                                        t.Name,
                                        @lettersToSearch)
               
 
-- The Function For Every String
CREATE FUNCTION [dbo].[fn_NameContainingLetters](
        @name NVARCHAR(50),
        @letters NVARCHAR(50)
        )
        RETURNS bit
AS
BEGIN
        DECLARE @contains bit
        SET @contains = 1
        DECLARE @curLetter NVARCHAR(1)
        DECLARE @counter INT
        SET @counter = 1
 
        WHILE(@counter <= LEN(@name))
                BEGIN
                SET @curLetter = SUBSTRING(@name, @counter, 1)
                IF (CHARINDEX(@curLetter, @letters) = 0)
                        SET @contains = 0
                SET @counter = @counter + 1
                END
        RETURN @contains
END
 
EXEC [dbo].[usp_FindNames] @letterstosearch = 'oistmiahf'
EXEC [dbo].[usp_FindMiddleames] @letterstosearch = 'oistmiahf'
EXEC [dbo].[usp_FindLastNames] @letterstosearch = 'oistmiahf'
EXEC [dbo].[usp_FindTowns] @letterstosearch = 'oistmiahf'
 
 
--8.
 
DECLARE empCursor CURSOR READ_ONLY FOR
        SELECT e.FirstName, e.LastName, t.Name,
                o.FirstName, o.LastName
        FROM Employees e
                INNER JOIN Addresses a
                        ON a.AddressID = e.AddressID
                INNER JOIN Towns t
                        ON t.TownID = a.TownID,
        Employees o
                INNER JOIN Addresses a1
                        ON a1.AddressID = o.AddressID
                INNER JOIN Towns t1
                        ON t1.TownID = a1.TownID               
 
        OPEN empCursor
        DECLARE @firstName1 NVARCHAR(50)
        DECLARE @lastName1 NVARCHAR(50)
        DECLARE @town NVARCHAR(50)
        DECLARE @firstName2 NVARCHAR(50)
        DECLARE @lastName2 NVARCHAR(50)
        FETCH NEXT FROM empCursor
                INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
 
        WHILE @@FETCH_STATUS = 0
                BEGIN
                        PRINT @firstName1 + ' ' + @lastName1 +
                                '     ' + @town + '      ' + @firstName2 + ' ' + @lastName2
                        FETCH NEXT FROM empCursor
                                INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
                END
 
        CLOSE empCursor
        DEALLOCATE empCursor
 
 
--9.
 
-- Create another table to hold people fromeach city, ordered by city
CREATE TABLE UsersTowns (
        ID INT IDENTITY,
        FullName NVARCHAR(50),
        TownName NVARCHAR(50)
)
INSERT INTO UsersTowns
SELECT e.FirstName + ' ' + e.LastName, t.Name
                FROM Employees e
                        INNER JOIN Addresses a
                                ON a.AddressID = e.AddressID
                        INNER JOIN Towns t
                                ON t.TownID = a.TownID
                GROUP BY t.Name, e.FirstName, e.LastName
 
 
 
-- Nested cursors to fetch info
DECLARE @name NVARCHAR(50)
        DECLARE @town NVARCHAR(50)
 
        DECLARE empCursor1 CURSOR READ_ONLY FOR
                SELECT DISTINCT ut.TownName
                        FROM UsersTowns ut     
 
        OPEN empCursor1
        FETCH NEXT FROM empCursor1
                INTO @town
 
                WHILE @@FETCH_STATUS = 0
                BEGIN
                        PRINT @town
 
                        DECLARE empCursor2 CURSOR READ_ONLY FOR
                                SELECT ut.FullName
                                FROM UsersTowns ut
                                        WHERE ut.TownName = @town
                        OPEN empCursor2
                       
                        FETCH NEXT FROM empCursor2
                                INTO @name
                               
                                WHILE @@FETCH_STATUS = 0
                                BEGIN
                                        PRINT '   ' + @name
                                        FETCH NEXT FROM empCursor2 INTO @name
                                END
 
                                CLOSE empCursor2
                                DEALLOCATE empCursor2
                        FETCH NEXT FROM empCursor1 INTO @town
                END
 
        CLOSE empCursor1
        DEALLOCATE empCursor1
 
 
--10.
 
DECLARE @name nvarchar(MAX);
SET @name = N'';
SELECT @name+=e.FirstName+N','
FROM Employees e
SELECT LEFT(@name,LEN(@name)-1);