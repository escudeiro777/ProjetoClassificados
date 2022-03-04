USE ESCUDERIA_CAR_SALE;
GO

INSERT INTO tipoUsuario(titulo)
VALUES ('comum'),('admin');
GO

INSERT INTO usuario (nome, email, senha, idTipoUsuario)
VALUES ('murillo', 'murillo@email.com', '12345678', 1),
('putin', 'putin@russia.com', '12345678', 2);
GO

INSERT INTO cor (nomeCor)
VALUES ('vermelho'),('azul'),('branco'),('prata'),
('preto'),('amarelo'),('verde'),('laranja');
GO

INSERT INTO estado (nomeEstado)
VALUES ('Acre'),('Alagoas'),('Amapa'),('Amazonas'),('Bahia'),('Ceara'),
('Espirito Santo'),('Goias'),('Maranhao'),('Mato Grosso'),('Mato Grosso do Sul'),('Minas Gerais'),
('Para'),('Paraiba'),('Parana'),('Pernambuco'),('Piaui'),('Rio de Janeiro'),
('Rio Grande do Norte'),('Rio Grande do Sul'),('Rondonia'),('Roraima'),('Santa Catarina'),('Sao Paulo'),
('Sergipe'),('Tocantins'),('Distrito Federal');
GO

INSERT INTO situacao (tituloSituacao)
VALUES ('ativo'),('bloqueado'),('em negociacao'),('finalizado');
GO

INSERT INTO marca (nomeMarca)
VALUES ('fiat'),('volkswagen'),('chevrolet'),('hyundai'),('toyota'),
('jeep'),('renault'),('honda'),('nissan'),('ford'),
('peugeot'),('citroen'),('audi');
GO

INSERT INTO modelo (nomeModelo, descricao, idMarca)
VALUES ('hb20','1.3 flex',4),('argo','1.0 gasolina',1),('onix','1.4 flexpower',3),
('renegade','2.0 turbo',6),('mobi','1.3 econoflex',1),('gol','1.6 power',2),
('creta','1.4 totalflex',4),('compass','1.8 diesel',6),('kwid','1.3 alcool',7),
('t-cross','1.8 power',2),('classic','1.0 mpfi',3),('palio','1.0 fire',1),
('corolla','2.0 turbo',5),('hr-v','1.6 flex',8),('ka','1.4 flex',10);
GO

--delete from usuario
--where idUsuario = 9

--select * from marca
--select * from modelo
--select * from usuario









