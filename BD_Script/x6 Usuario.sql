USE ControlEscolar;


/* ========= Consultas ========= */



DROP PROCEDURE IF EXISTS SP_SELECT_Usuario2;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Usuario2( 	IN _IdUsuario VARCHAR(10),
					IN _Nombre_completo VARCHAR(80),
					IN _Usuario VARCHAR(80),
					IN _KEY VARCHAR(4))
BEGIN

	SELECT U.IdUsuario AS ID, 
	CONCAT(H.Nombre,' ',H.APaterno,' ',H.AMaterno) AS Nombre,
	U.Usuario, AES_DECRYPT(Password,'BQG') as 'Password', H.Correo, U.Admin
	FROM Usuario AS U
	INNER JOIN Empleado AS E ON U.IdEmpleado = E.IdEmpleado
	INNER JOIN Humano AS H ON E.IdHumano = H.IdHumano
	WHERE 
	U.IdUsuario LIKE CONCAT('%',_IdUsuario,'%')
	AND U.Usuario LIKE CONCAT('%',_Usuario,'%')
	AND U.Estatus = 1
	HAVING
	Nombre LIKE CONCAT('%',_Nombre_completo,'%')
	ORDER BY U.Idusuario;	

END $$
DELIMITER ;


DROP PROCEDURE IF EXISTS SP_SELECT_UserEmpleado;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_UserEmpleado()
BEGIN

	SELECT E.IdEmpleado, CONCAT(H.Nombre,' ',H.APaterno,' ',H.AMaterno) AS Nombre
	FROM Empleado AS E
	INNER JOIN Humano AS H ON E.IdHumano = H.IdHumano	
	ORDER BY E.IdEmpleado;	

END $$
DELIMITER ;





/* ========= Eliminaciones ========= */


DROP PROCEDURE IF EXISTS SP_DELETE_Usuario;
DELIMITER $$
CREATE PROCEDURE SP_DELETE_Usuario(_IdUsuario INT)
BEGIN

	UPDATE Usuario as U
	SET U.Estatus = 0
	WHERE U.IdUsuario=_IdUsuario;

END $$
DELIMITER ;


/* ========= Actualizaciones ========= */


DROP PROCEDURE IF EXISTS SP_UPDATE_Usuario;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Usuario(	IN _IdUsuario INT,
					IN _Usuario VARCHAR(30),
					IN _Password VARCHAR(30),
					IN _Admin INT,
					IN _KEY VARCHAR(4))
BEGIN

	SET NAMES utf8;
	UPDATE Usuario
	SET
		Usuario=_Usuario,
		Password=AES_ENCRYPT(_Password,_KEY),
		Admin=_Admin		
	WHERE IdUsuario=_IdUsuario;



END $$
DELIMITER ;



/* ========= Insertados ========= */




DROP PROCEDURE IF EXISTS SP_INSERT_Usuario;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_Usuario(	IN _IdEmpleado INT,
					IN _Usuario VARCHAR(30),
					IN _Password VARCHAR(30),
					IN _Admin INT,
					IN _KEY VARCHAR(4))
BEGIN	

	INSERT INTO Usuario(IdEmpleado,Usuario,Password,Admin,Estatus) VALUES
	(_IdEmpleado,_Usuario,AES_ENCRYPT(_Password,_KEY),_Admin,1);


END $$
DELIMITER ;

/* ========= Triggers ========= */


DROP TRIGGER IF EXISTS T_INSERT_Usuario;
DELIMITER $$
CREATE TRIGGER T_INSERT_Usuario AFTER INSERT ON Usuario
FOR EACH ROW
BEGIN	
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Insert',(SELECT IdTabla FROM Tabla WHERE Nombre='Usuario' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;


DROP TRIGGER IF EXISTS T_UPDATE_Usuario;
DELIMITER $$
CREATE TRIGGER T_UPDATE_Usuario AFTER UPDATE ON Usuario
FOR EACH ROW
BEGIN			
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Update',(SELECT IdTabla FROM Tabla WHERE Nombre='Usuario' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;




