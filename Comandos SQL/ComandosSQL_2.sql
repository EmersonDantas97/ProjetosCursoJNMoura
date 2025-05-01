use [web-api];

Select * from Carro where id = 1 or id = 2; -- Operado "and" não funciona.
Select * from Carro where id in (1, 2);

insert Carro values (3, 'Zafira Express', 45000);

select Nome, sum(Valor) as SomaValores from Carro group by Nome;

Select Nome, Valor from Carro where Valor > 30000 and Valor < 40000;
Select Nome, Valor from Carro where Valor between 30000 and 40000; -- Faz maior igual e menor igual.

Select * from Carro where id != 50; -- <> ou utilizar o operador not

select * from Carro where Nome like 'o%';
select * from Carro where Nome like '_m%';

Select * from Carro order by Valor desc; -- Tomar cuidado com o order by, pois consome muito processamento.

select * from Pessoa;

sp_help Carro; -- Coluna Collation: Latin1_General_CI_AS = CI_AS = Maiuscula e minuscula insensitive_Acento Sensitive. 

insert into Pessoa (Id, Nome, Idade) values (1, 'Emerson', 28);
insert Pessoa (Id, Nome, Idade) values (2, 'Bruna', 28);
insert Pessoa (Id, Nome, Idade) values (2, 'Bruna', 28), (3, 'Dora', 40);
insert Pessoa values (4, 'Adriano', 39);

sp_help Carro; -- Primeira linha é chamada de Tupla. 

-- Chave Primária => Primary Key => PK

delete from Carro; -- DML

drop table Carro; -- DDL

create table Carro 
(
	Id int not null ,
	Nome varchar(100) not null, -- Poderia ser feito também "Nome varchar(100) not null primary key," mas não colocaria nome.
	Valor decimal(10,2) not null,
	constraint pk_Carro primary key (id) -- Determino o nome da pk
);

select * from Carro;

insert Carro values (1, 'Ka', 19000);
insert Carro values (2, 'Ecosport', 25000);
insert Carro values (2, 'Ecosport', 25000);

-- Estudar algorítimo de ordenação.

/*
	Não confundir a PK com AUTO INCREMENTO
	PK = Restrição de exclusividade. Por padrão PK não aceita nulos (é "not null" automáticamente).
	Auto Incremento = Numeração automática.
*/

drop table Pessoa;

create table Pessoa 
(
	Id int not null identity (1,1), -- (1,1) Número inicial e quantidade por incremento. 
	Nome varchar (100) not null,
	Idade int not null,
	constraint pk_Pessoa primary key (id)
);

insert into Pessoa (Nome, Idade) values ('Emerson', 28);
insert into Pessoa (Nome, Idade) values ('Bruna', 28);
insert into Pessoa (Nome, Idade) values ('Dora', 47);
insert into Pessoa (Nome, Idade) values ('Adriano', 45);
/*insert into Pessoa (Id, Nome, Idade) values (15,'Fernando', 45); Erro. Não deixar inserir valor explicitamente.*/

Select * from Pessoa;