CREATE DATABASE Loja;
GO

USE Loja;
GO

CREATE TABLE Veiculos 
(
	Id int identity(1,1),
	Marca varchar(50) not null,
	Nome varchar(100) not null,
	AnoModelo int not null,
	DataFabricacao date not null,
	Valor decimal(8,2) not null,
	Opcionais varchar(500),
	constraint pk_Veiculos primary key (Id)
);
GO