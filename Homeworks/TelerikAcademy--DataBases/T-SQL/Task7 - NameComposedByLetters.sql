USE [TelerikAcademy]

GO

CREATE FUNCTION CheckIfHasLetters (@word nvarchar(20), @letters nvarchar(20))
RETURNS BIT
AS
BEGIN

DECLARE @lettersLen int = LEN(@letters),
@matches int = 0,
@currentChar nvarchar(1)

WHILE(@lettersLen > 0)
BEGIN
	SET @currentChar = SUBSTRING(@letters, @lettersLen, 1)
	IF(CHARINDEX(@currentChar, @word, 0) > 0)
		BEGIN
			SET @matches += 1
			SET @lettersLen -= 1
		END
	ELSE
		SET @lettersLen -= 1
END

IF(@matches >= LEN(@word) OR @matches >= LEN(@letters))
	RETURN 1

RETURN 0
END

GO

CREATE FUNCTION NamesAndTowns(@letters nvarchar(20))
RETURNS @ResultTable TABLE
(
Name varchar(50) NOT NULL
)
AS
BEGIN

INSERT INTO @ResultTable
SELECT LastName  FROM Employees

INSERT INTO @ResultTable
SELECT FirstName FROM Employees

INSERT INTO @ResultTable
SELECT towns.Name FROM Towns towns

DELETE FROM @ResultTable
WHERE dbo.CheckIfHasLetters(Name, @letters) = 0

RETURN
END

GO

SELECT * FROM dbo.NamesAndTowns('oistmiahf')
