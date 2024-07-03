-- 2) Numero totale di clienti che abitano a Londra
SELECT 
	COUNT(*) AS TotaleClienti 
FROM 
	Customers
WHERE
	City = 'London'