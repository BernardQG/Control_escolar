USE ControlEscolar;


/* ========= Eliminacion para la tabla Alumno ========= */

DROP PROCEDURE IF EXISTS SP_DELETE_Alumno;
DELIMITER $$
CREATE PROCEDURE SP_DELETE_Alumno(_IdAlumno INT)
BEGIN

	UPDATE Humano as h
	INNER JOIN Alumno as a ON h.IdHumano=a.IdHumano
	SET h.Estatus = 0
	WHERE a.IdAlumno=_IdAlumno;

END $$
DELIMITER ;




















