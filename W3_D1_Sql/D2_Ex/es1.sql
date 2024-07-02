-- 1) Selezione di tutti i prodotti (tutti i campi)
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