USE esporte;

--[campeonato]
INSERT INTO [dbo].[campeonato]([nome],[ativo])
     VALUES ('Paulista',0);
INSERT INTO [dbo].[campeonato]([nome],[ativo])
     VALUES ('Libertadores',1);

--[equipe]

INSERT INTO [dbo].[equipe]([nome])
     VALUES ('São Paulo');
INSERT INTO [dbo].[equipe]([nome])
     VALUES ('Corinthians');
INSERT INTO [dbo].[equipe]([nome])
     VALUES ('Santos');
INSERT INTO [dbo].[equipe]([nome])
     VALUES ('Palmeiras');
INSERT INTO [dbo].[equipe]([nome])
     VALUES ('Ferroviária');
INSERT INTO [dbo].[equipe]([nome])
     VALUES ('The Strongest');
INSERT INTO [dbo].[equipe]([nome])
     VALUES ('Emelec');
INSERT INTO [dbo].[equipe]([nome])
     VALUES ('Flamengo');
INSERT INTO [dbo].[equipe]([nome])
     VALUES ('Internacional');
INSERT INTO [dbo].[equipe]([nome])
     VALUES ('Libertad');

--[partida]

INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (1,1,2,3,2,'2022-03-20','20:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (1,3,4,2,1,'2022-03-20','20:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (1,1,3,3,3,'2022-03-24','16:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (1,4,5,2,3,'2022-03-24','16:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (1,1,4,1,2,'2022-04-01','20:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (1,2,3,3,2,'2022-04-01','20:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (1,1,5,0,5,'2022-04-05','16:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (1,2,4,1,1,'2022-04-05','10:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (1,2,5,3,5,'2022-05-12','20:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (1,3,5,0,4,'2022-05-15','10:00');     
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,5,6,3,4,'2022-04-20','22:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,7,10,0,0,'2022-04-20','22:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,8,9,3,2,'2022-04-20','21:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,5,7,2,1,'2022-04-24','10:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,6,8,1,5,'2022-04-24','11:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,9,10,8,1,'2022-04-24','10:30');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,5,8,6,0,'2022-05-01','20:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,6,7,2,3,'2022-05-01','20:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,5,9,3,2,'2022-05-05','20:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,6,10,3,1,'2022-05-05','22:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,7,8,4,5,'2022-05-05','10:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,5,10,0,0,'2022-05-11','11:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,6,9,1,3,'2022-05-11','22:00');
INSERT INTO [dbo].[partida](idcampeonato,idequipecasa,idequipevisitante,golsequipecasa,golsequipevisitante,[data],hora)
     VALUES  (2,8,10,7,1,'2022-05-15','10:00');

SELECT *
  FROM dbo.[campeonato];

SELECT *
  FROM dbo.[equipe];

SELECT *
  FROM dbo.[partida];