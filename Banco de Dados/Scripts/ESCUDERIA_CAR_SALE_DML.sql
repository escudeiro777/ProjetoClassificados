USE ESCUDERIA_CAR_SALE;

INSERT INTO tipoUsuario(titulo)
VALUES ('admin'),('comum')
GO

INSERT INTO usuario(idTipoUsuario, nome, email, senha, notaComprador, notaVendedor)
VALUES (1, 'Adm', 'adm@email.com', '12345678', 3, 3),
(2, 'UsuarioComum', 'comum@email.com', '12345678', 3, 3)
GO

select * from tipoUsuario
select * from usuario

