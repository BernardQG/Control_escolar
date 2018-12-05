DROP DATABASE IF EXISTS ControlEscolar;
CREATE DATABASE ControlEscolar;
USE ControlEscolar;

CREATE TABLE Pais(
	IdPais INT NOT NULL AUTO_INCREMENT(1000),
	Nombre VARCHAR(25) NOT NULL,
	Primary key(IdPais)
);

