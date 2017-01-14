USE [ExamPrep-ToyStore]

SELECT 
	m.Name, 
	(SELECT COUNT(*) 
		FROM Toys t
			INNER JOIN AgeRanges ar ON ar.Id = t.AgeRange
			INNER JOIN Manufacturers innerM ON innerM.Id = t.Manufacturer
			WHERE ar.RangeFrom = 5
				AND ar.RangeTo = 10
				AND innerM.Id = m.Id)
FROM Manufacturers m
ORDER BY m.Name
