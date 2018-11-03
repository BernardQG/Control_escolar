USE ControlEscolar;

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
	Usuario =_Usuario AND Password=AES_ENCRYPT(_Password,_Llave);

END $$
DELIMITER ;


DROP PROCEDURE IF EXISTS SP_SELECT_Usuario;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Usuario(_Usuario VARCHAR(30))
BEGIN

	SELECT * FROM Usuario WHERE
	Usuario =_Usuario;

END $$
DELIMITER ;


DROP PROCEDURE IF EXISTS SP_SELECT_Alumno;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Alumno(	_ID VARCHAR(10),
					_Nombre_completo VARCHAR(80),
					_Inscripcion VARCHAR(10),
					_Pagado VARCHAR(10),
					_Carrera VARCHAR(80)					
					)
BEGIN

	SELECT Alumno.IdAlumno as ID, CONCAT(Humano.Nombre,' ',Humano.APaterno,' ',Humano.AMaterno) AS Nombre,
	(SELECT COUNT(IdAlumno) FROM Inscripcion WHERE Estatus<>0 AND IdAlumno=Alumno.IdAlumno) as Inscripcion,
	(SELECT CASE Estatus WHEN 1 THEN 'Si' WHEN 0 THEN 'No' END FROM Inscripcion WHERE
	IdPeriodo=(SELECT MAX(IdPeriodo) FROM Periodo) AND IdAlumno=Alumno.IdAlumno) as Pagado,
	Carrera.Nombre as Carrera,
	Alumno.Fecha_inscripcion as 'Fecha de inscripcion'
	FROM Alumno 
	INNER JOIN Humano ON Alumno.IdHumano=Humano.IdHumano
	INNER JOIN Carrera ON Alumno.IdCarrera=Carrera.IdCarrera	
	WHERE 
	Carrera.Nombre LIKE CONCAT('%',_Carrera,'%')
	AND Alumno.IdAlumno LIKE CONCAT('%',_ID,'%')
        HAVING 
	Nombre LIKE CONCAT('%',_Nombre_completo,'%') 
	AND Inscripcion LIKE CONCAT('%',_Inscripcion,'%')
	AND Pagado LIKE CONCAT('%',_Pagado,'%');		

END $$
DELIMITER ;


DROP PROCEDURE IF EXISTS SP_SELECT_Carrera;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Carrera()
BEGIN

	SELECT * from carrera;		

END $$
DELIMITER ;




















