-- 7) Selezione di tutte le righe dei dettagli degli ordini che hanno applicato uno sconto
SELECT
	OrderID
	, ProductID
	, UnitPrice
	, Quantity
	, Discount
FROM 
	[Order Details]
WHERE 
	Discount > 0