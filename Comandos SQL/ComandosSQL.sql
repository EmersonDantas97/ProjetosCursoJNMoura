create database [web-api]; -- Colocar entre chaves para reconhecer traço.
GO

use [web-api];

create table Carro 
(
	Id int not null ,
	Nome varchar(100) not null,
	Valor decimal(10,2) not null,
	constraint joca primary key (id)
);

use [web-api];

create table Pessoa 
(
	Id int not null,
	Nome varchar (100) not null,
	Idade int not null
);

select * from Pessoa;

insert into Carro (Id, Nome, Valor) values (2, 'Zafira', 32000.00);

select * from dbo.Carro;
select * from dbo.Pessoa;

