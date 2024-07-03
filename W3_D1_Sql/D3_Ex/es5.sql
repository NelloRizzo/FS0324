-- 5) La media aritmetica del costo del trasporto di tutti gli ordini effettuati dal cliente "BOTTM"

SELECT
	AVG(Freight) AS CostoTrasportoMedio
FROM
	Orders
WHERE
	CustomerID = 'BOTTM'
	
SELECT
	CustomerID,
	AVG(Freight) AS CostoTrasportoMedio
FROM
	Orders
GROUP BY
	CustomerID 