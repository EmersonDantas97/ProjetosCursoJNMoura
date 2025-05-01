use [web-api];

create table Funcionario 
(
	Codigo int identity (1,1),	
	CodigoDepartamento int not null,
	PrimeiroNome Varchar(50) not null,
	SegundoNome Varchar(100),
	UltimoNome Varchar(100) not null,
	DataNascimento date not null,
	CPF char(11) not null, --
	RG Varchar(10) not null,
	Endereco Varchar(200),
	CEP Varchar(8),
	Cidade Varchar(50),
	Fone Varchar(12), -- 14988054131. Telefone e DDD juntos.
	Funcao Varchar(50) not null, --  
	Salario Decimal(7,2) not null
	constraint pk_Funcionario primary key (Codigo)
);

Select * from Funcionario;

/*
3) Descreva o comando para listar o nome e o dia do aniversário dos funcionários que nasceram no mês de agosto ordenados por dia de aniversário.
4) Descreva o comando para listar os nomes, endereços e fones dos funcionários que moram em Recife e que exerçam a função de Telefonista.
5) Descreva o comando para listar os nomes dos funcionários que trabalham no departamento Pessoal (Código 3).
6) Descreva o comando para listar o nome, o código do departamento e a função de todos os funcionários.
7) Descreva o comando para listar os códigos de departamentos dos funcionários que têm a função de Supervisor.
8) Descreva o comando para listar a quantidade de funcionários desta empresa.
9) Descreva o comando para listar a quantidade de funcionários por departamento.
10) Descreva o comando para listar a quantidade de funcionários por departamento ordenados por ordem decrescente de quantidade de funcionários.
11) Descreva o comando para listar o nome de todos os funcionários que não tenham segundo nome.
12) Descreve o comando para lista os funcionários com salários entre 1000 e 2000.13) Descreva o comando para listar os nomes dos funcionários que tenham a primeira letra igual a “C”.
14) Descreva o comando para listar os códigos de departamentos que possuem funcionários sem repetição.
15) Descreva o comando para excluir os funcionários do departamento 8.
16) Descreva o comando para alterar o salário do funcionário 10 para R$ 25000,96.
*/

delete from Funcionario;


-- 1) Descreva o comando para listar todos os dados de funcionários ordenados por cidade.
Select * from Funcionario order by Cidade;


-- 2) Descreva o comando para listar todos os dados dos funcionários que têm salário superior a R$ 1.000,00 ordenados por ordem decrescente de salário.
Select * from Funcionario where Salario > 1000.00 order by Salario desc;

-- 3) Descreva o comando para listar o nome e o dia do aniversário dos funcionários que nasceram no mês de agosto ordenados por dia de aniversário. 
select CONCAT(PrimeiroNome,' ',isnull(SegundoNome,''),' ',UltimoNome) AS NomeCompleto, DataNascimento 
from Funcionario 
where Month(DataNascimento)  = '08'
Order by Day(DataNascimento);



-- R Questao 17:
insert into Funcionario (CodigoDepartamento,PrimeiroNome,SegundoNome,UltimoNome,DataNascimento,CPF,RG,Endereco,CEP,Cidade,Fone,Funcao,Salario)
values (3,'Joaquim','Barbosa','Silva', '1978-04-23', '28798909877', '13908345X', 'Av. das nações 1234', '14356234', 'Campinas','998987899', 'Gerente', 12000);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) 
values (2, 'Mariana', 'Oliveira', 'Souza', '1985-09-14', '32165498700', '12345678A', 'Rua das Flores 45', '13045000', 'São Paulo', '988887777', 'Analista', 5800);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) 
values (1, 'Carlos', 'Eduardo', 'Menezes', '1990-01-20', '45678912300', '99887766B', 'Av. Paulista 900', '01311000', 'São Paulo', '999996666', 'Desenvolvedor', 7200);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) 
values (4, 'Luciana', 'Fernanda', 'Ramos', '1975-12-30', '78912345600', '11223344C', 'Rua do Comércio 789', '15015000', 'Ribeirão Preto', '988884444', 'Coordenadora', 9500);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) 
values (3, 'Renato', 'Luiz', 'Figueiredo', '1982-06-10', '98765432100', '55667788D', 'Travessa Central 10', '14020000', 'Campinas', '977776666', 'Supervisor', 8300);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) 
values (5, 'Amanda', 'Cristina', 'Silveira', '1993-11-03', '12398745600', '33445566E', 'Alameda das Palmeiras 67', '12033000', 'Taubaté', '988885555', 'Assistente', 4100);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) 
values (2, 'Felipe', 'André', 'Costa', '1991-08-15', '32178965400', '44556677F', 'Rua do Sol 321', '14035000', 'Campinas', '999998888', 'Técnico', 4800);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) 
values (4, 'Patrícia', 'Maria', 'Almeida', '1987-08-03', '98732165400', '77889900G', 'Rua São Jorge 58', '13098000', 'Jundiaí', '977775555', 'Secretária', 3900);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) 
values (1, 'Ricardo', 'Henrique', 'Teixeira', '1979-08-28', '65412398700', '22334455H', 'Av. Rio Branco 876', '01004000', 'São Paulo', '966667777', 'Consultor', 9100);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) 
values (3, 'Sueli', 'Marta', 'Pereira', '1986-05-12', '34567891234', '12312312A', 'Rua Imperial 456', '50020000', 'Recife', '988887777', 'Telefonista', 3200);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario) 
values (2, 'José', 'Carlos', 'Nascimento', '1994-10-25', '87654321987', '32132132B', 'Av. Conde da Boa Vista 789', '50060000', 'Recife', '999996666', 'Telefonista', 3400);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (1, 'Bruno', NULL, 'Lima', '1990-02-14', '11122233344', '11223344X', 'Rua das Laranjeiras 123', '12345000', 'Curitiba', '999998888', 'Designer', 5400);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (5, 'Elisa', NULL, 'Mendes', '1983-07-19', '55566677788', '99887766Y', 'Av. Central 456', '45678000', 'Salvador', '988887777', 'Recepcionista', 3600);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (3, 'Roberto', NULL, 'Ferraz', '1975-03-05', '99988877766', '44556677Z', 'Travessa Azul 89', '78900000', 'Belo Horizonte', '977776666', 'Motorista', 4200);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (2, 'Ana', 'Luiza', 'Rocha', '1999-06-11', '12345678001', '11223344A', 'Rua da Liberdade 100', '60150000', 'Fortaleza', '988887777', 'Auxiliar', 1850);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (4, 'Carlos', 'Eduardo', 'Farias', '2001-11-22', '22334455002', '22334455B', 'Av. Getúlio Vargas 456', '74810000', 'Goiânia', '999996666', 'Estagiário', 1200);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (1, 'Luciana', 'Beatriz', 'Moreira', '1995-03-09', '33445566003', '33445566C', 'Rua das Palmeiras 89', '69050000', 'Manaus', '988887777', 'Telefonista', 1700);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (3, 'Rafael', 'Silva', 'Pinto', '1988-12-30', '44556677004', '44556677D', 'Travessa do Norte 12', '40020000', 'Salvador', '999998888', 'Atendente', 1950);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (5, 'Jéssica', 'Fernanda', 'Souza', '1992-09-17', '55667788005', '55667788E', 'Rua da Aurora 333', '50050000', 'Recife', '988889999', 'Recepcionista', 1600);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (8, 'Eduardo', 'Luiz', 'Freitas', '1987-06-18', '11122333445', '12345678X', 'Rua das Hortênsias 45', '78000000', 'Cuiabá', '999998888', 'Analista', 4200);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (8, 'Carla', 'Patrícia', 'Vieira', '1992-03-22', '22233444556', '23456789Y', 'Av. Atlântica 123', '76801000', 'Porto Velho', '988887766', 'Supervisora', 5100);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (8, 'Renato', 'José', 'Amaral', '1983-09-10', '33344555667', '34567890Z', 'Rua Amazonas 678', '69301000', 'Boa Vista', '997776666', 'Coordenador', 6000);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (8, 'Juliana', 'Cristina', 'Santos', '1990-08-03', '44455666778', '45678901W', 'Rua Rio Branco 89', '64001000', 'Teresina', '996665544', 'Secretária', 3500);

insert into Funcionario (CodigoDepartamento, PrimeiroNome, SegundoNome, UltimoNome, DataNascimento, CPF, RG, Endereco, CEP, Cidade, Fone, Funcao, Salario)
values (8, 'Alex', 'Marcos', 'Lopes', '1985-12-15', '55566777889', '56789012V', 'Av. Beira Mar 456', '65000000', 'São Luís', '998887755', 'Técnico', 3800);


/*
	Char constante.
	Varchar e Char.
	Varchar não aceita caracteres unicode. 
	Usar nvarchar, para tipo de coluna, para algo universal. Tem a variação maior.
*/

