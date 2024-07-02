-- 4) Selezione di tutti gli ordini, ordinati in ordine decrescente per spese 
--    di trasporto (Freight)
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
ORDER BY 
	Freight DESC