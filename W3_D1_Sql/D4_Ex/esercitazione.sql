-- a)
SELECT * FROM Impiegato WHERE Eta > 29;
-- b)
SELECT * FROM Impiegato WHERE RedditoMensile >= 800;
-- c)
SELECT * FROM Impiegato WHERE DetrazioneFiscale = 1;
-- d)
SELECT * FROM Impiegato WHERE DetrazioneFiscale = 0;
-- e)
SELECT * FROM Impiegato WHERE Cognome LIKE 'G%' ORDER BY Cognome;
-- f)
SELECT COUNT(*) AS TotaleImpiegati FROM Impiegato;
-- g)
SELECT SUM(RedditoMensile) AS TotaleRedditoMensile FROM Impiegato;
-- h)
SELECT AVG(RedditoMensile) AS TotaleRedditoMensile FROM Impiegato;
-- i)
SELECT MAX(RedditoMensile) AS RedditoMensileMaggiore FROM Impiegato;
-- j)
SELECT MIN(RedditoMensile) AS RedditoMensileMaggiore FROM Impiegato;
-- k)
SELECT * FROM Impiegato AS i JOIN Impiego AS m ON i.ImpiegoFk = m.Id WHERE Assunzione BETWEEN '2007-01-01' AND '2008-01-01'
-- l)
SELECT * FROM Impiegato AS i JOIN Impiego AS m ON i.ImpiegoFk = m.Id WHERE m.TipoImpiego LIKE @param
-- m)
SELECT AVG(Eta) AS EtaMedia FROM Impiegato;
