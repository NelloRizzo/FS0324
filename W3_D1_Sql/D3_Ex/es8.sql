-- 8) Totale di UnitPrice * Quantity raggruppato per ogni ordine
SELECT
	o.OrderID,
	SUM(d.UnitPrice * Quantity) AS Totale
FROM
	Orders AS o 
		JOIN [Order Details] d ON o.OrderId = d.OrderId
GROUP BY o.OrderID