USE ControlEscolar;


/* ========= Consultas ========= */



DROP PROCEDURE IF EXISTS SP_SELECT_Profesor;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Profesor( IN _IdProfesor VARCHAR(10),
				     IN _Nombre_completo VARCHAR(80))
BEGIN

	SELECT IdProfesor AS ID, 
	CONCAT(H.Nombre,' ',H.APaterno,' ',H.AMaterno) AS Nombre,
	P.Especialidad
	FROM Profesor AS P
	INNER JOIN Empleado AS E ON P.IdEmpleado = E.IdEmpleado
	INNER JOIN Humano AS H ON E.IdHumano = H.IdHumano
	INNER JOIN Puesto AS Pu ON E.idPuesto = Pu.IdPuesto
	WHERE 
	P.IdProfesor LIKE CONCAT('%',_IdProfesor,'%')
	AND H.Estatus = 1
	HAVING
	Nombre LIKE CONCAT('%',_Nombre_completo,'%')
	ORDER BY P.IdProfesor;	

END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS SP_SELECT_IProfesor;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_IProfesor( IN _IdProfesor INT)
BEGIN
	SELECT Pr.IdProfesor AS ID, 
	CONCAT(H.Nombre,' ',H.APaterno,' ',H.AMaterno) AS Nombre,
	H.Fecha_nacimiento as 'Nacimiento',H.Sexo,H.Calle,H.Numero,H.Telefono,H.Celular,H.Correo,
	Ac.CP as CP,Ac.Nombre as Acentamiento,T.Nombre as 'Tipo de acentamiento', M.Nombre as Municipio,
	E.Nombre as Estado, P.Nombre as Pais,Em.Grado_estudios as 'Grado de estudios',
	Pu.Descripcion AS 'Tareas',
	Pu.Sueldo_quincenal AS 'Sueldo por quincena',
	Pr.Folio_titulo as Folio
 	FROM Profesor AS Pr
	INNER JOIN Empleado AS Em ON Pr.IdEmpleado = Em.IdEmpleado
	INNER JOIN Humano AS H ON Em.IdHumano = H.IdHumano
	INNER JOIN Acentamiento as Ac ON H.IdAcentamiento= Ac.IdAcentamiento
	INNER JOIN Tipo_acentamiento as T ON Ac.IdTipo_acentamiento=T.IdTipo_acentamiento
	INNER JOIN Municipio as M ON Ac.IdMunicipio = M.IdMunicipio
	INNER JOIN Estado as E ON M.IdEstado=E.IdEstado
	INNER JOIN Pais as P ON E.IdPais=P.IdPais
	INNER JOIN Puesto AS Pu ON Em.IdPuesto = Pu.IdPuesto
	WHERE 
	IdProfesor = _IdProfesor;

END $$
DELIMITER ;



/* ========= Eliminaciones ========= */


DROP PROCEDURE IF EXISTS SP_DELETE_Profesor;
DELIMITER $$
CREATE PROCEDURE SP_DELETE_Profesor(_IdProfesor INT)
BEGIN

	UPDATE Humano as H
	INNER JOIN Empleado as E ON H.IdHumano=a.IdHumano
	INNER JOIN Profesor as P ON E.IdEmpleado=P.IdProfesor
	SET H.Estatus = 0
	WHERE P.IdProfesor=_IdProfesor;

END $$
DELIMITER ;







/* ========= Actualizaciones ========= */


DROP PROCEDURE IF EXISTS SP_UPDATE_Profesor;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Profesor(	IN _IdProfesor INT,
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
					IN _Grado_estudios varchar(30),
					IN _Especialidad VARCHAR(50),
					IN _Folio_titulo INT)
BEGIN
	DECLARE _IdEmpleado INT;

	SET _IdEmpleado = (SELECT IdEmpleado FROM Profesor WHERE IdProfesor=_IdProfesor);
 	CALL SP_UPDATE_Empleado(_IdEmpleado,_Nombre,_APaterno,_AMaterno,_Fecha_nacimiento,_Sexo,_Calle,_Numero,_Telefono,_Celular,_Correo,_IdAcentamiento,1000,_Grado_estudios);
	SET NAMES utf8;
	UPDATE Profesor
	SET
		Especialidad=_Especialidad,
 		Folio_titulo = _Folio_titulo
	WHERE IdProfesor=_IdProfesor;



END $$
DELIMITER ;



/* ========= Insertados ========= */




DROP PROCEDURE IF EXISTS SP_INSERT_Profesor;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_Profesor(	IN _Nombre VARCHAR(25),
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
					IN _Grado_estudios varchar(30),
					IN _Especialidad VARCHAR(50),
					IN _Folio_titulo INT)
BEGIN

	CALL SP_INSERT_Empleado(@IdEmpleado,_Nombre,_APaterno,_AMaterno,_Fecha_nacimiento,_Sexo,_Calle,_Numero,_Telefono,_Celular,_Correo,_IdAcentamiento,1000,_Grado_estudios);

	INSERT INTO Profesor(IdEmpleado,Especialidad, Folio_titulo) VALUES
	(@IdEmpleado,_Especialidad,_Folio_titulo);


END $$
DELIMITER ;

/* ========= Triggers ========= */


DROP TRIGGER IF EXISTS T_INSERT_Profesor;
DELIMITER $$
CREATE TRIGGER T_INSERT_Profesor AFTER INSERT ON Profesor
FOR EACH ROW
BEGIN	
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Insert',(SELECT IdTabla FROM Tabla WHERE Nombre='Profesor' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;


DROP TRIGGER IF EXISTS T_UPDATE_Profesor;
DELIMITER $$
CREATE TRIGGER T_UPDATE_Profesor AFTER UPDATE ON Profesor
FOR EACH ROW
BEGIN			
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Update',(SELECT IdTabla FROM Tabla WHERE Nombre='Profesor' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;




