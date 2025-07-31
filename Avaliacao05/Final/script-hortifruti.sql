Create database Hortifruti;
go

use Hortifruti;
go

create table Frutas
(
	Id int identity(1,1),
	Nome Varchar(100) not null,
	DataVenc date not null,
	Constraint pk_Frutas primary key (Id)
);
go