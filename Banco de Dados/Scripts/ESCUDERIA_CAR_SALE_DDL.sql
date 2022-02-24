CREATE DATABASE ESCUDERIA_CAR_SALE;
GO 

USE ESCUDERIA_CAR_SALE;
GO

-- TIPO USUARIO
CREATE TABLE tipoUsuario
(
	idTipoUsuario SMALLINT PRIMARY KEY IDENTITY,
	titulo VARCHAR(50) UNIQUE NOT NULL
);
GO


-- USUARIO
CREATE TABLE usuario
(
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario SMALLINT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	nome VARCHAR(100) NOT NULL,
	email VARCHAR(255) UNIQUE NOT NULL,
	senha VARCHAR(255) NOT NULL CHECK ( len(senha) >= 8 ),
	notaComprador TINYINT NULL,
	notaVendedor TINYINT NULL,
	caminhoImagemUsuario VARCHAR(255) NULL
);
GO 

-- SITUACAO
CREATE TABLE situacao
(
	idSituacao SMALLINT PRIMARY KEY IDENTITY,
	tituloSituacao VARCHAR(50) DEFAULT ('Ativo') UNIQUE NOT NULL 
);
GO

-- MARCA
CREATE TABLE marca
(
	idMarca SMALLINT PRIMARY KEY IDENTITY,
	nome VARCHAR (50) NOT NULL
);
GO

-- MODELO
CREATE TABLE modelo
(
	idModelo INT PRIMARY KEY IDENTITY,
	idMarca SMALLINT FOREIGN KEY REFERENCES marca(idMarca),
	nomeMarca VARCHAR(100) NOT NULL
);
GO

-- FOTOS DO PRODUTO
CREATE TABLE fotosProduto
(
	idFotosProduto SMALLINT PRIMARY KEY IDENTITY(1,1),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	imgBinario VARBINARY(MAX) NOT NULL, -- TAMANHO MAXIMO POSSIVEL PARA ARMAZENAMENTO DE BINARIOS
	mimeType VARCHAR(30) NOT NULL, -- PARA SALVAR A EXTENS�O DO TIPO DE IMAGEM
	nomeArquivo VARCHAR(250) NOT NULL,
	dataInclusao DATETIME DEFAULT GETDATE() NULL
);
GO

-- PRODUTO
CREATE TABLE produto
(
	idProduto INT PRIMARY KEY IDENTITY,
	idFotosProduto SMALLINT FOREIGN KEY REFERENCES fotosProduto(idfotosProduto),
	idSituacao SMALLINT FOREIGN KEY REFERENCES situacao(idSituacao),
	idModelo INT FOREIGN KEY REFERENCES modelo(idModelo),
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	dataAnuncio DATETIME NOT NULL,
	descricao VARCHAR(300) NOT NULL,
	titulo VARCHAR(50) NOT NULL,
	ano VARCHAR(4) NOT NULL,
	km FLOAT NOT NULL,
	cor VARCHAR(50) NOT NULL
);
GO
















