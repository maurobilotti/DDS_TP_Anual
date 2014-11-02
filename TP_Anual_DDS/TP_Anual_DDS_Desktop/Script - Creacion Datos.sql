/* PARTIDOS */
INSERT INTO DBPartido (Lugar, Confirmado, Fecha_Hora) Values('Caballito', 0, '20141012 16:00')
INSERT INTO DBPartido (Lugar, Confirmado, Fecha_Hora) Values('Ciudad Jardin', 0, '20140506 22:00')
INSERT INTO DBPartido (Lugar, Confirmado, Fecha_Hora) Values('Campus UTN', 0, '20141222 18:00')




/* USUARIOS */ 
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('pfurst', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'pfurst'), 'Pablo', 'Furst', '19911015', 'pfurst@mail.com', 5, 6, 'Estandar', 0)


INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('mbilotti', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'mbilotti'), 'Mauro', 'Bilotti', '19871003', 'Bilotti@mail.com', 9, 9, 'Estandar', 0)


INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('fbelvedere', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'fbelvedere'), 'Fede', 'Belvedere', '19870403', 'Belvedere@mail.com', 2, 5, 'Estandar', 0)


INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('ebarany', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'ebarany'), 'Eze', 'Barany', '19910620', 'Barany@mail.com', 7, 8, 'Estandar', 0)


INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('lmessi', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'lmessi'), 'Lionel', 'Messi', '19870621', 'lmessi@mail.com', 10, 10, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('ghiguain', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'ghiguain'), 'Gonzalo', 'Higuain', '19800621', 'ghiguain@mail.com', 9, 9, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('elavezzi', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'elavezzi'), 'Ezequiel', 'Lavezzi', '19880321', 'elavezzi@mail.com', 7, 6, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('rpalacio', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'rpalacio'), 'Rodrigo', 'Palacio', '19841109', 'rpalacio@mail.com', 11, 6, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('mrojo', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'mrojo'), 'Marcos', 'Rojo', '19900106', 'mrojo@mail.com', 3, 5, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('egaray', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'egaray'), 'Ezequiel', 'Garay', '19820206', 'egaray@mail.com', 2, 5, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('sromero', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'sromero'), 'Sergio', 'Romero', '19870212', 'sromero@mail.com', 1, 3, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('adimaria', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'adimaria'), 'Angel', 'Di Maria', '19880911', 'adimaria@mail.com', 7, 10, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('jmascherano', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'jmascherano'), 'Javier', 'Mascherano', '19820813', 'jmascherano@mail.com', 5, 10, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('lbiglia', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'lbiglia'), 'Lucas', 'Biglia', '19820813', 'lbiglia@mail.com', 5, 7, 'Estandar', 0)
	
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('pzabaleta', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'pzabaleta'), 'Pablito', 'Zabaleta', '19810819', 'pzabaleta@mail.com', 4, 6, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('mdemichelis', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'mdemichelis'), 'Martin', 'Demichelis', '19800504', 'mdemichelis@mail.com', 6, 3, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('eperez', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'eperez'), 'Enzo', 'Perez', '19790307', 'eperez@mail.com', 8, 5, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('aorion', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'aorion'), 'Agustin', 'Orion', '19770617', 'aorion@mail.com', 1, 3, 'Estandar', 0)	

INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('jbasanta', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'jbasanta'), 'José', 'Basanta', '19760917', 'jbasanta@mail.com', 3, 4, 'Estandar', 0)	
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('afernandez', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'afernandez'), 'Augusto', 'Fernandez', '19831011', 'afernandez@mail.com', 8, 6, 'Estandar', 0)
		
/* JUGADORES */			
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Jugó muy bien, buen compañero',1,2,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Llegó tarde y con resaca',1,3,3)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Excelente partido!',1,4,9)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Es muy violento y encima hincha de River',1,5,2)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Se la paso insultando a todos',1,6,3)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Gran compañero, seguro juguemos de nuevo juntos',1,7,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Partido regular, puede dar mas',1,8,6)			
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Buen compañero',2,2,6)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Llegó tarde y con resaca',2,3,3)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Excelente partido!',2,4,9)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Es muy violento ',2,5,1)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Se la paso corriendo! un genio',2,6,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Gran compañero',2,7,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (1,'Partido regular',2,8,4)			
						
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Jugó muy bien, buen compañero',1,2,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Llegó tarde y con resaca',1,3,3)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Excelente partido!',1,4,9)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Es muy violento y encima hincha de River',1,5,2)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Se la paso insultando a todos',1,6,3)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Gran compañero, seguro juguemos de nuevo juntos',1,7,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Partido regular, puede dar mas',1,8,6)			
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Buen compañero',2,2,6)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Llegó tarde y con resaca',2,3,3)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Excelente partido!',2,4,9)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Es muy violento ',2,5,1)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Se la paso corriendo! un genio',2,6,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Gran compañero',2,7,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (2,'Partido regular',2,8,4)									

INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Jugó muy bien, buen compañero',1,2,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Llegó tarde y con resaca',1,3,3)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Excelente partido!',1,4,9)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Es muy violento y encima hincha de River',1,5,2)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Se la paso insultando a todos',1,6,3)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Gran compañero, seguro juguemos de nuevo juntos',1,7,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Partido regular, puede dar mas',1,8,6)						                                                                                                                 
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Buen compañero',2,2,6)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Llegó tarde y con resaca',2,3,3)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Excelente partido!',2,4,9)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Es muy violento ',2,5,1)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Se la paso corriendo! un genio',2,6,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Gran compañero',2,7,8)
INSERT INTO [DBCalificacion] ([Id_Partido],[Descripcion],[Id_Jugador_Critico],[Id_Jugador_Criticado],[Calificacion]) values (3,'Partido regular',2,8,4)									

/*INSCRIPTOS A PARTIDOS*/

--RESET
--DELETE FROM DBPartido_Interesado
--DELETE FROM DBPartido_Interesado_Condicional

INSERT INTO DBPartido_Interesado VALUES (1,1,3,null,0)
INSERT INTO DBPartido_Interesado VALUES (1,2,1,null,0)
	INSERT INTO DBPartido_Interesado_Condicional VALUES (1,2,1,0)
	INSERT INTO DBPartido_Interesado_Condicional VALUES (1,2,2,0)
INSERT INTO DBPartido_Interesado VALUES (1,3,2,null,0)
INSERT INTO DBPartido_Interesado VALUES (1,4,3,null,0)
INSERT INTO DBPartido_Interesado VALUES (1,5,2,null,0)
INSERT INTO DBPartido_Interesado VALUES (1,6,3,null,0)
INSERT INTO DBPartido_Interesado VALUES (1,7,2,null,0)
INSERT INTO DBPartido_Interesado VALUES (1,8,2,null,0)
INSERT INTO DBPartido_Interesado VALUES (1,9,3,null,0)
INSERT INTO DBPartido_Interesado VALUES (1,10,3,null,0)


INSERT INTO DBPartido_Interesado VALUES (2,1,3,null,0)
INSERT INTO DBPartido_Interesado VALUES (2,2,1,null,0)
	INSERT INTO DBPartido_Interesado_Condicional VALUES (2,2,1,0)
	INSERT INTO DBPartido_Interesado_Condicional VALUES (2,2,2,0)
INSERT INTO DBPartido_Interesado VALUES (2,13,2,null,0)
INSERT INTO DBPartido_Interesado VALUES (2,18,1,null,0)
	INSERT INTO DBPartido_Interesado_Condicional VALUES (2,18,1,0)
	INSERT INTO DBPartido_Interesado_Condicional VALUES (2,18,2,0)
INSERT INTO DBPartido_Interesado VALUES (2,9,2,null,0)
INSERT INTO DBPartido_Interesado VALUES (2,11,3,null,0)


/**************************************************/
/* Reset de datos */
--TRUNCATE TABLE dbo.DBAmigos
--TRUNCATE TABLE dbo.DBCalificacion
--TRUNCATE TABLE dbo.DBCondicion
--TRUNCATE TABLE dbo.DBCondicion_Interesado
--TRUNCATE TABLE dbo.DBDenegacion
--TRUNCATE TABLE dbo.DBInfraccion
--TRUNCATE TABLE dbo.DBInteresado
--TRUNCATE TABLE dbo.DBPartido
--TRUNCATE TABLE dbo.DBPartido_Interesado
--TRUNCATE TABLE dbo.DBPartido_Interesado_Condicional
--TRUNCATE TABLE dbo.DBUsuario
/**************************************************/