insert into Carro (Id, Nome, Valor) 
	values (50,'Camaro', 25600); -- String � aspas simples.

insert into Carro (Id, Nome, Valor) 
	values (51,'Monza', 1500); -- String � aspas simples.

select * from Carro;

select Id, Nome, Valor from Carro;

delete from Carro where Nome = 'Camaro';

update Carro set Valor = 2500 where Nome = 'Monza';

select * from Carro where Nome like 'Za%'; -- Produ��o n�o utiliza "*".

sp_help Carro -- Mostra informa��es das colunas e tabela.









