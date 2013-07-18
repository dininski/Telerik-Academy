-- task 1: 
-- Create a table in SQL Server with 10 000 000 log entries (date + text).
-- Search in the table by date range. Check the speed (without caching).

create database PerformanceHomewordDb
go

use PerformanceHomewordDb

create table Concerts(
	Id int Identity Primary Key,
	Performer nvarchar(100),
	[Date] date
)
go

-- Insert 10000 different values
SET NOCOUNT ON
DECLARE @ConcertCount int = (SELECT COUNT(*) FROM Concerts)
DECLARE @RowCount int = 10000
WHILE @RowCount > 0
BEGIN
  DECLARE @Performer nvarchar(100) = 
    'Name ' + CONVERT(nvarchar(100), @RowCount) + ': ' +
    CONVERT(nvarchar(100), newid())
  DECLARE @Date datetime = 
	DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
  INSERT INTO Concerts(Performer, [Date])
  VALUES(@Performer, @Date)
  SET @RowCount = @RowCount - 1
END
SET NOCOUNT OFF

-- Copy values until the total count is 1 000 000
WHILE (SELECT COUNT(*) FROM Concerts) < 1000000
BEGIN
  INSERT INTO Concerts(Performer, [Date])
  SELECT Performer, [Date] FROM Concerts
END

select count(*) from Concerts

CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- time taken - 6 sec
select * from Concerts
	where [date] > '10-10-2010' AND [date] < '10-10-2012'

-- task 2 - Add an index to speed-up the search by date.
-- Test the search speed (after cleaning the cache).

create index IDX_Concert_Date on Concerts([date])

CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- time taken - 2 sec
select * from Concerts
	where [date] > '10-10-2010' AND [date] < '10-10-2012'

-- task 3 - Add a full text index for the text column.
-- Try to search with and without the full-text index and compare the speed.
create fulltext catalog PerformersFullTextCatalog
with accent_sensitivity = off

create fulltext index on Concerts(Performer)
key index PK_Concerts on PerformersFullTextCatalog
with change_tracking auto

CHECKPOINT; DBCC DROPCLEANBUFFERS;

-- time taken - 0 sec
SELECT * FROM Concerts
WHERE CONTAINS(Performer, '123')

-- time taken - 6 sec
SELECT * FROM Concerts
WHERE Performer LIKE '%123%'