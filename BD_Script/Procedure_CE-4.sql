USE ControlEscolar;


DROP PROCEDURE IF EXISTS SP_UPDATE_Sesion;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Sesion(IN _IdUsuario INT)
BEGIN

	DELETE FROM Sesion;
	INSERT INTO Sesion (IdUsuario) VALUES(_IdUsuario);	


END $$
DELIMITER ;


/* ========= Actualizaciones para la tabla Alumno ========= */

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

# select name from mysql.proc where db='controlescolar';



/* ========= Actualizaciones para la tabla Periodo ========= */

DROP PROCEDURE IF EXISTS SP_UPDATE_Periodo;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Periodo(IN _IdPeriodo INT, IN _Fecha_inicio DATE, IN Fecha_fin DATE)
BEGIN
	
	UPDATE Periodo
	SET
		Fecha_Fin = _Fecha_fin,
		Fecha_inicio = _Fecha_inicio

	WHERE IdPeriodo=_IdPerido;

END $$
DELIMITER ;












