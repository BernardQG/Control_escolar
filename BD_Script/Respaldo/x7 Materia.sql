USE ControlEscolar;


/* ========= Consultas ========= */



DROP PROCEDURE IF EXISTS SP_SELECT_Materia;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Materia( 	IN _IdMateria VARCHAR(10),
					IN _Nombre VARCHAR(45))
BEGIN

	SELECT IdMateria as ID, Nombre, Creditos
	FROM Materia
	WHERE 
	IdMateria LIKE CONCAT('%',_IdMateria,'%')
	AND Nombre LIKE CONCAT('%',_Nombre,'%')
	AND Estatus = 1
	ORDER BY IdMateria;	

END $$
DELIMITER ;


/* ========= Eliminaciones ========= */


DROP PROCEDURE IF EXISTS SP_DELETE_Materia;
DELIMITER $$
CREATE PROCEDURE SP_DELETE_Materia(_IdMateria INT)
BEGIN

	UPDATE Materia
	SET Estatus = 0
	WHERE IdMateria=_IdMateria;

END $$
DELIMITER ;


/* ========= Actualizaciones ========= */


DROP PROCEDURE IF EXISTS SP_UPDATE_Materia;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Materia(	IN _IdMateria INT,
					IN _Nombre VARCHAR(45),
					IN _Creditos INT)
BEGIN

	SET NAMES utf8;
	UPDATE Materia
	SET
		Nombre=_Nombre,
 		Creditos= _Creditos
	WHERE IdMateria=_IdMateria;


END $$
DELIMITER ;



/* ========= Insertados ========= */




DROP PROCEDURE IF EXISTS SP_INSERT_Materia;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_Materia(	IN _Nombre VARCHAR(45),
					IN _Creditos INT)
BEGIN	

	INSERT INTO Materia(Nombre,Creditos,Estatus) VALUES
	(_Nombre,_Creditos,1);


END $$
DELIMITER ;

/* ========= Triggers ========= */


DROP TRIGGER IF EXISTS T_INSERT_Materia;
DELIMITER $$
CREATE TRIGGER T_INSERT_Materia AFTER INSERT ON Materia
FOR EACH ROW
BEGIN	
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Insert',(SELECT IdTabla FROM Tabla WHERE Nombre='Materia' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;


DROP TRIGGER IF EXISTS T_UPDATE_Materia;
DELIMITER $$
CREATE TRIGGER T_UPDATE_Materia AFTER UPDATE ON Materia
FOR EACH ROW
BEGIN			
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Update',(SELECT IdTabla FROM Tabla WHERE Nombre='Materia' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;




