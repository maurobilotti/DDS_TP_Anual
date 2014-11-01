INSERT INTO DBPartido (Lugar, Confirmado, Fecha_Hora) Values('Caballito', 0, '20141012 16:00')
INSERT INTO DBPartido (Lugar, Confirmado, Fecha_Hora) Values('Ciudad Jardin', 0, '20140506 22:00')
INSERT INTO DBPartido (Lugar, Confirmado, Fecha_Hora) Values('Campus UTN', 0, '20141222 18:00')

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
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'pzabaleta'), 'Pablo', 'Zabaleta', '19810819', 'pzabaleta@mail.com', 4, 6, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('mdemichelis', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'mdemichelis'), 'Martin', 'Demichelis', '19800504', 'mdemichelis@mail.com', 6, 3, 'Estandar', 0)
			
INSERT INTO DBUSuario (Nombre_Usuario, Password_Usuario, Usuario_Administrador) Values('eperez', '1234', 0)
INSERT INTO DBInteresado (Id_Usuario, Nombre, Apellido, FechaNacimiento, Mail, Posicion, Handicap, Criterio, CantPartidosJugados) 
			Values((SELECT id_usuario from DBUsuario where Nombre_Usuario = 'eperez'), 'Martin', 'Demichelis', '19790307', 'eperez@mail.com', 8, 5, 'Estandar', 0)
			
			
		
