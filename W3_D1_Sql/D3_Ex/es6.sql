-- 6) Totale delle spese effettuate raggruppate per id cliente
SELECT
	CompanyName AS Cliente
	, SUM(Quantity * UnitPrice) AS Spese
FROM 
	Orders AS o 
		JOIN [Order Details] AS d ON o.OrderID = d.OrderID
		JOIN Customers AS c ON o.CustomerID = c.CustomerID
GROUP BY 
	c.CompanyName