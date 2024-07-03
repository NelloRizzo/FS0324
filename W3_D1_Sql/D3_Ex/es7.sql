-- 7) Numero totale di clienti raggruppati per città di appartenenza
SELECT
	Country,
	City,
	COUNT(*) AS Customers
FROM 
	Customers
GROUP BY Country, City
ORDER BY 
	Country, City DESC