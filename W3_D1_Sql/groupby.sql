SELECT 
	Regione, Provincia,
	COUNT(*) as 'Totale Comuni'
	, MIN(Superficie) as 'Superficie Minima'
	, MAX(Superficie) as 'Superficie Massima'
	, AVG(Superficie) as 'Superficie Media'
	, SUM(Superficie) as 'Superficie Complessiva'
FROM 
	SuperficieComuniItaliani
WHERE
	Regione < 3
GROUP BY 
	Regione, Provincia
HAVING
	COUNT(*) >= 100
ORDER BY CAST(Regione as INT),CAST( Provincia AS INT)