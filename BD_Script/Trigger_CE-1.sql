USE ControlEscolar;


/* ========= Disparadores para la tabla Alumno =========*/

DROP TRIGGER IF EXISTS T_INSERT_Alumno;
DELIMITER $$
CREATE TRIGGER T_INSERT_Alumno AFTER INSERT ON Alumno
FOR EACH ROW
BEGIN	
	DECLARE _IdAlumno INT;
	DECLARE _IdPeriodo INT;
	SET _IdAlumno = (select idAlumno from Alumno order by idAlumno desc limit 1);	
	SET _IdPeriodo = (select idPeriodo from Periodo order by idPeriodo desc limit 1);
	INSERT INTO Inscripcion(IdAlumno,IdPeriodo,Estatus) VALUES
	(_IdAlumno,_IdPeriodo,0);

	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Insert',(SELECT IdTabla FROM Tabla WHERE Nombre='Alumno' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;



DROP TRIGGER IF EXISTS T_UPDATE_Alumno;
DELIMITER $$
CREATE TRIGGER T_UDATE_Alumno AFTER UPDATE ON Alumno
FOR EACH ROW
BEGIN	
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Update',(SELECT IdTabla FROM Tabla WHERE Nombre='Alumno' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;







