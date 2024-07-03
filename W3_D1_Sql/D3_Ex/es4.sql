-- 4) La media aritmetica del costo del trasporto di tutti gli ordini effettuati
SELECT
	AVG(Freight) AS CostoTrasportoMedio,
	SUM(Freight) AS CostoTrasporto,
	COUNT(Freight) AS TotaleTrasporti,
	SUM(Freight) / COUNT(Freight) AS Media
FROM
	Orders