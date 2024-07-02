-- 5) Selezione degli ordini il cui importo del trasporto è superiore a 90 e inferiore a 200
SELECT 
	OrderID
	, CustomerID
	, EmployeeID
	, OrderDate
	, RequiredDate
	, ShippedDate
	, ShipVia
	, Freight
	, ShipName
	, ShipAddress
	, ShipCity
	, ShipRegion
	, ShipPostalCode
	, ShipCountry
FROM 
	Orders
WHERE
	Freight > 90 AND Freight < 200