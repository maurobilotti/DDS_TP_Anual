CREATE TABLE DBUsuario(
	Id_Usuario int IDENTITY(1,1) NOT NULL,	
	Nombre_Usuario nvarchar(50) NULL,
	Password_Usuario nvarchar(50) NULL,
	Usuario_Administrador [bit] NULL,
	CONSTRAINT PK_Usuarios PRIMARY KEY (Id_Usuario)
)

CREATE TABLE DBInteresado(
	Id_Interesado int IDENTITY(1,1) NOT NULL,
	Id_Usuario int NOT NULL,
	Nombre nvarchar(50) NOT NULL,
	Apellido nvarchar(50) NOT NULL,
	FechaNacimiento date NOT NULL,
	Mail nvarchar(50) NULL,	
	Posicion int NULL,
	Handicap int NULL,	 
	CantPartidosJugados int NOT NULL,
	PRIMARY KEY (Id_Interesado),
	foreign key(Id_Usuario)references DBUsuario(Id_Usuario),
)

CREATE TABLE DBPartido(
	Id_Partido int IDENTITY(1,1) NOT NULL,
	Lugar nvarchar(50) NOT NULL,	
	Confirmado bit NULL,
	Fecha_Hora datetime NULL,
	Finalizado bit default 0,
	PRIMARY KEY(Id_Partido)
)

CREATE TABLE DBTipoJugador(
	Id_TipoJugador int NOT NULL,
	Descripcion nvarchar(50) NOT NULL,	
	PRIMARY KEY(Id_TipoJugador)
) 
/* Cargamos los tipos */
INSERT INTO DBTipoJugador (Id_TipoJugador,Descripcion) values (1,'Condicional')
INSERT INTO DBTipoJugador (Id_TipoJugador,Descripcion) values (2,'Solidario')
INSERT INTO DBTipoJugador (Id_TipoJugador,Descripcion) values (3,'Estandar')

create TABLE DBPartido_Interesado(
	Id_Partido int NOT NULL,
	Id_Interesado int NOT NULL,
	Id_TipoJugador int NOT NULL,
	EquipoDesignado int NULL,
	Baja bit NULL,		
	CONSTRAINT Partido_Interesado_pk PRIMARY KEY(Id_Interesado,Id_Partido),
	foreign key(Id_Interesado)references DBInteresado(Id_Interesado),
	foreign key(Id_Partido)references DBPartido(Id_Partido)ON DELETE CASCADE,
	foreign key(Id_TipoJugador)references DBTipoJugador(ID_TipoJugador)
) 


CREATE TABLE DBCalificacion(
	Id_Calificacion int IDENTITY(1,1) NOT NULL,
	Id_Partido int NOT NULL,
	Descripcion nvarchar(50) NULL,
	Id_Jugador_Critico int NULL,
	Id_Jugador_Criticado int NULL,
	Calificacion int NOT NULL,	
	PRIMARY KEY (Id_Calificacion),
	foreign key(Id_Partido)references DBPartido(Id_Partido)ON DELETE CASCADE 
) 

CREATE TABLE DBCondicion(
	Id_Condicion int NOT NULL,
	Descripcion_Condicion nvarchar(50) NULL,
	PRIMARY KEY(Id_Condicion)
)

/*CREACION DE CONDICIONES */
INSERT INTO DBCondicion VALUES (1, 'CondicionCantidadMayoresDe20')
INSERT INTO DBCondicion VALUES (2, 'CondicionLugar')

CREATE TABLE DBPartido_Interesado_Condicional(
	Id_Partido int NOT NULL,
	Id_Interesado int NOT NULL,
	Id_Condicion int NOT NULL,
	Baja bit NULL,
	CONSTRAINT Partido_Interesado_Condicional_pk PRIMARY KEY(Id_Interesado,Id_Partido,Id_Condicion),
	foreign key(Id_Interesado)references DBInteresado(Id_Interesado),
	foreign key(Id_Partido)references DBPartido(Id_Partido)ON DELETE CASCADE ,
	foreign key(Id_Condicion)references DBCondicion(Id_Condicion)
) 
 

CREATE TABLE DBCondicion_Interesado(
	Id_Condicion int NOT NULL,
	Id_interesado int NOT NULL,
	CONSTRAINT [PK_Condicion_Interesado] PRIMARY KEY(Id_Condicion, Id_interesado),
	foreign key(Id_Condicion)references DBCondicion(Id_Condicion),
	foreign key(Id_Interesado)references DBInteresado(Id_Interesado)ON DELETE CASCADE 
)

CREATE TABLE DBAmigos(
	Id_Interesado int  NOT NULL,
	Id_Amigo int IDENTITY(1,1) NOT NULL,
	PRIMARY KEY (Id_Amigo, Id_Interesado),
	foreign key(Id_Interesado)references DBInteresado(Id_Interesado)ON DELETE CASCADE 
) 


CREATE TABLE DBDenegacion(
	Id_Denegacion int IDENTITY(1,1) NOT NULL,
	Id_Interesado int NOT NULL,
	Id_Usuario int NOT NULL,
	Fecha_Denegacion datetime NULL,
	Descripcion_motivo_Denegacion nvarchar(50) NULL,
	Id_Admin int NULL,
	CONSTRAINT [PK_Denegacion] PRIMARY KEY(Id_Denegacion, Id_Interesado, Id_Usuario),
	foreign key(Id_Interesado)references DBInteresado(Id_Interesado),
	foreign key(Id_Usuario)references DBUsuario(Id_Usuario) ON DELETE CASCADE 
)

CREATE TABLE DBInfraccion(
	Id_Infraccion int IDENTITY(1,1) NOT NULL,
	Descripcion_Infraccion nvarchar(50) NULL,
	Id_Usuario int NULL,
	CONSTRAINT [PK_Infracciones] PRIMARY KEY(Id_Infraccion),
	foreign key(Id_Usuario)references DBUsuario(Id_Usuario)ON DELETE CASCADE
)

CREATE TABLE [dbo].[DBEstandar](
	[Modalidad_deJuego] [nvarchar](50) NULL,
	[Descripcion_Estandar] [nvarchar](50) NULL,
	[Prioridad] [nvarchar](50) NULL
) ON [PRIMARY]

CREATE TABLE [dbo].[DBSolidario](
	[Modalidad_deJuego] [nvarchar](50) NULL,
	[Descripcion_Estandar] [nvarchar](50) NULL,
	[Datos_contacto] [nvarchar](50) NULL,
	[Prioridad] [nvarchar](50) NULL
) ON [PRIMARY]
GO

--FUNCIONES

CREATE FUNCTION PromUltimoPartido(
	@Id_Interesado int
)
RETURNS decimal(18,2)
AS 
BEGIN	
RETURN 
(
	SELECT ISNULL(AVG(CAST(c.Calificacion as decimal(18,2))),0) as promedio
	FROM DBCalificacion c 
	JOIN DBPartido pa on pa.Id_Partido = c.Id_Partido
	JOIN DBInteresado inte on inte.Id_Interesado = c.Id_Jugador_Criticado
	WHERE CONVERT(datetime,pa.Fecha_Hora,103) = (SELECT TOP 1 CONVERT(datetime,part.Fecha_Hora,103)FROM DBPartido part 
	JOIN DBCalificacion calif on calif.Id_Partido=part.Id_Partido order by CONVERT(datetime,part.Fecha_Hora,103) desc)
	AND inte.Id_Interesado = @Id_Interesado
)
END
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
    INSERT INTO DBPartido VALUES  (@Lugar,@Confirmado,@Fecha_Hora,0)
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
	IF(EXISTS(SELECT 1 FROM DBUsuario WHERE Nombre_Usuario = @Nombre_Usuario))
	BEGIN
		UPDATE dbo.DBUsuario 
		SET Nombre_Usuario = @Nombre_Usuario,
		Password_Usuario = @Password_Usuario,
		Usuario_Administrador = @Usuario_Administrador
	END
	ELSE
	BEGIN
		INSERT INTO dbo.DBUsuario VALUES (@Nombre_Usuario,@Password_Usuario,@Usuario_Administrador)	
	END
END
GO

CREATE PROCEDURE [dbo].Interesado_UI(
	@Id_Usuario int,
    @Nombre nvarchar(50),
    @Apellido nvarchar(50),
    @FechaNacimiento date,
    @Mail nvarchar(50),
    @Posicion int,
    @Handicap int    
)
AS
BEGIN
	SET NOCOUNT ON
	IF(EXISTS(SELECT 1 FROM DBInteresado WHERE @Id_Usuario = Id_Usuario))
	BEGIN
		UPDATE Interesado
		SET
		Id_Usuario = @Id_Usuario,
		Nombre = @Nombre,
		Apellido = @Apellido,
		FechaNacimiento = @FechaNacimiento,
		Mail = @Mail,
		Posicion = @Posicion,
		Handicap = @Handicap,		
		CantPartidosJugados = 0
	END
	ELSE
	BEGIN
		INSERT INTO dbo.DBInteresado 
		VALUES (@Id_Usuario,@Nombre,@Apellido,@FechaNacimiento,@Mail,@Posicion,@Handicap, 0)	
	END
END
GO


CREATE PROCEDURE dbo.Usuario_L
AS
BEGIN
	SELECT 
	U.Id_Usuario AS Id_Usuario,
	U.Nombre_Usuario,
	U.Password_Usuario,
	I.Nombre,
	I.Apellido,
	I.FechaNacimiento,
	I.Mail,
	I.Posicion,
	I.Handicap,
	I.CantPartidosJugados
	FROM DBUsuario U
	INNER JOIN DBInteresado I ON U.Id_Usuario = I.Id_Usuario
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
		FechaNacimiento,
		Posicion,
		Mail,
		Handicap,
		CantPartidosJugados
	FROM DBINTERESADO WHERE Handicap < 5
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
		FechaNacimiento,
		Mail,
		Posicion,
		Handicap,		
		CantPartidosJugados
		FROM DBUsuario U
		INNER JOIN DBInteresado I ON I.Id_Usuario = U.Id_Usuario
		WHERE Nombre_Usuario = @Nombre_Usuario AND
			  Password_Usuario = @Password_Usuario 
	
END
GO

CREATE PROCEDURE Partido_Interesado_UI(
	@Id_Partido int,
	@Id_Interesado int,	
	@Tipo_Jugador int,	
	@Baja bit = 0
)
AS
BEGIN 
	SET NOCOUNT ON
	IF(EXISTS(SELECT 1 FROM DBPartido_Interesado WHERE Id_Partido = @Id_Partido AND Id_Interesado = @Id_Interesado))
	BEGIN
		UPDATE DBPartido_Interesado
		SET Baja = @Baja, Id_TipoJugador = @Tipo_Jugador
		WHERE Id_Partido = @Id_Partido AND Id_Interesado = @Id_Interesado
	END
	ELSE
	BEGIN
		--deben generarse los equipos nuevamente, por lo que primero se quita la designaci�n de equipos
		UPDATE DBPartido_Interesado SET EquipoDesignado = NULL WHERE Id_Partido = @Id_Partido
		--se inserta el nuevo jugador al partido
		INSERT INTO DBPartido_Interesado
		VALUES (@Id_Partido,@Id_Interesado, @Tipo_Jugador, null, @Baja)		
	END
END 
GO

CREATE PROCEDURE Partido_Interesado_Condicional_UI(
	@Id_Partido int,
	@Id_Interesado int,	
	@Id_Condicion int,
	@Baja bit = 0
)
AS
BEGIN 
	SET NOCOUNT ON
	IF(EXISTS(SELECT 1 FROM DBPartido_Interesado_Condicional WHERE Id_Partido = @Id_Partido AND Id_Interesado = @Id_Interesado AND Id_Condicion = @Id_Condicion))
	BEGIN
		UPDATE DBPartido_Interesado_Condicional
		SET Baja = @Baja
		WHERE Id_Partido = @Id_Partido AND Id_Interesado = @Id_Interesado AND Id_Condicion = @Id_Condicion
	END
	ELSE
	BEGIN
		INSERT INTO DBPartido_Interesado_Condicional
		VALUES (@Id_Partido,@Id_Interesado, @Id_Condicion, @Baja)		
	END
END 
GO


CREATE PROCEDURE Partido_L
AS
BEGIN
	SELECT Lugar,Fecha_Hora,Confirmado, Finalizado
	FROM DBPartido		
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
		FechaNacimiento,
		Mail,
		Posicion,
		Handicap,
		CantPartidosJugados
	FROM DBUsuario U
	INNER JOIN DBInteresado I ON U.Id_Usuario = I.Id_Usuario
	INNER JOIN DBPartido_Interesado PINT ON PiNT.Id_Interesado = I.Id_Interesado
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
		FechaNacimiento,
		Mail,
		Posicion,
		Handicap,
		CantPartidosJugados
	FROM DBUsuario U
	INNER JOIN DBInteresado I ON U.Id_Usuario = I.Id_Usuario
	INNER JOIN DBInfraccion INF ON U.Id_Usuario = INF.Id_Usuario
END
GO

CREATE PROCEDURE Partido_Interesado_D(
	@Id_Partido int,
	@Id_Interesado int
)
AS 
BEGIN
	UPDATE DBPartido_Interesado
	SET Baja = 1
	WHERE Id_Partido = @Id_Partido AND Id_Interesado = @Id_Interesado

END
GO

CREATE PROCEDURE Partido_Interesado_Condicional_D(
	@Id_Partido int,
	@Id_Interesado int,
	@Id_Condicion int
)
AS 
BEGIN
	UPDATE DBPartido_Interesado_Condicional
	SET Baja = 1
	WHERE Id_Partido = @Id_Partido AND Id_Interesado = @Id_Interesado AND @Id_Condicion = Id_Condicion
END
GO

CREATE PROCEDURE Partido_Interesado_L(
	@Id_Partido int
)
AS
BEGIN
	SELECT 
		Nombre,
		Apellido,
		FechaNacimiento,
		Posicion,		
		Handicap,
		TJ.Descripcion
		FROM DBInteresado I
		INNER JOIN DBPartido_Interesado P_I ON I.Id_Interesado = P_I.Id_Interesado
		INNER JOIN DBTipoJugador		TJ  ON TJ.Id_TipoJugador = P_I.Id_TipoJugador
		WHERE P_I.Id_Partido = @Id_Partido AND P_I.Baja <> 1
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
		FechaNacimiento,
		Posicion,
		Mail,
		Handicap,
		CantPartidosJugados
	FROM DBINTERESADO I
	WHERE
		(SELECT Count(1) FROM DBInfraccion INF WHERE I.Id_Usuario = INF.Id_Usuario) > 3
		--FALTA CONDICION DE "EL ULTIMO MES". Agregar un campo fecha en la infracci�n		
END
GO


CREATE PROCEDURE [dbo].[ObtenerJugadoresConFuturo]
AS
BEGIN
	DECLARE @TempJugadoresMalos TABLE
	(
		Id_Usuario INT,
		Id_Interesado INT,
		Nombre NVARCHAR(50),
		Apellido NVARCHAR(50),		
		FechaNacimiento date,
		Posicion INT,
		Mail nvarchar(50),
		Handicap int,
		CantPartidosJugados int
	)

	INSERT INTO @TempJugadoresMalos
	EXEC ObtenerJugadoresMalos 
	
	SELECT * FROM @TempJugadoresMalos WHERE (YEAR(GETDATE()) - YEAR(FechaNacimiento)) < 25
END


CREATE PROCEDURE Infraccion_I
(
	@Id_Usuario int
)
AS
BEGIN
	INSERT INTO DBInfraccion (Descripcion_Infraccion, Id_Usuario) 
	VALUES ('No recomend� jugador tras baja.',@Id_Usuario)				
END
GO

CREATE PROCEDURE Calificacion_I(
	@Id_Partido int,
	@Descripcion nvarchar(50),
	@Id_Jugador_Critico int,
	@Id_Jugador_Criticado int,
	@Calificacion int
)
AS
BEGIN
	INSERT INTO DBCalificacion (Id_Partido,Descripcion,Id_Jugador_Critico,Id_Jugador_Criticado,Calificacion) 
	VALUES(@Id_Partido, @Descripcion, @Id_Jugador_Critico, @Id_Jugador_Criticado, @Calificacion)
END
GO


CREATE PROCEDURE [dbo].[Interesado_Detalle_L](
	@Id_Interesado int 
)
AS
BEGIN
SELECT	Inte.Nombre, 
		Inte.Handicap,
		dbo.PromUltimoPartido(Inte.Id_Interesado) as PromUltimo,
		AVG(cal.Calificacion) PromTodos,
		Inte.FechaNacimiento,
	(SELECT COUNT(*) FROM  DBPartido_Interesado where Id_Interesado = Inte.Id_Interesado AND Baja = 0) as cantJugados
FROM DBInteresado Inte
JOIN DBCalificacion cal ON cal.Id_Jugador_Criticado = Inte.Id_Interesado
where inte.Id_Interesado = @Id_Interesado
group by Inte.Nombre,Inte.Handicap,dbo.PromUltimoPartido(Inte.Id_Interesado),Inte.FechaNacimiento,Inte.Id_Interesado


Return
END
GO



CREATE PROCEDURE [dbo].[Interesado_Infracciones_L](
	@Id_Interesado int 
)
AS
BEGIN
SELECT	Infra.*
FROM DBInfraccion Infra
JOIN DBInteresado inte ON inte.Id_Usuario = Infra.Id_Usuario 
where inte.Id_Interesado = @Id_Interesado

Return
END
GO


CREATE PROCEDURE [dbo].[Buscar_Jugadores_L](
	@nombre_jugador varchar(50)= '',
	@fecha_nacimiento date = '',
	@handicap_desde int = -1,
	@handicap_hasta int = 11,
	@promedio_desde decimal(5,2) = 0,
	@promedio_hasta decimal(5,2) = 11,
	@infracciones int
)
AS
BEGIN

set @nombre_jugador = ISNULL(@nombre_jugador,'')
set @fecha_nacimiento = ISNULL(@fecha_nacimiento,'')
set @handicap_desde = ISNULL(@handicap_desde,-1)
set @handicap_hasta = ISNULL(@handicap_hasta,11)
set @promedio_desde = ISNULL(@promedio_desde,0)
set @promedio_hasta = ISNULL(@promedio_hasta,11)

	IF @infracciones = -1
	BEGIN
				SELECT 
				DISTINCT
				 i.Id_Interesado,
				 i.Nombre,
				 i.Apellido,
				 i.FechaNacimiento,
				 i.Handicap,
				 i.CantPartidosJugados	
			FROM DBInteresado i
			LEFT JOIN DBCalificacion ca on ca.Id_Jugador_Criticado = i.Id_Interesado
			WHERE i.nombre LIKE (CASE WHEN @nombre_jugador = '' THEN  i.Nombre ELSE @nombre_jugador+'%' END) 
			AND CONVERT(datetime,i.FechaNacimiento,103) < (CASE WHEN @fecha_nacimiento = '' THEN '2100-12-01' ELSE @fecha_nacimiento END)
			AND (i.Handicap between @handicap_desde and @handicap_hasta)			
			RETURN
	END
	ELSE 
	BEGIN
		IF @infracciones = 0
		BEGIN
			SELECT 
			DISTINCT
				i.Id_Interesado,
				 i.Nombre,
				 i.Apellido,
				 i.FechaNacimiento,
				 i.Handicap,
				 i.CantPartidosJugados		
			FROM DBInteresado i
			LEFT JOIN DBCalificacion ca on ca.Id_Jugador_Criticado = i.Id_Interesado
			WHERE i.nombre LIKE (CASE WHEN @nombre_jugador = '' THEN  i.Nombre ELSE @nombre_jugador+'%' END) 
		AND CONVERT(datetime,i.FechaNacimiento,103) < (CASE WHEN @fecha_nacimiento = '' THEN '9999-12-01' ELSE @fecha_nacimiento END)
		AND (i.Handicap between @handicap_desde and @handicap_hasta)
		AND not exists (SELECT * FROM DBInfraccion inf where inf.Id_Usuario = i.Id_Usuario)
		RETURN
		END
		ELSE
		BEGIN
			SELECT 
			DISTINCT
				 i.Id_Interesado,
				 i.Nombre,
				 i.Apellido,
				 i.FechaNacimiento,
				 i.Handicap,
				 i.CantPartidosJugados	
			FROM DBInteresado i
			LEFT JOIN DBCalificacion ca on ca.Id_Jugador_Criticado = i.Id_Interesado
			WHERE i.nombre LIKE (CASE WHEN @nombre_jugador = '' THEN  i.Nombre ELSE @nombre_jugador+'%' END) 
			AND CONVERT(datetime,i.FechaNacimiento,103) < (CASE WHEN @fecha_nacimiento = '' THEN '9999-12-01'ELSE @fecha_nacimiento END)
		AND (i.Handicap between @handicap_desde and @handicap_hasta)
		AND exists (SELECT * FROM DBInfraccion inf where inf.Id_Usuario = i.Id_Usuario)
		RETURN
		END
	END
END
GO

CREATE PROCEDURE Interesado_ObtenerPartidosFinalizados(
	@Id_Interesado int
)
AS 
BEGIN
	SELECT 
	P.Id_Partido,
	P.Lugar,
	P.Confirmado,
	P.Fecha_Hora,
	P.Finalizado
	FROM DBPartido_Interesado P_I
	INNER JOIN DBPartido P ON P.Id_Partido = P_I.Id_Partido
	WHERE P_I.Id_Interesado = @Id_Interesado AND P.Finalizado = 1 AND P.Confirmado = 1
	AND P_I.Baja = 0
END 
GO



CREATE TABLE DBEstandar(
	Modalidad_deJuego nvarchar(50) NULL,
	Descripcion_Estandar nvarchar(50) NULL,
	Prioridad nvarchar(50) null
)
insert into DBEstandar values('Comprometido','Se compromete a presentarse en tiempo y forma','ALTA')

CREATE TABLE DBSolidario(
	Modalidad_deJuego nvarchar(50) NULL,
	Descripcion_Estandar nvarchar(50) NULL,
	Datos_contacto nvarchar(50) null,
	Prioridad nvarchar(50) null
)
insert into DBSolidario values('Solidaria','Se compromete a presentarse si se lo necesita','4944-4390','MEDIA')

