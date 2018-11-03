DROP DATABASE IF EXISTS ControlEscolar;
CREATE DATABASE ControlEscolar;
USE ControlEscolar;

CREATE TABLE Humano(
	IdHumano INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(20) NOT NULL,
	APaterno VARCHAR(20) NOT NULL,
	AMaterno VARCHAR(20),
	Fecha_nacimiento DATE,
	Sexo VARCHAR(2),
	Estado BOOLEAN,
	IdContacto INT,	
	PRIMARY KEY (IdHumano)
);