USE ControlEscolar;


/* ========= Consultas ========= */



DROP PROCEDURE IF EXISTS SP_SELECT_Aluditoria;
DELIMITER $$
CREATE PROCEDURE SP_SELECT_Auditoria()
BEGIN

	SELECT Au.IdAuditoria,Au.Accion,T.Nombre AS Tabla,Au.IdUsuario, 
	U.Usuario, Au.Fecha	
	FROM Auditoria AS Au
	INNER JOIN Tabla AS T ON Au.IdTabla = T.IdTabla
	INNER JOIN Usuario AS U ON Au.IdUsuario = U.IdUsuario
	ORDER BY Au.IdAuditoria;	

END $$
DELIMITER ;


/* ========= Eliminaciones ========= */

        

/* ========= Actualizaciones ========= */


/* ========= Insertados ========= */


/* ========= Triggers ========= */





