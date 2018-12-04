USE ControlEscolar;


/* ========= Consultas ========= */


DROP PROCEDURE IF EXISTS SP_SELECT_DataBase;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_DataBase()
BEGIN

	SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'ControlEscolar';

END $$
DELIMITER ;


DROP PROCEDURE IF EXISTS SP_SELECT_UsuarioLog;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_UsuarioLog(_Usuario VARCHAR(30),_Password VARCHAR(30),_Llave VARCHAR(5))
BEGIN

	SELECT * FROM Usuario WHERE
	Usuario =_Usuario AND Password=AES_ENCRYPT(_Password,_Llave) AND Estatus=1;

END $$
DELIMITER ;


DROP PROCEDURE IF EXISTS SP_SELECT_Usuario;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Usuario(_Usuario VARCHAR(30),_Llave VARCHAR(5))
BEGIN

	SELECT U.IdUsuario,U.IdEmpleado,U.Usuario,AES_DECRYPT(Password,'BQG') as 'Contraseña',H.Correo as Correo FROM Usuario AS U
	INNER JOIN Empleado AS E ON U.IdEmpleado=E.IdEmpleado
	INNER JOIN Humano AS H ON E.IdHumano = H.IdHumano
	WHERE
	U.Usuario =_Usuario AND Estatus=1;


END $$
DELIMITER ;


DROP PROCEDURE IF EXISTS SP_SELECT_Admin;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Admin()
BEGIN

	DECLARE _IdUsuario INT;
	SET _IdUsuario = (Select IdUsuario FROM Sesion LIMIT 1);
	SELECT Admin FROM Usuario WHERE IdUsuario=_Idusuario AND Estatus<>0;


END $$
DELIMITER ;



/* ========= Eliminaciones ========= */


/* ========= Actualizaciones ========= */


DROP PROCEDURE IF EXISTS SP_UPDATE_Sesion;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Sesion(IN _IdUsuario INT)
BEGIN

	DELETE FROM Sesion;
	INSERT INTO Sesion (IdUsuario) VALUES(_IdUsuario);	


END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS SP_UPDATE_Humano;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Humano(	IN _IdHumano INT,
					IN _Nombre VARCHAR(25),
					IN _APaterno VARCHAR(25),
					IN _AMaterno VARCHAR(25),
					IN _Fecha_nacimiento DATE,
					IN _Sexo ENUM('F','M'),
					IN _Calle VARCHAR(50),
					IN _Numero VARCHAR(5),
					IN _Telefono DECIMAL(10,0),
					IN _Celular DECIMAL(10,0),
					IN _Correo VARCHAR(30),
					IN _IdAcentamiento INT)

BEGIN

	UPDATE Humano 
	SET 
		Nombre=_Nombre,
		APaterno=_APaterno,
		AMaterno=_AMaterno,
		Fecha_nacimiento=_Fecha_nacimiento,
		Sexo=_Sexo,
		Calle=_Calle,
		Numero=_Numero,
		Telefono=_Telefono,
		Celular=_Celular,
		Correo=_Correo,
		IdAcentamiento=_IdAcentamiento
	WHERE IdHumano=_IdHumano;

END $$
DELIMITER ;

/* ========= Insertados ========= */


DROP PROCEDURE IF EXISTS SP_INSERT_Humano;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_Humano(	OUT _IdHumano INT,
					IN _Nombre VARCHAR(25),
					IN _APaterno VARCHAR(25),
					IN _AMaterno VARCHAR(25),
					IN _Fecha_nacimiento DATE,
					IN _Sexo ENUM('F','M'),
					IN _Calle VARCHAR(50),
					IN _Numero VARCHAR(5),
					IN _Telefono DECIMAL(10,0),
					IN _Celular DECIMAL(10,0),
					IN _Correo VARCHAR(30),
					IN _IdAcentamiento INT)

BEGIN


	INSERT INTO Humano(Nombre,APaterno,AMaterno,Fecha_nacimiento,Sexo,Calle,Numero,Telefono,Celular,Correo,IdAcentamiento,Estatus) VALUES
	(_Nombre,_APaterno,_AMaterno,_Fecha_nacimiento,_Sexo,_Calle,_Numero,_Telefono,_Celular,_Correo,_IdAcentamiento,1);
	SET _IdHumano = (select idHumano from Humano order by idHumano desc limit 1);

END $$
DELIMITER ;


/* ========= Triggers ========= */





