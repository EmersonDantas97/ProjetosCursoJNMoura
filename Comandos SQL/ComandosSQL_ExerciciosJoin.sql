/****************************************************************************/

Select * from cliente c where c.Id = 6;				-- Cliente 4
Select * from venda v where v.idCliente = 6;		-- Descobrindo qual compra o cliente 4 fez.
Select * from vendaproduto v where v.idproduto = 5;	-- Descobrindo quais itens tem na compra
Select * from produto p where p.id in (5);			-- Encontrando qual produtos foram comprados
Select * from categoria ct where ct.Id in (2,100);	-- Descobrindo a categoria

/****************************************************************************/

SELECT * FROM venda v
LEFT JOIN cliente c				ON v.idcliente = c.id
INNER JOIN vendaproduto vp		ON vp.idVenda =	v.Id
INNER JOIN produto p			ON vp.idproduto = p.Id
INNER JOIN categoria cat		ON p.idcategoria = cat.id
INNER JOIN vendastatus vs		ON vs.id = v.idstatus 
WHERE v.id = 5;

/****************************************************************************/

Select * from cliente;

use comercio;

-- SELECIONE O NOME DOS CLIENTES, CUJO NOME COMECE COM A LETRA 'G'.
Select nome 
from cliente 
where nome like 'G%';

-- SELECIONE TODOS OS DADOS DOS CLIENTES DO SEXO FEMININO.
Select * 
from cliente 
where sexo = 'F';

-- SELECIONE TODOS OS DADOS DOS PRODUTOS QUE ESTEJAM COM O ESTOQUE ATUAL ABAIXO DO ESTOQUE MINIMO.
Select *
From produto p
inner join categoria cat on p.idcategoria = cat.id
Where p.qtdeestoqueatual < p.qtdeestoqueminimo;

-- SELECIONE TODOS OS DADOS DOS CLIENTES QUE NASCERAM NO MES DE JULHO.
Select * 
From cliente c 
Where month(dtnascimento) = 07;

Select * 
From cliente c 
Where dtnascimento like '%-07-%';

-- SELECIONE TODOS OS DADOS DOS CLIENTES QUE NASCERAM NOS MESES 08, 09 E 10.
Select * 
From cliente c 
Where month(dtnascimento) in (08, 09, 10);

Select * 
From cliente c 
Where dtnascimento like '%-08-%' 
or dtnascimento like '%-09-%' 
or dtnascimento like '%-10-%';

-- SELECIONAR TODOS OS DADOS DAS VENDAS (INCLUSIVE SEUS PRODUTOS) REALIZADAS (finalizadas) PARA O CLIENTE 'Aroldo Rodrigues'.
SELECT * FROM venda v
INNER JOIN cliente c			ON v.idcliente = c.id
INNER JOIN vendaproduto vp		ON vp.idVenda =	v.Id
INNER JOIN produto p			ON vp.idproduto = p.Id
Where c.nome = 'Aroldo Rodrigues' 
And v.idstatus = 2;

-- SELECIONAR O ID, DT DAS VENDAS DOS CLIENTES DO SEXO MASCULINO QUE FORAM REALIZADAS (finalizadas) NO ANO DE 2025 ORDENADAS POR DATA DE VENDA (CRESCENTE).
SELECT v.id, v.Dt FROM venda v
INNER JOIN cliente c			ON v.idcliente = c.id
Where c.sexo = 'M' 
And v.idstatus = 2 
And Year(v.dt) = 2025 
Order by v.dt asc;

-- SELECIONE O ID, DESCRICAO E VRUNITARIO DOS PRODUTOS QUE FORAM VENDIDOS PARA CLIENTES DO SEXO MASCULINO NO ANO DE 2025, CONSIDERANDO SOMENTE VENDAS FINALIZADAS. 
SELECT p.id, p.descricao, p.vrunitario FROM venda v
INNER JOIN cliente c			ON v.idcliente = c.id -- 
INNER JOIN vendaproduto vp		ON vp.idVenda =	v.Id
INNER JOIN produto p			ON vp.idproduto = p.Id
Where c.sexo = 'M'  
And Year(v.dt) = 2025 
And v.idStatus = 2;

-- VALOR TOTAL DE CADA VENDA QUE NÃO FOI FINALIZADA.
Select vp.idvenda, sum(qtde * vr) as SomaVenda FROM venda v
INNER JOIN vendaproduto vp		ON vp.idVenda =	v.Id
INNER JOIN produto p			ON vp.idproduto = p.Id
Where v.idStatus != 2
Group by Idvenda;

-- Pegando produtos que não tiveram vendas utilizado not exists. CUIDADO! Se tiver nulo, dá problema na consulta.
select * from produto p
where not exists (
select vp.idproduto 
from vendaproduto vp 
where vp.Idproduto = p.id);

-- Pegando produtos que não tiveram vendas utilizado subselect.
select * from produto p
where p.id not in (select vp.idproduto from vendaproduto vp);

