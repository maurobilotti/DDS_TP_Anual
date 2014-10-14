CREATE TABLE Usuario(
	Id_Usuario int IDENTITY(1,1) NOT NULL,	
	Nombre_Usuario nvarchar(50) NULL,
	Password_Usuario nvarchar(50) NULL,
	Usuario_Administrador [bit] NULL,
	CONSTRAINT PK_Usuarios PRIMARY KEY (Id_Usuario)
)

CREATE TABLE Interesado(
	Id_Interesado int IDENTITY(1,1) NOT NULL,
	Id_Usuario int NOT NULL,
	Nombre nvarchar(50) NOT NULL,
	Apellido nvarchar(50) NOT NULL,
	Edad int NULL,
	Mail nvarchar(50) NULL,
	Tipo_Jugador nvarchar(50) NULL,
	Posicion int NULL,
	Handicap int NULL,
	Criterio nvarchar(50) NULL,	
	CantPartidosJugados int NOT NULL,
	PRIMARY KEY (Id_Interesado),
	foreign key(Id_Usuario)references Usuario(Id_Usuario),
)

CREATE TABLE Partido(
	Id_Partido int IDENTITY(1,1) NOT NULL,
	Lugar nvarchar(50) NOT NULL,	
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

CREATE TABLE Calificacion(
	Id_Calificacion int IDENTITY(1,1) NOT NULL,
	Id_Partido int NOT NULL,
	Descripcion nvarchar(50) NULL,
	Id_Jugador_Critico int NULL,
	Id_Jugador_Criticado int NULL,
	PRIMARY KEY (Id_Calificacion),
	foreign key(Id_Partido)references Partido(Id_Partido)ON DELETE CASCADE 
) 

CREATE TABLE Condicion(
	Id_Condicion int IDENTITY(1,1) NOT NULL,
	Descripcion_Condicion nvarchar(50) NULL,
	PRIMARY KEY(Id_Condicion)
)

CREATE TABLE Condicion_Interesado(
	Id_Condicion int NOT NULL,
	Id_interesado int NOT NULL,
	CONSTRAINT [PK_Condicion_Interesado] PRIMARY KEY(Id_Condicion, Id_interesado),
	foreign key(Id_Condicion)references Condicion(Id_Condicion),
	foreign key(Id_Interesado)references Interesado(Id_Interesado)ON DELETE CASCADE 
)

CREATE TABLE Amigos(
	Id_Interesado int  NOT NULL,
	Id_Amigo int IDENTITY(1,1) NOT NULL,
	PRIMARY KEY (Id_Amigo, Id_Interesado),
	foreign key(Id_Interesado)references Interesado(Id_Interesado)ON DELETE CASCADE 
) 


CREATE TABLE Denegacion(
	Id_Denegacion int IDENTITY(1,1) NOT NULL,
	Id_Interesado int NOT NULL,
	Id_Usuario int NOT NULL,
	Fecha_Denegacion datetime NULL,
	Descripcion_motivo_Denegacion nvarchar(50) NULL,
	Id_Admin int NULL,
	CONSTRAINT [PK_Denegacion] PRIMARY KEY(Id_Denegacion, Id_Interesado, Id_Usuario),
	foreign key(Id_Interesado)references Interesado(Id_Interesado),
	foreign key(Id_Usuario)references Usuario(Id_Usuario) ON DELETE CASCADE 
)

CREATE TABLE Infraccion(
	Id_Infraccion int IDENTITY(1,1) NOT NULL,
	Descripcion_Infraccion nvarchar(50) NULL,
	Id_Usuario int NULL,
	CONSTRAINT [PK_Infracciones] PRIMARY KEY(Id_Infraccion),
	foreign key(Id_Usuario)references Usuario(Id_Usuario)ON DELETE CASCADE
)
GO


--STORED PROCEDURES
CREATE PROCEDURE [dbo].[Partido_UI](
	@Lugar nvarchar(50),
	@Confirmado bit,
	@Fecha_Hora datetime
)
AS 
BEGIN
	SET NOCOUNT ON
    INSERT INTO Partido VALUES  (@Lugar,@Confirmado,@Fecha_Hora)
END
GO

CREATE PROCEDURE [dbo].[Usuario_UI](
@Nombre_Usuario nvarchar(50),
@Password_Usuario nvarchar(50),
@Usuario_Administrador bit
)
AS
BEGIN
	SET NOCOUNT ON
	IF(EXISTS(SELECT 1 FROM Usuario WHERE Nombre_Usuario = @Nombre_Usuario))
	BEGIN
		UPDATE dbo.Usuario 
		SET Nombre_Usuario = @Nombre_Usuario,
		Password_Usuario = @Password_Usuario,
		Usuario_Administrador = @Usuario_Administrador
	END
	ELSE
	BEGIN
		INSERT INTO dbo.Usuario VALUES (@Nombre_Usuario,@Password_Usuario,@Usuario_Administrador)	
	END
END
GO

CREATE PROCEDURE [dbo].Interesado_UI(
	@Id_Usuario int,
    @Nombre nvarchar(50),
    @Apellido nvarchar(50),
    @Edad int,
    @Mail nvarchar(50),
    @Tipo_Jugador nvarchar(50),
    @Posicion int,
    @Handicap int,
    @Criterio nvarchar(50)
)
AS
BEGIN
	SET NOCOUNT ON
	IF(EXISTS(SELECT 1 FROM Interesado WHERE @Id_Usuario = Id_Usuario))
	BEGIN
		UPDATE Interesado
		SET
		Id_Usuario = @Id_Usuario,
		Nombre = @Nombre,
		Apellido = @Apellido,
		Edad = @Edad,
		Mail = @Mail,
		Tipo_Jugador = @Tipo_Jugador,
		Posicion = @Posicion,
		Handicap = @Handicap,
		Criterio = @Criterio,
		CantPartidosJugados = 0
	END
	ELSE
	BEGIN
		INSERT INTO dbo.Interesado 
		VALUES (@Id_Usuario,@Nombre,@Apellido,@Edad,@Mail,@Tipo_Jugador,@Posicion,@Handicap,@Criterio, 0)	
	END
END
GO


CREATE PROCEDURE Usuario_L
AS
BEGIN
	SELECT 
	U.Id_Usuario AS Id_Usuario,
	U.Nombre_Usuario,
	U.Password_Usuario,
	I.Nombre,
	I.Apellido,
	I.Edad,
	I.Mail,
	I.Posicion,
	I.Handicap,
	I.CantPartidosJugados,
	I.Tipo_Jugador
	FROM Usuario U
	INNER JOIN Interesado I ON U.Id_Usuario = I.Id_Usuario
END
GO

CREATE PROCEDURE ObtenerJugadoresMalos
AS
BEGIN
	SET NOCOUNT ON
	SELECT 
		Id_Interesado,
		Id_Usuario,
		Nombre,		
		Apellido,
		Edad,
		Posicion,
		Mail,
		Handicap,
		CantPartidosJugados
	FROM INTERESADO WHERE Handicap < 5
END
GO

CREATE PROCEDURE UsuarioInteresado_Obtener(
	@Nombre_Usuario nvarchar(50),
	@Password_Usuario nvarchar(50)
)
AS
BEGIN
	SELECT Nombre_Usuario,
		Password_Usuario,
		U.Id_Usuario,
		Nombre,
		Apellido,
		Edad,
		Mail,
		Tipo_Jugador,
		Posicion,
		Handicap,
		Criterio,
		CantPartidosJugados
		FROM Usuario U
		INNER JOIN Interesado I ON I.Id_Usuario = U.Id_Usuario
		WHERE Nombre_Usuario = @Nombre_Usuario AND
			  Password_Usuario = @Password_Usuario 
	
END
GO

CREATE PROCEDURE Partido_Interesado_UI(
	@Id_Partido int,
	@Id_Interesado int,	
	@Baja bit = 0
)
AS
BEGIN 
	SET NOCOUNT ON
	IF(EXISTS(SELECT 1 FROM Partido_Interesado WHERE Id_Partido = @Id_Partido AND Id_Interesado = @Id_Interesado))
	BEGIN
		UPDATE Partido_Interesado
		SET Baja = @Baja
		WHERE Id_Partido = @Id_Partido AND Id_Interesado = @Id_Interesado
	END
	ELSE
	BEGIN
		INSERT INTO Partido_Interesado
		VALUES (@Id_Partido,@Id_Interesado, @Baja)		
	END
END 
GO

CREATE PROCEDURE Partido_L
AS
BEGIN
	SELECT Lugar,Fecha_Hora,Confirmado
	FROM Partido		
END
GO


CREATE PROCEDURE Partido_ObtenerInteresados(
	@Id_Partido int
)
AS
BEGIN
	SELECT 
		Nombre_Usuario,
		Password_Usuario,
		Nombre,
		Apellido,
		Edad,
		Mail,
		Tipo_Jugador,
		Posicion,
		Handicap,
		CantPartidosJugados
	FROM Usuario U
	INNER JOIN Interesado I ON U.Id_Usuario = I.Id_Usuario
	INNER JOIN Partido_Interesado PINT ON PiNT.Id_Interesado = I.Id_Interesado
	WHERE Baja <> 1 AND PINT.Id_Partido = @Id_Partido
END
GO

CREATE PROCEDURE Infraccion_L
AS
BEGIN
	SELECT 
		Nombre_Usuario,
		Password_Usuario,
		Nombre,
		Apellido,
		Edad,
		Mail,
		Tipo_Jugador,
		Posicion,
		Handicap,
		CantPartidosJugados
	FROM Usuario U
	INNER JOIN Interesado I ON U.Id_Usuario = I.Id_Usuario
	INNER JOIN Infraccion INF ON U.Id_Usuario = INF.Id_Usuario
END
GO

CREATE PROCEDURE Partido_Interesado_D(
	@Id_Partido int,
	@Id_Interesado int
)
AS 
BEGIN
	UPDATE Partido_Interesado
	SET Baja = 1
	WHERE Id_Partido = @Id_Partido AND Id_Interesado = @Id_Interesado

END
GO

CREATE PROCEDURE ObtenerJugadoresTraicioneros
AS
BEGIN
	SELECT 
		Id_Interesado,
		Id_Usuario,
		Nombre,		
		Apellido,
		Edad,
		Posicion,
		Mail,
		Handicap,
		CantPartidosJugados
	FROM INTERESADO I
	WHERE
		(SELECT Count(1) FROM Infracciones WHERE I.Id_Usuario = INF_IdUsuario) > 3
		--FALTA CONDICION DE "EL ULTIMO MES". Agregar un campo fecha en la infracción		
END
GO


CREATE PROCEDURE ObtenerJugadoresConFuturo
AS
BEGIN
	CREATE TABLE #TempJugadoresMalos
	(
		Id_Interesado INT,
		Nombre NVARCHAR(50),
		Apellido NVARCHAR(50),
		Handicap INT,
		Edad INT
	)

	INSERT INTO #TempJugadoresMalos
	EXEC ObtenerJugadoresMalos 
	
	SELECT * FROM #TempJugadoresMalos WHERE Edad > 25
END
GO


CREATE PROCEDURE Infraccion_I
(
	@Id_Usuario int	
)
AS
BEGIN
	INSERT INTO Infracciones (Descripcion,Id_Usuario) 
	VALUES ('No recomendó jugador tras baja.',@Id_Usuario)				
END
GO
