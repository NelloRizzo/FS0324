-- 6) Selezione di tutti i prodotti la cui categoria è "1"
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
	CategoryID = 1