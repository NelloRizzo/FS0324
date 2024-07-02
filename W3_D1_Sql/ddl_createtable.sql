-- DDL CREATE -> crea una struttura di metadati
create table Esempio (
	Id int primary key not null identity,
	Nome nvarchar(50) not null,
	DataNascita DATETIME2 not null,
	UltimaModifica DATETIME2 null default getdate()
)