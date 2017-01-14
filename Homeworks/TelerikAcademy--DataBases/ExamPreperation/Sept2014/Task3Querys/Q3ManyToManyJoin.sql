USE [ExamPrep-ToyStore]

SELECT * FROM ToysCategoryes tc
INNER JOIN Toys t ON t.Id = tc.ToyId
INNER JOIN Category c ON c.Id = tc.CategoryId
WHERE c.Name = 'boys'