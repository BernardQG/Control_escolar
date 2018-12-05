USE ControlEscolar;


/* ========= Consultas ========= */



DROP PROCEDURE IF EXISTS SP_SELECT_Grupo;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Grupo( 	IN _IdGrupo VARCHAR(10),
					IN _Materia VARCHAR(45),
					IN _IdPeriodo VARCHAR(10))
BEGIN

	SELECT G.IdGrupo, M.Nombre AS Materia, M.Creditos,
	CONCAT(H.Nombre,' ',H.APaterno,' ',H.AMaterno) AS Profesor, CONCAT(Pe.Fecha_inicio,'-',Pe.Fecha_fin) AS 'Periodo'
	FROM Grupo AS G
	INNER JOIN Periodo AS Pe ON G.IdPeriodo = Pe.IdPeriodo
	INNER JOIN Materia AS M ON G.IdMateria = M.IdMateria
	INNER JOIN Profesor AS P ON G.IdProfesor = P.IdProfesor
	INNER JOIN Empleado AS E ON P.IdEmpleado = E.IdEmpleado
	INNER JOIN Humano AS H ON E.IdHumano = H.IdHumano
	WHERE 
	G.IdGrupo LIKE CONCAT('%',_IdGrupo,'%')
	AND G.IdPeriodo LIKE CONCAT('%',_IdPeriodo,'%')
	AND G.Estatus=1
	HAVING
	Materia LIKE CONCAT('%',_Materia,'%')	
	ORDER BY G.IdGrupo;	

END $$
DELIMITER ;







/* ========= Eliminaciones ========= */


DROP PROCEDURE IF EXISTS SP_DELETE_Grupo;
DELIMITER $$
CREATE PROCEDURE SP_DELETE_Grupo(_IdGrupo INT)
BEGIN

	UPDATE Grupo
	SET Estatus = 0
	WHERE IdGrupo=_IdGrupo;

END $$
DELIMITER ;


/* ========= Actualizaciones ========= */


DROP PROCEDURE IF EXISTS SP_UPDATE_Grupo;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Grupo(	IN _IdGrupo INT,
					IN _IdMateria INT,
					IN _IdProfesor INT,
					IN _IdPeriodo INT)
BEGIN

	SET NAMES utf8;
	UPDATE Grupo
	SET
		IdMateria=_IdMateria,
 		IdProfesor= _IdProfesor,
		IdPeriodo=_IdPeriodo
	WHERE IdGrupo=_IdGrupo;


END $$
DELIMITER ;



/* ========= Insertados ========= */




DROP PROCEDURE IF EXISTS SP_INSERT_Grupo;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_Grupo(	IN _IdMateria INT,
					IN _IdProfesor INT,
					IN _IdPeriodo INT)
BEGIN	

	INSERT INTO Grupo(IdMateria,IdProfesor,IdPeriodo,Estatus) VALUES
	(_IdMateria,_IdProfesor,_IdPeriodo,1);


END $$
DELIMITER ;

/* ========= Triggers ========= */


DROP TRIGGER IF EXISTS T_INSERT_Grupo;
DELIMITER $$
CREATE TRIGGER T_INSERT_Grupo AFTER INSERT ON Grupo
FOR EACH ROW
BEGIN	
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Insert',(SELECT IdTabla FROM Tabla WHERE Nombre='Materia' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;


DROP TRIGGER IF EXISTS T_UPDATE_Grupo;
DELIMITER $$
CREATE TRIGGER T_UPDATE_Grupo AFTER UPDATE ON Grupo
FOR EACH ROW
BEGIN			
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Update',(SELECT IdTabla FROM Tabla WHERE Nombre='Grupo' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;




