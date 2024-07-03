-- 9) Totale di UnitPrice * Quantity solo dell'ordine con id=10248
SELECT
	o.OrderID,
	SUM(d.UnitPrice * Quantity) AS Totale
FROM
	Orders AS o 
		JOIN [Order Details] d ON o.OrderId = d.OrderId
WHERE 
	o.OrderID = 10248
GROUP BY o.OrderID