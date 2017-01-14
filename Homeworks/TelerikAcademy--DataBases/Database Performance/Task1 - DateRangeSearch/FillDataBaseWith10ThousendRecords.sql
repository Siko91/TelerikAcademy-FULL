USE Task1SlowDateRangeSearch;

DECLARE @i int = 0
WHILE @i < 10000000 
BEGIN
    SET @i = @i + 1;
    
	INSERT INTO Logs (LogDate, LogText)
		VALUES (GETDATE(), 'some logged text');
END