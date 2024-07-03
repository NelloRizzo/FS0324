with -- CTE 
	citysource as (select top 3 * from cities) -- sorgente dati temporanea di nome citysource
, 
	provsource as (select top 3 * from provinces) -- sorgente dati temporanea di nome provsource
-- in questa query posso usare le due CTE
select 
	* 
from 
	citysource 
	, provsource
where
	citysource.ProvinceId = provsource.id