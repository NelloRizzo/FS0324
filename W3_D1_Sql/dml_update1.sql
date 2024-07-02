-- DML Update -> Modifica
UPDATE RegistrazioniEsami
SET
	Esame = 'PROVA',
	DataEsame = getdate()
WHERE
	Voto = 29 OR Nome = 'Mickey'