USE ControlEscolar;


/* ========= Consultas ========= */






DROP PROCEDURE IF EXISTS SP_SELECT_Periodo;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Periodo(IN _IdPeriodo VARCHAR(8))
BEGIN

	SELECT * FROM Periodo WHERE IdPeriodo LIKE CONCAT('%',_IdPeriodo,'%');	

END $$
DELIMITER ;







/* ========= Eliminaciones ========= */










/* ========= Actualizaciones ========= */


DROP PROCEDURE IF EXISTS SP_UPDATE_Periodo;
DELIMITER $$
CREATE PROCEDURE SP_UPDATE_Periodo(IN _IdPeriodo INT, IN _Fecha_inicio DATE, IN _Fecha_fin DATE)
BEGIN
	
	UPDATE Periodo
	SET
		Fecha_Fin = _Fecha_fin,
		Fecha_inicio = _Fecha_inicio

	WHERE IdPeriodo=_IdPeriodo;

END $$
DELIMITER ;







/* ========= Insertados ========= */

DROP PROCEDURE IF EXISTS SP_INSERT_Periodo;
DELIMITER $$
CREATE PROCEDURE SP_INSERT_Periodo(IN _Fecha_inicio DATE, IN _Fecha_fin DATE)
BEGIN

	
	INSERT INTO Periodo(Fecha_inicio,Fecha_Fin) VALUES
	(_Fecha_inicio,_Fecha_Fin);


END $$
DELIMITER ;








/* ========= Triggers ========= */



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




