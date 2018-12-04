USE ControlEscolar;


/* ========= Consultas ========= */




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
	AND Humano.Estatus = 1
        HAVING 
	Nombre LIKE CONCAT('%',_Nombre_completo,'%') 
	AND Inscripcion LIKE CONCAT('%',_Inscripcion,'%')
	AND Pagado LIKE CONCAT('%',_Pagado,'%')
	ORDER BY Alumno.IdAlumno;		

END $$
DELIMITER ;


DROP PROCEDURE IF EXISTS SP_SELECT_Carrera;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Carrera()
BEGIN

	SELECT * from carrera;		

END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS SP_SELECT_IAlumno;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_IAlumno(_idAlumno INT)
BEGIN

	SELECT A.IdAlumno as ID, CONCAT(H.Nombre,' ',H.APaterno,' ',H.AMaterno) AS Nombre,
	H.Fecha_nacimiento as 'Nacimiento',Sexo,Calle,Numero,Telefono,Celular,Correo,
	Ac.CP as CP,Ac.Nombre as Acentamiento,T.Nombre as 'Tipo de acentamiento', M.Nombre as Municipio,
	E.Nombre as Estado, P.Nombre as Pais
	
	FROM Alumno as A
	INNER JOIN Humano as H ON A.IdHumano = H.idHumano
	INNER JOIN Acentamiento as Ac ON H.IdAcentamiento= Ac.IdAcentamiento
	INNER JOIN Tipo_acentamiento as T ON Ac.IdTipo_acentamiento=T.IdTipo_acentamiento
	INNER JOIN Municipio as M ON Ac.IdMunicipio = M.IdMunicipio
	INNER JOIN Estado as E ON M.IdEstado=E.IdEstado
	INNER JOIN Pais as P ON E.IdPais=P.IdPais
	WHERE
	A.IdAlumno=_IdAlumno;		

END $$
DELIMITER ;



/* ========= Eliminaciones ========= */

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




/* ========= Actualizaciones ========= */

DROP PROCEDURE IF EXISTS SP_UPDATE_Alumno;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Alumno(	IN _IdAlumno INT,
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
					IN _IdAcentamiento INT,
					IN _IdCarrera INT,
					IN _Fecha_inscripcion DATE)
BEGIN
	DECLARE _IdHumano INT;

	SET _IdHumano = (SELECT IdHumano FROM Alumno WHERE IdAlumno=_IdAlumno);

	CALL SP_UPDATE_Humano(_IdHumano,_Nombre,_APaterno,_AMaterno,_Fecha_nacimiento,_Sexo,_Calle,_Numero,_Telefono,_Celular,_Correo,_IdAcentamiento);
	SET NAMES utf8;
	UPDATE Alumno
	SET
		IdCarrera=_IdCarrera,
		Fecha_inscripcion = _Fecha_inscripcion
	WHERE IdAlumno=_IdAlumno;



END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS SP_UPDATE_Inscripcion;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Inscripcion(IN _IdAlumno INT, IN _Estatus INT)
BEGIN
	
	DECLARE _IdPeriodo INT;	
	SET _IdPeriodo = (select idPeriodo from Periodo order by idPeriodo desc limit 1);
	
	UPDATE Inscripcion
	SET
		Estatus = _Estatus
	WHERE IdAlumno=_IdAlumno
	AND IdPeriodo=_IdPeriodo;



END $$
DELIMITER ;


/* ========= Insertados ========= */


DROP PROCEDURE IF EXISTS SP_INSERT_Alumno;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_Alumno(	IN _Nombre VARCHAR(25),
					IN _APaterno VARCHAR(25),
					IN _AMaterno VARCHAR(25),
					IN _Fecha_nacimiento DATE,
					IN _Sexo ENUM('F','M'),
					IN _Calle VARCHAR(50),
					IN _Numero VARCHAR(5),
					IN _Telefono DECIMAL(10,0),
					IN _Celular DECIMAL(10,0),
					IN _Correo VARCHAR(30),
					IN _IdAcentamiento INT,
					IN _IdCarrera INT,
					IN _Fecha_inscripcion DATE)
BEGIN

	CALL SP_INSERT_Humano(@IdHumano,_Nombre,_APaterno,_AMaterno,_Fecha_nacimiento,_Sexo,_Calle,_Numero,_Telefono,_Celular,_Correo,_IdAcentamiento);
	INSERT INTO Alumno(IdHumano,IdCarrera,Fecha_inscripcion) VALUES
	(@IdHumano,_IdCarrera,_Fecha_inscripcion);


END $$
DELIMITER ;


/* ========= Triggers ========= */



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




