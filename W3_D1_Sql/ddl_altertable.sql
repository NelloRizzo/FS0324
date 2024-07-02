-- DDL ALTER -> modifica una struttura di metadati
alter table Esempio ADD
	Stipendio DECIMAL(18,2) NULL DEFAULT 1000 check (Stipendio > 0)

alter table Esempio 
	drop column DataNascita
	