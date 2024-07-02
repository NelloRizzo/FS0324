select 
	-- lista di selezione
	upper(denominazione_comune) as comune -- alias di colonna
	, cast(
		replace(
			replace(superficie_totale_ettari, '.', ''), ',', '.') 
		as decimal(18,2))
		as ettari
	, cast(replace(replace(Superficie_totale_Km2, '.', ''), ',', '.') 
		as decimal(18,2)) as km2
into Superficie
from 
	daticomunali