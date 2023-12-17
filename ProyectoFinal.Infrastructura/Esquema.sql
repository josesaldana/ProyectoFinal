USE [ds8-proyectofinal]
GO

DROP TABLE IF EXISTS [Trabajos];
DROP TABLE IF EXISTS [Contratantes];
DROP TABLE IF EXISTS [Categorias];

CREATE TABLE [Categorias] (
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
);

INSERT INTO Categorias (Nombre) VALUES ('Conductor'),('Secretarias'),('Desarrollador de Software');

CREATE TABLE [Contratantes] (
	[Id] INT IDENTITY PRIMARY KEY,
	[Nombre] VARCHAR(250) NOT NULL,
	[Tipo] VARCHAR(50) NOT NULL,
	[Direccion] NVARCHAR(MAX),
	[Contacto] NVARCHAR(MAX),
	CHECK ([Tipo] IN ('Individuo', 'Empresa'))
);

INSERT INTO [Contratantes] ([Nombre], [Tipo], [Direccion], [Contacto])
VALUES ('Roberto Pérez', 'Individuo', 'Costa del Este', '6000-0000');

CREATE TABLE [Trabajos] (
	[Id] BIGINT IDENTITY PRIMARY KEY,
	[Titulo] VARCHAR(500) NOT NULL,
	[DescripcionCorta] NVARCHAR(MAX) NOT NULL,
	[DescripcionCompleta] NVARCHAR(MAX) NOT NULL,
	[DescripcionCompletaSanitizado] NVARCHAR(MAX) NOT NULL,
	[CategoriaId] INT NOT NULL,
	[ContratanteId] INT NOT NULL,
	[Ubicacion] VARCHAR(250),
	[Tipo] VARCHAR(20),
	[EntornoDeTrabajo] VARCHAR(20),
	[Abierto] BIT NOT NULL DEFAULT 1, 
	[FechaDePublicacion] DATE DEFAULT getdate(),
	FOREIGN KEY ([CategoriaId]) REFERENCES Categorias (Id),
	FOREIGN KEY ([ContratanteId]) REFERENCES [Contratantes] (Id),
	CHECK ([Tipo] IN ('Tiempo Completo', 'Tiempo Parcial', 'Por Contrato', 'Otro')),
	CHECK ([EntornoDeTrabajo] IN ('En Sitio', 'Remoto', 'Híbrido'))
);

INSERT INTO Trabajos ([Titulo], [DescripcionCorta], [DescripcionCompleta], [DescripcionCompletaSanitizado], [CategoriaId], [ContratanteId], [Ubicacion], [Tipo], [EntornoDeTrabajo])
VALUES (
	'Conductor', 
	'Conductor privado para persona discapacitada.', 
	'<p>Conductor privado para persona discapacitada. Salario: $800 mensuales.</p><h2>Requisitos</h2><ul><li><strong>Edad</strong>: +25 a&ntilde;os</li></ul><h2>Beneficios</h2><ul><li>Bono Anual</li></ul>', 
	'Conductor privado para persona discapacitada. Salario: $800 mensuales. Requisitos Edad: +25 a&ntilde;os Beneficios Bono Anual',
	1, 
	1,
	'Panamá',
	'Tiempo Parcial',
	'En Sitio'
);

INSERT INTO Trabajos ([Titulo], [DescripcionCorta], [DescripcionCompleta], [DescripcionCompletaSanitizado], [CategoriaId], [ContratanteId], [Ubicacion], [Tipo], [EntornoDeTrabajo])
VALUES (
	'Repostero Experimentado', 
	'Repostero Experimentado para reconocido comercio de repostería', 
	'<p>Necesitamos un reportero con un mímo de 5 años de experiencia para reconocida casa repostera. Salario: $800 mensuales.</p><h2>Requisitos</h2><ul><li><strong>Edad</strong>: +25 a&ntilde;os</li></ul><h2>Beneficios</h2><ul><li>Bono Anual</li></ul>', 
	'Necesitamos un reportero con un mímo de 5 años de experiencia para reconocida casa repostera. Salario: $800 mensuales. Requisitos Edad: +25 a&ntilde;os Beneficios Bono Anual',
	1, 
	1,
	'Panama Oeste',
	'Tiempo Completo',
	'En Sitio'
);

INSERT INTO Trabajos ([Titulo], [DescripcionCorta], [DescripcionCompleta], [DescripcionCompletaSanitizado], [CategoriaId], [ContratanteId], [Ubicacion], [Tipo], [EntornoDeTrabajo])
VALUES (
	'Conductor para Metrobus', 
	'Conductor de bus articulado', 
	'<p>Conductor de con experiencia en buses articulados. Salario: $1000 mensuales.</p><h2>Requisitos</h2><ul><li><strong>Edad</strong>: +25 a&ntilde;os</li></ul><h2>Beneficios</h2><ul><li>Bono Anual</li></ul>', 
	'Conductor de con experiencia en buses articulados. Salario: $1000 mensuales. Requisitos Edad: +25 a&ntilde;os Beneficios Bono Anual',
	1, 
	1,
	'Panamá',
	'Tiempo Completo',
	'En Sitio'
);
