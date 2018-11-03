USE ControlEscolar;

/* ========= Insertar para la tabla Alumno ========= */
DROP PROCEDURE IF EXISTS SP_INSERT_Humano;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_Humano(	OUT _IdHumano INT,
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


	INSERT INTO Humano(Nombre,APaterno,AMaterno,Fecha_nacimiento,Sexo,Calle,Numero,Telefono,Celular,Correo,IdAcentamiento,Estatus) VALUES
	(_Nombre,_APaterno,_AMaterno,_Fecha_nacimiento,_Sexo,_Calle,_Numero,_Telefono,_Celular,_Correo,_IdAcentamiento,1);
	SET _IdHumano = (select idHumano from Humano order by idHumano desc limit 1);

END $$
DELIMITER ;

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



/* ========= Insertar para la tabla Periodo ========= */

DROP PROCEDURE IF EXISTS SP_INSERT_Periodo;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_Periodo(IN _Fecha_inicio DATE, IN _Fecha_fin DATE)
BEGIN

	
	INSERT INTO Periodo(Fecha_inicio,Fecha_Fin) VALUES
	(_Fecha_inicio,_Fecha_Fin);


END $$
DELIMITER ;














