DROP DATABASE IF EXISTS ControlEscolar;
CREATE DATABASE ControlEscolar;
USE ControlEscolar;

CREATE TABLE Pais(
	IdPais INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(25) NOT NULL,
	Primary key(IdPais)
);

CREATE TABLE Estado(
	IdEstado INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(25) NOT NULL,
	IdPais INT NOT NULL,
	Primary key(IdEstado),
	Foreign key(IdPais) references Pais(IdPais)
);

CREATE TABLE Municipio(
	IdMunicipio INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(25) NOT NULL,
	CP SMALLINT,
	IdEstado INT NOT NULL,
	Primary key(IdMunicipio),
	Foreign key(IdEstado) references Estado(IdEstado)
);

CREATE TABLE Contacto(
	IdContacto INT NOT NULL AUTO_INCREMENT,
	Direccion VARCHAR(50),
	Numero VARCHAR(5),
	Telefono NUMERIC(10,0),
	Celular NUMERIC(10,0),
	Correo VARCHAR(30),
	IdMunicipio INT,
	Primary key(IdContacto),
	Foreign key(IdMunicipio) references Municipio(IdMunicipio)
);
CREATE TABLE Humano(
	IdHumano INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(25) NOT NULL,
	APaterno VARCHAR(25) NOT NULL,
	AMaterno VARCHAR(25),
	Fecha_nacimiento DATE NOT NULL,
	Sexo VARCHAR(1),
	Estatus BIT,
	IdContacto INT,
	Primary key (IdHumano),
	Foreign key(IdContacto) references Contacto(IdContacto)	
);

CREATE TABLE Instituto(
	IdInstituto INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(50),
	IdContacto INT NOT NULL,
	Primary key(IdInstituto),
	Foreign key(Idcontacto) references Contaco(IdContacto)
);

