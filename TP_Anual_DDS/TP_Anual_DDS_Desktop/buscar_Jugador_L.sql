SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
				 i.Handicap,
				 dbo.PromUltimoPartido(i.Id_Interesado)
			FROM DBInteresado i
			LEFT JOIN DBCalificacion ca on ca.Id_Jugador_Criticado = i.Id_Interesado
			WHERE i.nombre LIKE (CASE WHEN @nombre_jugador = '' THEN  i.Nombre ELSE @nombre_jugador+'%' END) 
			AND CONVERT(datetime,i.FechaNacimiento,103) < (CASE WHEN @fecha_nacimiento = '' THEN '9999-12-01' ELSE @fecha_nacimiento END)
			AND (i.Handicap between @handicap_desde and @handicap_hasta)
			AND (dbo.PromUltimoPartido(i.Id_Interesado) between @promedio_desde and @promedio_hasta) 
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
				 i.Handicap,
				 dbo.PromUltimoPartido(i.Id_Interesado)
			FROM DBInteresado i
			LEFT JOIN DBCalificacion ca on ca.Id_Jugador_Criticado = i.Id_Interesado
			WHERE i.nombre LIKE (CASE WHEN @nombre_jugador = '' THEN  i.Nombre ELSE @nombre_jugador+'%' END) 
		AND CONVERT(datetime,i.FechaNacimiento,103) < (CASE WHEN @fecha_nacimiento = '' THEN '9999-12-01' ELSE @fecha_nacimiento END)
		AND (i.Handicap between @handicap_desde and @handicap_hasta)
		AND (dbo.PromUltimoPartido(i.Id_Interesado) between @promedio_desde and @promedio_hasta)
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
				 i.Handicap,
				 dbo.PromUltimoPartido(i.Id_Interesado)
			FROM DBInteresado i
			LEFT JOIN DBCalificacion ca on ca.Id_Jugador_Criticado = i.Id_Interesado
			WHERE i.nombre LIKE (CASE WHEN @nombre_jugador = '' THEN  i.Nombre ELSE @nombre_jugador+'%' END) 
			AND CONVERT(datetime,i.FechaNacimiento,103) < (CASE WHEN @fecha_nacimiento = '' THEN '9999-12-01'ELSE @fecha_nacimiento END)
		AND (i.Handicap between @handicap_desde and @handicap_hasta)
		AND (dbo.PromUltimoPartido(i.Id_Interesado) between @promedio_desde and @promedio_hasta)
		AND exists (SELECT * FROM DBInfraccion inf where inf.Id_Usuario = i.Id_Usuario)
		RETURN
		END
	END
END
GO


