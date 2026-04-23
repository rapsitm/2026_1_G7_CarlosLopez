CREATE DATABASE db_colegio;
GO
USE db_colegio;
GO

CREATE TABLE [Estudiantes] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(150) NOT NULL,
	[Fecha] SMALLDATETIME NOT NULL,
);

CREATE TABLE [Asignaturas] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(150) NOT NULL
);

CREATE TABLE [Semestres] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Descripcion] NVARCHAR(150) NOT NULL
);

CREATE TABLE [Notas] (
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Estudiante] INT NOT NULL REFERENCES [Estudiantes]([Id]),
	[Asignatura] INT NOT NULL REFERENCES [Asignaturas]([Id]),
	[Semestre] INT NOT NULL REFERENCES [Semestres]([Id]),
	[Nota1] DECIMAL(10,2) NOT NULL,
	[Nota2] DECIMAL(10,2) NOT NULL,
	[Nota3] DECIMAL(10,2) NOT NULL,
	[Nota4] DECIMAL(10,2) NOT NULL,
	[Nota5] DECIMAL(10,2) NOT NULL,
	[NotaFinal] DECIMAL(10,2) NOT NULL,
	[Fecha] SMALLDATETIME NOT NULL,
);

INSERT INTO [Estudiantes] ([Nombre],[Fecha])
VALUES ('Pepito Perez', GETDATE());

INSERT INTO [Asignaturas] ([Nombre])
VALUES ('Calculo Basico');

INSERT INTO [Semestres] ([Descripcion])
VALUES ('2026-1');

INSERT INTO [Notas] ([Estudiante],[Asignatura],[Semestre],[Nota1],[Nota2],[Nota3],[Nota4],[Nota5],[NotaFinal],[Fecha])
VALUES (1, 1, 1, 4.5, 2.1, 0.7, 4.8, 3.4, 0.0, GETDATE());

SELECT * FROM [Notas];