USE ControlEscolar;


/* ========= Consultas ========= */



DROP PROCEDURE IF EXISTS SP_SELECT_Empleado;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Empleado( IN _IdEmpleado VARCHAR(10),
				     IN _Nombre_completo VARCHAR(80),
			             IN _Puesto VARCHAR(80))
BEGIN

	SELECT IdEmpleado AS ID, 
	CONCAT(H.Nombre,' ',H.APaterno,' ',H.AMaterno) AS Nombre,
	P.Nombre AS Puesto
 	FROM Empleado AS E
	INNER JOIN Humano AS H ON E.IdHumano = H.IdHumano
	INNER JOIN Puesto AS P ON E.idPuesto = P.IdPuesto
	WHERE 
	E.IdEmpleado LIKE CONCAT('%',_IdEmpleado,'%')
	AND P.IdPuesto<>1000	
	AND H.Estatus = 1
	HAVING
	Nombre LIKE CONCAT('%',_Nombre_completo,'%')
	AND Puesto LIKE CONCAT('%',_Puesto,'%')
	ORDER BY E.IdEmpleado;	

END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS SP_SELECT_IEmpleado;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_IEmpleado( IN _IdEmpleado INT)
BEGIN
	SELECT Em.IdEmpleado AS ID, 
	CONCAT(H.Nombre,' ',H.APaterno,' ',H.AMaterno) AS Nombre,
	H.Fecha_nacimiento as 'Nacimiento',H.Sexo,H.Calle,H.Numero,H.Telefono,H.Celular,H.Correo,
	Ac.CP as CP,Ac.Nombre as Acentamiento,T.Nombre as 'Tipo de acentamiento', M.Nombre as Municipio,
	E.Nombre as Estado, P.Nombre as Pais,Em.Grado_estudios as 'Grado de estudios',
	Pu.Descripcion AS 'Tareas',
	Pu.Sueldo_quincenal AS 'Sueldo por quincena'
 	FROM Empleado AS Em
	INNER JOIN Humano AS H ON Em.IdHumano = H.IdHumano
	INNER JOIN Acentamiento as Ac ON H.IdAcentamiento= Ac.IdAcentamiento
	INNER JOIN Tipo_acentamiento as T ON Ac.IdTipo_acentamiento=T.IdTipo_acentamiento
	INNER JOIN Municipio as M ON Ac.IdMunicipio = M.IdMunicipio
	INNER JOIN Estado as E ON M.IdEstado=E.IdEstado
	INNER JOIN Pais as P ON E.IdPais=P.IdPais
	INNER JOIN Puesto AS Pu ON Em.IdPuesto = Pu.IdPuesto
	WHERE 
	IdEmpleado = _IdEmpleado;

END $$
DELIMITER ;


DROP PROCEDURE IF EXISTS SP_SELECT_Puesto;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Puesto()
BEGIN

	SELECT * FROM Puesto;

END $$
DELIMITER ;







/* ========= Eliminaciones ========= */


DROP PROCEDURE IF EXISTS SP_DELETE_Empleado;
DELIMITER $$
CREATE PROCEDURE SP_DELETE_Empleado(_IdEmpleado INT)
BEGIN

	UPDATE Humano as h
	INNER JOIN Empleado as E ON h.IdHumano=E.IdHumano
	SET h.Estatus = 0
	WHERE E.IdEmpleado=_IdEmpleado;

END $$
DELIMITER ;







/* ========= Actualizaciones ========= */


DROP PROCEDURE IF EXISTS SP_UPDATE_Empleado;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Empleado(	IN _IdEmpleado INT,
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
					IN _IdPuesto INT,
					IN _Grado_estudios varchar(30))
BEGIN
	DECLARE _IdHumano INT;

	SET _IdHumano = (SELECT IdHumano FROM Empleado WHERE IdEmpleado=_IdEmpleado);

	CALL SP_UPDATE_Humano(_IdHumano,_Nombre,_APaterno,_AMaterno,_Fecha_nacimiento,_Sexo,_Calle,_Numero,_Telefono,_Celular,_Correo,_IdAcentamiento);
	SET NAMES utf8;
	UPDATE Empleado
	SET
		IdPuesto=_IdPuesto,
		Grado_estudios = _Grado_estudios
	WHERE IdEmpleado=_IdEmpleado;



END $$
DELIMITER ;



/* ========= Insertados ========= */




DROP PROCEDURE IF EXISTS SP_INSERT_uEmpleado;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_uEmpleado(	IN _Nombre VARCHAR(25),
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
					IN _IdPuesto INT,
					IN _Grado_estudios varchar(30))
BEGIN

	CALL SP_INSERT_Humano(@IdHumano,_Nombre,_APaterno,_AMaterno,_Fecha_nacimiento,_Sexo,_Calle,_Numero,_Telefono,_Celular,_Correo,_IdAcentamiento);
	INSERT INTO Empleado(IdHumano,IdPuesto,Grado_estudios) VALUES
	(@IdHumano,_IdPuesto,_Grado_estudios);
	
	


END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS SP_INSERT_Empleado;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_Empleado(	OUT _IdEmpleado INT,
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
					IN _IdPuesto INT,
					IN _Grado_estudios varchar(30))
BEGIN

	CALL SP_INSERT_Humano(@IdHumano,_Nombre,_APaterno,_AMaterno,_Fecha_nacimiento,_Sexo,_Calle,_Numero,_Telefono,_Celular,_Correo,_IdAcentamiento);
	INSERT INTO Empleado(IdHumano,IdPuesto,Grado_estudios) VALUES
	(@IdHumano,_IdPuesto,_Grado_estudios);
	SET _IdEmpleado = (select idEmpleado from Empleado order by idEmpleado desc limit 1);
	


END $$
DELIMITER ;

/* ========= Triggers ========= */


DROP TRIGGER IF EXISTS T_INSERT_Empleado;
DELIMITER $$
CREATE TRIGGER T_INSERT_Empleado AFTER INSERT ON Empleado
FOR EACH ROW
BEGIN	
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Insert',(SELECT IdTabla FROM Tabla WHERE Nombre='Empleado' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;


DROP TRIGGER IF EXISTS T_UPDATE_Empleado;
DELIMITER $$
CREATE TRIGGER T_UPDATE_Empleado AFTER UPDATE ON Empleado
FOR EACH ROW
BEGIN			
	INSERT INTO Auditoria (Accion,IdTabla,IdUsuario) VALUES
	('Update',(SELECT IdTabla FROM Tabla WHERE Nombre='Empleado' LIMIT 1),(SELECT IdUsuario FROM Sesion LIMIT 1));

END $$
DELIMITER ;




