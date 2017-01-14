USE Task1SlowDateRangeSearch;

SELECT * FROM Logs
	WHERE LogDate >= CAST('20060501' AS DATETIME) AND CAST('20060601' AS DATETIME) >= LogDate;

/* No records should be returned, but all will be checked */