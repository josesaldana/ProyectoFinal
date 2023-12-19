USE [ds8-proyectofinal]
GO

DROP TABLE IF EXISTS [Aplicaciones]
DROP TABLE IF EXISTS [Trabajos];
DROP TABLE IF EXISTS [Contratantes];
DROP TABLE IF EXISTS [Categorias];
DROP TABLE IF EXISTS [Usuarios];

CREATE TABLE [Categorias] (
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
);

INSERT INTO Categorias (Nombre) VALUES 
		('Conductores'),('Secretarias'), ('Panaderos'), ('Electricistas'),
		('Soldadores'),('Albañiles'),('Plomeros'), ('Empleada Doméstica'), 
		('Carpinteros'), ('Cajeros'), ('Sastres'), ('Policías'), ('Barberos'),
		('Desarrollador de Software'), ('Periodista'), ('Ingeniero'), ('Profesor');

CREATE TABLE [Contratantes] (
	[Id] INT IDENTITY PRIMARY KEY,
	[Nombre] VARCHAR(250) NOT NULL,
	[Tipo] VARCHAR(50) NOT NULL,
	[Direccion] NVARCHAR(MAX),
	[Contacto] NVARCHAR(MAX),
	CHECK ([Tipo] IN ('Individuo', 'Empresa'))
);

INSERT INTO [Contratantes] ([Nombre], [Tipo], [Direccion], [Contacto]) VALUES 
	('Roberto Pérez', 'Individuo', 'Costa del Este', '6000-0000'),
	('La Casa Rendonda', 'Empresa', 'El Dorado', '230-0000');

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
	'Conductor privado para persona discapacitada.  Debe llevar a la persona a diligencias 4 veces por semana en horas.', 
	'<p>Conductor privado para persona discapacitada.  Debe llevar a la persona a diligencias 4 veces por semana en horas de la ma&ntilde;ana.</p><h4 style="color: white">Salario</h4><p>$800 mensuales.</p><h4 style="color: white">Requisitos</h4><ul><li><strong style="color: white">Edad</strong style="color: white">: +25 a&ntilde;os</li></ul><h4 style="color: white">Beneficios</h4><ul><li>Bono Anual</li><li>Seguro M&eacute;dico</li><li>Almuerzo al regresar</li></ul>', 
	'Conductor privado para persona discapacitada. Salario: $800 mensuales. Requisitos Edad: +30 a&ntilde;os Beneficios Bono Anual',
	(SELECT TOP 1 Id FROM Categorias WHERE [Nombre] = 'Conductores'),
	1,
	'Panamá',
	'Tiempo Parcial',
	'En Sitio'
);

INSERT INTO Trabajos ([Titulo], [DescripcionCorta], [DescripcionCompleta], [DescripcionCompletaSanitizado], [CategoriaId], [ContratanteId], [Ubicacion], [Tipo], [EntornoDeTrabajo])
VALUES (
	'Repostero Experimentado', 
	'Repostero Experimentado para reconocido comercio de repostería', 
	'<p>Necesitamos un reportero con un mímo de 5 años de experiencia para reconocida casa repostera.</p><h4 style="color: white">Salario</h4><p>$800 mensuales.</p><h4 style="color: white">Requisitos</h4><ul><li><strong style="color: white">Edad</strong>: +25 a&ntilde;os</li></ul><h4 style="color: white">Beneficios</h4><ul><li>Bono Anual</li><li>Seguro M&eacute;dico</li></ul>', 
	'Necesitamos un reportero con un mímo de 5 años de experiencia para reconocida casa repostera. Salario: $800 mensuales. Requisitos Edad: +25 a&ntilde;os Beneficios Bono Anual',
	(SELECT TOP 1 Id FROM Categorias WHERE [Nombre] = 'Panaderos'), 
	2,
	'Panama Oeste',
	'Tiempo Completo',
	'En Sitio'
);

INSERT INTO Trabajos ([Titulo], [DescripcionCorta], [DescripcionCompleta], [DescripcionCompletaSanitizado], [CategoriaId], [ContratanteId], [Ubicacion], [Tipo], [EntornoDeTrabajo])
VALUES (
	'Conductor para Metrobus', 
	'Conductor de bus articulado', 
	'<p>Conductor de con experiencia en buses articulados.</p><h4 style="color: white">Salario</h4><p>$1000 mensuales.</p><h4 style="color: white">Requisitos</h4><ul><li><strong style="color: white">Edad</strong>: +25 a&ntilde;os</li></ul><h4 style="color: white">Beneficios</h4><ul><li>Bono Anual</li><li>Seguro M&eacute;dico</li></ul>', 
	'Conductor de con experiencia en buses articulados. Salario: $1000 mensuales. Requisitos Edad: +25 a&ntilde;os Beneficios Bono Anual',
	(SELECT TOP 1 Id FROM Categorias WHERE [Nombre] = 'Conductores'), 
	1,
	'Panamá',
	'Tiempo Completo',
	'En Sitio'
);

INSERT INTO Trabajos ([Titulo], [DescripcionCorta], [DescripcionCompleta], [DescripcionCompletaSanitizado], [CategoriaId], [ContratanteId], [Ubicacion], [Tipo], [EntornoDeTrabajo])
VALUES (
	'Desarrollador de Software con Python', 
	'Desarrollador de Software con Python para sistema legacy', 
	'<p>Desarrollador de Software con Visual Basic para sistema legacy.</p><h4 style="color: white">Salario</h4><p>$3500 mensuales.</p><h4 style="color: white">Requisitos</h4><ul><li><strong style="color: white">Idioma</strong>: Ingl&eacute;s</li></ul><h4 style="color: white">Beneficios</h4><ul><li>Bono Anual</li><li>Seguro M&eacute;dico</li><li>Equipo</li><li>Beca de Estudio</li></ul>', 
	'Desarrollador de Software con Visual Basic para sistema legacy. Salario: $3500 mensuales. Requisitos Idioma: Inglés Beneficios Bono Anual Equipo Beca de Estudio',
	(SELECT TOP 1 Id FROM Categorias WHERE [Nombre] = 'Desarrollador de Software'), 
	1,
	'Estados Unidos',
	'Tiempo Completo',
	'Remoto'
);


CREATE TABLE Usuarios (
		[Id] BIGINT NOT NULL IDENTITY PRIMARY KEY,
		[Nombre] VARCHAR(250) NOT NULL,
		[Apellido] VARCHAR(250) NOT NULL,
		[Edad] INT,
		[FechaDeNacimiento] DATE,
		[Telefono] VARCHAR(50) NOT NULL,
		[Email] VARCHAR(250),
		[Discriminador] VARCHAR(50) NOT NULL,
		UNIQUE ([Email])
);

CREATE TABLE Aplicaciones (
		[Id] BIGINT NOT NULL IDENTITY PRIMARY KEY,
		[AplicanteId] BIGINT NOT NULL,
		[TrabajoId] BIGINT NOT NULL,
		[Fecha] DATETIME DEFAULT getdate(),
		[Educacion] NVARCHAR(MAX) NOT NULL,
		[Habilidades] NVARCHAR(MAX) NOT NULL,
		[Experiencia] NVARCHAR(MAX) NOT NULL,
		[HojaDeVida] VARCHAR(1024),
		FOREIGN KEY ([TrabajoId]) REFERENCES [Trabajos] ([Id]),
		FOREIGN KEY ([AplicanteId]) REFERENCES [Usuarios] ([Id])
);
