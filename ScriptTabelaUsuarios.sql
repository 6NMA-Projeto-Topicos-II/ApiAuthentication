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
        ID INT PRIMARY KEY IDENTITY(1,1),
        Nome NVARCHAR(255) NOT NULL,
		Sobrenome NVARCHAR(255) NOT NULL,
		Matricula NVARCHAR(255) NOT NULL,
		Email NVARCHAR(255),
		Senha NVARCHAR(255) NOT NULL,
		DataCriacao DATETIME NOT NULL
    );
    PRINT 'Tabela criada com sucesso.'
END