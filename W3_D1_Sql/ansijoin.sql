SELECT 
	c.Name as [Città]
	, p.Name as [Provincia]
	, CONCAT(c.Name, ' (', p.Acronym, ')') as Denominazione
FROM 
	Cities as c, Provinces as p -- risultato con 7901 città x 110 province CROSS JOIN
WHERE
	--Cities.ProvinceId = Provinces.Id -- ANSI JOIN
	c.ProvinceId = p.Id
	AND 
	p.Acronym = 'RM'