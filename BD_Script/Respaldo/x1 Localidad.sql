USE ControlEscolar;


/* ========= Consultas ========= */




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








/* ========= Eliminaciones ========= */









/* ========= Actualizaciones ========= */






/* ========= Insertados ========= */




/* ========= Triggers ========= */





