USE ControlEscolar;


/* ========= Consultas ========= */



DROP PROCEDURE IF EXISTS SP_SELECT_Historial_alumno;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Historial_alumno( 	IN _IdAlumno VARCHAR(10),
						IN _Nombre VARCHAR(10),
						IN _IdProfesor VARCHAR(10),
						IN _IdGrupo VARCHAR(10))
BEGIN

	SELECT DISTINCT HA.IdAlumno,
	CONCAT(H.Nombre,' ',H.APaterno,' ',H.AMaterno) AS Alumno,HA.IdGrupo,
	M.Nombre AS Materia,HA.Calificacion,HA.Oportunidad,
	M.Creditos,G.IdProfesor,
	
	(SELECT CONCAT(hu.Nombre,' ',hu.APaterno,' ',hu.AMaterno) FROM Profesor AS P
	INNER JOIN Empleado as em ON P.IdEmpleado = em.IdEmpleado
	INNER JOIN Humano as hu ON em.IdHumano = hu.IdHumano
	WHERE P.IdProfesor= G.IdProfesor LIMIT 1)  as Profesor, 

	Pe.IdPeriodo
	FROM Historial_alumno AS HA
	INNER JOIN Alumno AS A ON HA.IdAlumno = A.IdAlumno
	INNER JOIN Humano AS H ON A.IdHumano = H.IdHumano
	INNER JOIN Grupo AS G ON HA.IdGrupo = G.IdGrupo
	INNER JOIN Materia AS M ON G.IdMateria = M.IdMateria
	INNER JOIN Periodo AS Pe ON G.IdPeriodo = Pe.IdPeriodo
	WHERE 
	HA.IdGrupo LIKE CONCAT('%',_IdGrupo,'%')
	AND HA.IdAlumno LIKE CONCAT('%',_IdAlumno,'%')
	AND G.IdProfesor LIKE CONCAT('%',_IdProfesor,'%')
	HAVING
	Alumno LIKE CONCAT('%',_Nombre,'%')	
	ORDER BY HA.IdAlumno;	

END $$
DELIMITER ;


/* ========= Eliminaciones ========= */

        

/* ========= Actualizaciones ========= */


DROP PROCEDURE IF EXISTS SP_UPDATE_Historial_alumno;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Historial_alumno(	IN _nIdAlumno INT,
						IN _nIdGrupo INT,
						IN _IdAlumno INT,
						IN _IdGrupo INT,
						IN _Calificacion double,
						IN _Oportunidad int)
BEGIN

	SET NAMES utf8;
	UPDATE Historial_alumno
	SET
		Calificacion=_Calificacion,
 		Oportunidad= _Oportunidad,
		IdGrupo=_nIdGrupo,
		IdAlumno=_nIdAlumno
	WHERE IdGrupo=_IdGrupo
	AND IdAlumno=_IdAlumno;


END $$
DELIMITER ;



/* ========= Insertados ========= */




DROP PROCEDURE IF EXISTS SP_INSERT_Historial_alumno;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_Historial_alumno(	IN _IdAlumno INT,
						IN _IdGrupo INT,
						IN _Calificacion double,
						IN _Oportunidad int)
BEGIN	

	INSERT INTO Historial_alumno(IdAlumno,IdGrupo,Calificacion,Oportunidad) VALUES
	(_IdAlumno,_IdGrupo,_Calificacion,_Oportunidad);


END $$
DELIMITER ;

/* ========= Triggers ========= */


DROP TRIGGER IF EXISTS T_INSERT_Historial_alumno;
DELIMITER $$
CREATE TRIGGER T_INSERT_Historial_alumno AFTER INSERT ON Historial_alumno
FOR EACH ROW
BEGIN	
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Insert',(SELECT IdTabla FROM Tabla WHERE Nombre='Historial_alumno' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;


DROP TRIGGER IF EXISTS T_UPDATE_Historial_alumno;
DELIMITER $$
CREATE TRIGGER T_UPDATE_Historial_alumno AFTER UPDATE ON Historial_alumno
FOR EACH ROW
BEGIN			
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Update',(SELECT IdTabla FROM Tabla WHERE Nombre='Historial_alumno' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;




