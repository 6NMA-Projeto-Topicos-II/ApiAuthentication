 IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'DbCampusHub')
BEGIN
    CREATE DATABASE DbCampusHub
    PRINT 'Banco de dados criado com sucesso.'
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'tbl_Usuarios')
BEGIN

	USE DbCampusHub

    CREATE TABLE DbCampusHub.dbo.tbl_Usuarios
    (
		Matricula VARCHAR(255) PRIMARY KEY ,
        Nome VARCHAR(255) NOT NULL,
		Sobrenome VARCHAR(255) NOT NULL,
		Email VARCHAR(255),
		Senha VARCHAR(255) NOT NULL,
		DataCriacao VARCHAR(255) NOT NULL
    );

    PRINT 'Tabela criada com sucesso.'
END
