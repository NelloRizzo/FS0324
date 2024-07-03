-- 11) Numero totale di ordini raggruppati per paese di spedizione (ShipCountry)
SELECT
	ShipCountry AS Paese,
	COUNT(*) AS TotaleOrdini,
--	12) La media del costo del trasporto raggruppati per paese di spedizione (ShipCountry)
	AVG(Freight) AS TrasportoMedio
FROM
	Orders
GROUP BY 
	ShipCountry