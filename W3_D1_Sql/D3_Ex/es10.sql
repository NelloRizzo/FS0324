-- 10) Numero di prodotti censiti per ogni categoria 
SELECT
	CategoryName AS Categoria,
	COUNT(*) AS TotaleProdotti
FROM 
	Products p JOIN Categories c ON p.CategoryID = c.CategoryID
GROUP BY CategoryName