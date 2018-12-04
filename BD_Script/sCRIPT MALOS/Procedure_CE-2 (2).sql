USE ControlEscolar;

/* ========= Consultas inciciales ========= */
DROP PROCEDURE IF EXISTS SP_SELECT_DataBase;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_DataBase()
BEGIN

	SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'ControlEscolar';

END $$
DELIMITER ;




/* ========= Consultas para la tabla Usuario ========= */



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
CREATE PROCEDURE SP_SELECT_Usuario(_Usuario VARCHAR(30),_Llave VARCHAR(5))
BEGIN

	SELECT U.IdUsuario,U.IdEmpleado,U.Usuario,AES_DECRYPT(Password,'BQG') as 'Contraseña',H.Correo as Correo FROM Usuario AS U
	INNER JOIN Empleado AS E ON U.IdEmpleado=E.IdEmpleado
	INNER JOIN Humano AS H ON E.IdHumano = H.IdHumano
	WHERE
	U.Usuario =_Usuario;


END $$
DELIMITER ;


DROP PROCEDURE IF EXISTS SP_SELECT_Admin;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Admin()
BEGIN

	DECLARE _IdUsuario INT;
	SET _IdUsuario = (Select IdUsuario FROM Sesion LIMIT 1);
	SELECT * FROM Usuario WHERE IdUsuario=_Idusuario AND Admin=1;


END $$
DELIMITER ;







/* ========= Consultas para la localizacion ========= */




DROP PROCEDURE IF EXISTS SP_SELECT_Pais;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Pais()
BEGIN

	SELECT * from Pais;		

END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS SP_SELECT_Estado;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Estado(IN _IdPais INT)
BEGIN

	SELECT * from Estado WHERE IdPais=_IdPais;		
	
END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS SP_SELECT_Municipio;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Municipio(IN _IdEstado INT)
BEGIN

	SELECT * from Municipio WHERE IdEstado=_IdEstado;		

END $$
DELIMITER ;

DROP PROCEDURE IF EXISTS SP_SELECT_Acentamiento;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Acentamiento(IN _IdMunicipio INT)
BEGIN

	SELECT Ac.IdAcentamiento,Ac.CP, Ac.Nombre as Acentamiento, Ta.Nombre AS Tipo from Acentamiento AS Ac
	INNER JOIN Tipo_acentamiento AS Ta ON Ac.IdTipo_acentamiento = Ta.IdTipo_acentamiento
	WHERE IdMunicipio=_IdMunicipio;		

END $$
DELIMITER ;



DROP PROCEDURE IF EXISTS SP_SELECT_CP;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_CP(IN _CP VARCHAR(8))
BEGIN

	SELECT Ac.IdAcentamiento AS IdAcentamiento, Ac.Nombre AS Acentamiento,T.Nombre as Tipo,M.Nombre as Municipio,E.Nombre as Estado, P.Nombre as Pais
	FROM Acentamiento AS Ac
	INNER JOIN Tipo_acentamiento AS T ON Ac.IdTipo_acentamiento = T.IdTipo_acentamiento 
	INNER JOIN Municipio AS M ON Ac.IdMunicipio=M.IdMunicipio
	INNER JOIN Estado AS E ON M.IdEstado = E.IdEstado
	INNER JOIN Pais AS P ON E.IdPais = P.IdPais
	WHERE Ac.CP LIKE concat('%',_cp,'%');	

END $$
DELIMITER ;






/* ========= Consultas para la tabla Alumno ========= */





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




/* ========= Consultas para la tabla Periodo ========= */





DROP PROCEDURE IF EXISTS SP_SELECT_Periodo;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Periodo(IN _IdPeriodo VARCHAR(8))
BEGIN

	SELECT * FROM Periodo WHERE IdPeriodo LIKE CONCAT('%',_IdPeriodo,'%');	

END $$
DELIMITER ;



















