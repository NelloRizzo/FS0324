SELECT
	Codice_Regione as Regione
	, Codice_Provincia as Provincia
	, Denominazione_Comune as Comune
	, CAST(
		REPLACE(REPLACE(Superficie_totale_ettari, '.', ''), ',', '.') AS DECIMAL(18,2)
		) as Superficie
INTO
	SuperficieComuniItaliani
FROM
	daticomunali