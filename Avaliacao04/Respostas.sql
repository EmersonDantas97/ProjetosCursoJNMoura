-- 01) Escreva a instrução para criar a base de dados “esporte”.
create database esporte;
go

use esporte;

-- 02) Escreva a instrução para criar a tabela “campeonato”.
create table campeonato 
(
	id int identity(1,1),
	nome varchar(50) not null,
	ativo bit not null,
	constraint pk_campeonato primary key (id)
);
go

-- 03) Escreva a instrução para criar a tabela “equipe”. 
create table equipe 
(
	id int identity(1,1),
	nome varchar(50) not null,
	constraint pk_equipe primary key (id)
);
go

-- 04) Escreva a instrução para criar a tabela “partida”. Não se esqueça das chaves estrangeiras.
create table partida 
(
	id int identity(1,1),
	idcampeonato int not null,
	idequipecasa int not null,
	idequipevisitante int not null,
	golsequipecasa int not null,
	golsequipevisitante int not null,
	data date not null,
	hora time(0) not null,
	constraint pk_partida primary key (id),
	foreign key (idcampeonato) references campeonato(id),
	foreign key (idequipecasa) references equipe(id),
	foreign key (idequipevisitante) references equipe(id)
);
go

-- 05) Escreva a instrução para inserir a partida 25 no banco de dados.
insert into partida (idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,data,hora)
Values (2,7,9,4,1,'2022-05-15','11:00:00');

-- 06) Escreva a instrução para alterar o placar da partida 6 para oito gols do time da casa e dois gols do time visitante. 
update partida 
set golsequipecasa = 8, 
golsequipevisitante = 2 
where id = 6;

-- 07) Escreva a instrução para excluir os campeonatos inativos.
DELETE FROM campeonato WHERE ativo = 0;

-- 08) A instrução da questão 7 causará algum erro? Explique sua reposta.
-- RESPOSTA: Sim, pois a coluna "id" da tabela "campeonato", é utilizada como chave estrageira na tabela "partida". Sendo assim, caso eu queira excluir os registros inativos da tabela "campeonato", antes eu preciso excluir todos os registros que tenha em outras tabelas que tenham vinculo de chave estrangeira com a coluna "id" da tabela "campeonato".

-- 09) Sugira uma nova chave primária para a tabela Partida e explique o motivo da sua sugestão. 
-- RESPOSTA: Tendo em vista que o principal objetivo da chave primária é criar uma restrição de identidade, pode ser criado uma chave primária composta, tendo as colunas "idequipecasa" e "data" como conteúdo. O motivo da sugestão é que é impossível um time (que está jogando em casa) jogar mais que um jogo por dia (Exemplo: Corinthians ter 2 jogos no dia 15/03/2022). Desta maneira, cada linha de registro da tabela, é um registro individual, sem repetições, se estivermos considendo esta sugestão de primary key.

-- 10) Escreva a instrução para selecionar todos os dados dos campeonatos ativos.
Select * from campeonato where ativo = 1;

-- 11) Escreva a instrução para selecionar todos os dados das equipes que tenham a letra 'P' no nome.
Select * from equipe where nome like '%P%';

-- 12) Escreva a instrução para selecionar os nomes das equipes que possuem Id entre 3 e 6.
Select nome from equipe where id between 3 and 6;

-- 13) Escreva a instrução para selecionar as datas e horas das partidas e os nomes das equipes que jogaram em casa no mês de abril de 2022. 
select p.data, p.hora, e.nome from partida p 
inner join equipe e on p.idequipecasa = e.id 
Where month(p.data) = 4 
and year(p.data) = 2022;

-- 14) Escreva a instrução para selecionar os nomes das equipes visitantes que jogaram em 15/05/2022. 
Select e.nome from partida p
inner join equipe e 
on p.idequipevisitante = e.id
Where p.data = '2022-05-15';

-- 15) Escreva a instrução para selecionar as datas das partidas, os números de gols feitos em casa e os nomes das equipes que jogaram em casa e marcaram mais de três gols na data de 24/04/2022.
select p.data, p.golsequipecasa, e.nome from partida p 
inner join equipe e
on p.idequipecasa = e.id
Where p.data = '2022-04-24' 
and p.golsequipecasa > 3;

-- 16) Escreva a instrução para selecionar os nomes das equipes que perderam partidas em casa. Devemos utilizar o “Distinct” neste comando? Por quê? 
Select DISTINCT e.nome from partida p
inner join equipe e
on p.idequipecasa = e.id
Where p.golsequipevisitante > p.golsequipecasa;

-- RESPOSTA: Sim, pois vem nome duplicado, fato que indicia que o mesmo time perdeu mais que uma partida em casa. Temos que utilizar o distinct, remover o nome que vier em multiplicidade.

-- 17)  Escreva a instrução para selecionar os nomes das equipes que ganharam partidas fora de casa.
select distinct e.nome from partida p 
inner join equipe e 
on p.idequipevisitante = e.id 
where p.golsequipevisitante > p.golsequipecasa;

-- 18) Escreva a instrução para contar o número de jogos realizados pela “Ferroviária” como visitante. 
Select count(p.idequipevisitante) as JogosRealizados from partida p
inner join equipe e
on p.idequipevisitante = e.id 
Where e.nome = 'Ferroviária';

-- 19) Escreva a instrução para selecionar o nome das equipes que não jogaram partidas de futebol.
Select nome from equipe e 
where not exists (select idequipevisitante from partida pv where pv.idequipevisitante = e.id) 
and not exists (select idequipecasa from partida pc where pc.idequipecasa = e.id);

-- 20) Qual a importância de visualizar o plano de execução das instruções.
-- RESPOSTA: Pelo plano de execução podemos verificar as informações relacionadas à execução do script, sendo elas: O custo da consulta, quantidades de linhas afetadas em cada nó, custo estimado de cpu em cada nó, linhas afetadas e etc. Em análise destas informações, podemos comparar versões diferentes da mesma query para escolha da menos custosa, entender o comportamento do otimizador de consultas, identificar problemas de performance.