-- 2) Selezione di tutti i prodotti con una quantità disponibile (UnitsInStock) di 
--    almeno 40 pezzi
SELECT
	ProductID
	, ProductName
	, SupplierID
	, CategoryID
	, QuantityPerUnit
	, UnitPrice
	, UnitsInStock
	, ReorderLevel
	, Discontinued
FROM 
	Products
WHERE
	UnitsInStock >= 40