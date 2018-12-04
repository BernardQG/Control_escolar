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
CREATE TRIGGER T_UPDATE_Alumno AFTER UPDATE ON Alumno
FOR EACH ROW
BEGIN	
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Update',(SELECT IdTabla FROM Tabla WHERE Nombre='Alumno' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;





/* ========= Disparadores para la tabla Perido =========*/





DROP TRIGGER IF EXISTS T_INSERT_Periodo;
DELIMITER $$
CREATE TRIGGER T_INSERT_Periodo AFTER INSERT ON Periodo
FOR EACH ROW
BEGIN	
	
	
	DECLARE _IdPeriodo INT;
	SET _IdPeriodo = (select idPeriodo from Periodo order by idPeriodo desc limit 1);	

	INSERT INTO Inscripcion(IdAlumno,idPeriodo,Estatus) SELECT IdAlumno,_IdPeriodo,0 FROM ALUMNO;	

	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Insert',(SELECT IdTabla FROM Tabla WHERE Nombre='Periodo' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;


DROP TRIGGER IF EXISTS T_UPDATE_Periodo;
DELIMITER $$
CREATE TRIGGER T_UPDATE_Periodo AFTER UPDATE ON Periodo
FOR EACH ROW
BEGIN			
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Update',(SELECT IdTabla FROM Tabla WHERE Nombre='Periodo' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;



