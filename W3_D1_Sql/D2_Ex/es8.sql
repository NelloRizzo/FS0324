-- 8) Selezione di tutti gli ordini del cliente con ID "BOTTM" le cui 
--    spese di trasporto superano l'importo di 50.
SELECT
	*
FROM 
	Orders
WHERE
	CustomerID = 'BOTTM' AND Freight > 50;
-- Per conoscere i dati completi del cliente dovrei scrivere
SELECT * FROM Customers WHERE CustomerID = 'BOTTM';
-- Per conoscere i dati completi degli impiegati dovrei scrivere
SELECT * FROM Employees WHERE EmployeeID = 3;
SELECT * FROM Employees WHERE EmployeeID = 6;
SELECT * FROM Employees WHERE EmployeeID = 2;
SELECT * FROM Employees WHERE EmployeeID = 1;