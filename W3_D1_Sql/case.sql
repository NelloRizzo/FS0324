SELECT
	CASE 
		WHEN o.Nome IS NULL THEN 'Nessuno'
		ELSE CONCAT(o.Nome, ' ', o.Cognome)
	END AS Operaio
	, c.Denominazione, c.Citta, c.CAP
FROM
	Cantieri as c
		--INNER JOIN Operai as o ON c.Id = o.FK_Cantiere
		--LEFT OUTER JOIN Operai as o ON c.Id = o.FK_Cantiere
		--RIGHT OUTER JOIN Operai as o ON c.Id = o.FK_Cantiere
		FULL OUTER JOIN Operai as o ON c.Id = o.FK_Cantiere
WHERE
	c.CAP NOT LIKE '%0'
ORDER BY o.Cognome