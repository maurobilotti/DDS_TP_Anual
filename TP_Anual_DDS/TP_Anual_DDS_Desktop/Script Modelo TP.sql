CREATE TABLE Interesado(
	Id_Interesado int IDENTITY(1,1) NOT NULL,
	Nombre nvarchar(50) NOT NULL,
	Apellido nvarchar(50) NOT NULL,
	Fecha_Nacimiento datetime NULL,
	Mail nvarchar(50) NULL,
	Tipo_Jugador nvarchar(30) NULL,
	Posicion int NULL,
	Handicap int NULL,
	Criterio nvarchar(50) NULL,
	Id_Tipo_Jugador int NULL,
	PRIMARY KEY (Id_Interesado)
)

CREATE TABLE Partido(
	Id_Partido int IDENTITY(1,1) NOT NULL,
	Confirmado bit NULL,
	Fecha_Hora datetime NULL,
	PRIMARY KEY(Id_Partido)
) 

CREATE TABLE Partido_Interesado(
	Id_Partido int NOT NULL,
	Id_Interesado int NOT NULL,
	Baja bit NULL,
	CONSTRAINT Partido_Interesado_pk PRIMARY KEY(Id_Interesado,Id_Partido),
	foreign key(Id_Interesado)references Interesado(Id_Interesado),
	foreign key(Id_Partido)references Partido(Id_Partido)ON DELETE CASCADE 
) 

CREATE TABLE Calificaciones(
	Id_Calificacion int IDENTITY(1,1) NOT NULL,
	Id_Partido int NOT NULL,
	Descripcion nvarchar(50) NULL,
	Id_Jugador_Critico int NULL,
	Id_Jugador_Criticado int NULL,
	PRIMARY KEY (Id_Calificacion),
	foreign key(Id_Partido)references Partido(Id_Partido)ON DELETE CASCADE 
) 

CREATE TABLE Condiciones(
	Id_Condicion int IDENTITY(1,1) NOT NULL,
	Descripcion_Condicion nvarchar(100) NULL,
	PRIMARY KEY(Id_Condicion)
)

CREATE TABLE Condicion_Interesado(
	Id_Condicion int NOT NULL,
	Id_interesado int NOT NULL,
	CONSTRAINT [PK_Condicion_Interesado] PRIMARY KEY(Id_Condicion, Id_interesado),
	foreign key(Id_Condicion)references Condiciones(Id_Condicion),
	foreign key(Id_Interesado)references Interesado(Id_Interesado)ON DELETE CASCADE 
)

CREATE TABLE Amigos(
	Id_Interesado int  NOT NULL,
	Id_Amigo int IDENTITY(1,1) NOT NULL,
	PRIMARY KEY (Id_Amigo, Id_Interesado),
	foreign key(Id_Interesado)references Interesado(Id_Interesado)ON DELETE CASCADE 
) 

CREATE TABLE Usuarios(
	Id_Usuario int IDENTITY(1,1) NOT NULL,
	Nombre_Usuario nvarchar(50) NULL,
	Password_Usuario nvarchar(50) NULL,
	Usuario_Administrador [bit] NULL,
	CONSTRAINT PK_Usuarios PRIMARY KEY (Id_Usuario)
)

CREATE TABLE Denegacion(
	Id_Denegacion int IDENTITY(1,1) NOT NULL,
	Id_Interesado int NOT NULL,
	Id_Usuario int NOT NULL,
	Fecha_Denegacion datetime NULL,
	Descripcion_motivo_Denegacion nvarchar(250) NULL,
	Id_Admin int NULL,
	CONSTRAINT [PK_Denegacion] PRIMARY KEY(Id_Denegacion, Id_Interesado, Id_Usuario),
	foreign key(Id_Interesado)references Interesado(Id_Interesado),
	foreign key(Id_Usuario)references Usuarios(Id_Usuario) ON DELETE CASCADE 
)

CREATE TABLE Infracciones(
	Id_Infraccion int IDENTITY(1,1) NOT NULL,
	Descripcion_Infraccion nvarchar(50) NULL,
	Id_Usuario int NULL,
	CONSTRAINT [PK_Infracciones] PRIMARY KEY(Id_Infraccion),
	foreign key(Id_Usuario)references Usuarios(Id_Usuario)ON DELETE CASCADE
)


