Insert into Departamento Values ('RH');
Insert into Departamento Values ('Suporte');
Insert into Departamento Values ('Fiscal');
Insert into Departamento Values ('Desenvolvimento');
Insert into Departamento Values ('Vendas');
Insert into Departamento Values ('Financeiro');
Insert into Departamento Values ('Operacao');

select distinct codigodepartamento from funcionario order by codigodepartamento;

Select * from departamento;

sp_help Departamento;

Select * from Funcionario;

Select *
from Funcionario, Departamento
where Funcionario.CodigoDepartamento = Departamento.Codigo;

drop table Departamento;

Select * from funcionario;
Select * from Departamento;

create table Departamento 
(
	Codigo int identity(1,1),
	Nome Varchar(100) not null,
	constraint pk_Departamento primary key (Codigo)
);

select * from Funcionario 
left join Departamento 
on Funcionario.CodigoDepartamento = Departamento.Codigo

alter table Funcionario add
constraint fk_Funcionario_Departamento foreign key (CodigoDepartamento) 
references Departamento(Codigo);

Select F.Codigo, F.PrimeiroNome, F.CodigoDepartamento, D.Nome
from Funcionario as F
inner join Departamento as D 
on D.Codigo = F.CodigoDepartamento;

Select F.Codigo, F.PrimeiroNome, F.CodigoDepartamento, D.Nome
from Funcionario as F
right join Departamento as D 
on D.Codigo = F.CodigoDepartamento;

/*Juntamos 2 tabelas em uma instrucoes de SELECT.*/

Select Codigo, Nome from Departamento;







