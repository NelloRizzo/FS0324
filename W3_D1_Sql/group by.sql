SELECT -- (5) effettua la proiezione, cioè la lista dei campi da produrre al client
	--o.OrderID as Ordine ,
	c.CompanyName AS Cliente
	--, o.OrderDate as [Data]
	, COUNT(*) AS TotaleOrdini
	, ISNULL(SUM(d.Quantity), 0) AS [Quantità di Prodotti Ordinati]
	, ISNULL(SUM(d.Quantity * d.UnitPrice), 0) AS Totale
FROM -- specifica le sorgenti dalle quali prelevare i dati (1)
	Customers AS c 
		LEFT JOIN Orders AS o ON c.CustomerID = o.CustomerID
		LEFT JOIN [Order Details] AS d ON o.OrderID = d.OrderID
WHERE -- filtra le righe 1 ad 1 (2)
	c.City LIKE 'L%n'
GROUP BY -- raggruppa su uno o più campi (3)
	c.CompanyName 
HAVING -- filtra sul risultato delle operazioni di aggregazione (4)
	SUM(d.Quantity) >= 100
ORDER BY -- ordina su uno o più campi (6)
	TotaleOrdini DESC, Cliente