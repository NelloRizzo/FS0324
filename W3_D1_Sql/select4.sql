select  -- 3
	denominazione_comune, Superficie_totale_ettari
from -- 1
	daticomunali
where -- 2
	codice_provincia = 1 or codice_provincia = 2
	-- <> diverso
	-- > maggiore
	-- < minore
	-- >= maggiore o uguale
	-- <= minore o uguale
	-- AND / OR
order by -- 4
	superficie_totale_ettari desc