SELECT 
	c.Name as [Città]
	, p.Name as [Provincia]
	, CONCAT(c.Name, ' (', p.Acronym, ')') as Denominazione
FROM 
	Cities as c INNER JOIN Provinces as p 
		ON c.ProvinceId = p.Id
WHERE
	p.Acronym = 'RM'