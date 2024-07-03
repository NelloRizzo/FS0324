SELECT
	Id
	, CONCAT(Name, ' (', Acronym, ')') as Provincia
FROM 
	Provinces
WHERE
	-- Id < 10 or Id = 100
	-- Id > 5 AND Id < 10
	-- Id BETWEEN 5 AND 10
	Name BETWEEN 'A' AND 'Bologna'