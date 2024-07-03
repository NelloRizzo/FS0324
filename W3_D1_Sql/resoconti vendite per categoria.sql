-- resoconti delle vendite per categoria di prodotto
WITH report AS ( -- CTE 1
	-- media di vendita globale (1 riga perché raggruppa tutti i dettagli dell'ordine)
	SELECT AVG(Quantity * UnitPrice) AS GlobalAverage
	FROM 
		[Order Details]
	)
, 
grouped AS ( -- CTE 2
	-- vendite per categoria
	SELECT
		CategoryName,
		SUM(Quantity * d.UnitPrice) AS Amount, -- somma sul prezzo totale
		AVG(Quantity * d.UnitPrice) AS Average -- media di prezzo totale
	FROM 
		Categories AS c
			JOIN Products AS p ON c.CategoryID = p.CategoryID
			JOIN [Order Details] AS d ON d.ProductID = p.ProductID
	GROUP BY
		c.CategoryName
)
SELECT 
	CategoryName, 
	Amount, 
	Average, 
	GlobalAverage, 
	case 
		-- se la percentuale media di vendita è maggiore di 1
		when Average/GlobalAverage >= 1 THEN 'OK'
		-- altrimenti
		else 'KO'
	end as [Status]
from grouped, report -- cross join tra le due CTE (in realtà la prima è un solo valore in una sola riga)