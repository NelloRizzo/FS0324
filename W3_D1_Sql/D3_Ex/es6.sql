-- 6) Totale delle spese effettuate raggruppate per id cliente
SELECT
	CompanyName AS Cliente
	, SUM(Quantity * UnitPrice) AS Spese
FROM 
	Orders o 
		JOIN [Order Details] d ON o.OrderID = d.OrderID
		JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY 
	c.CompanyName