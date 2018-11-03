DROP DATABASE IF EXISTS ControlEscolar ;
SET NAMES utf8;
CREATE DATABASE ControlEscolar;
USE ControlEscolar;

SET NAMES utf8;
CREATE TABLE Pais(
	IdPais INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(35) NOT NULL,
	Primary key(IdPais)
)AUTO_INCREMENT=1000;


SET NAMES utf8;
CREATE TABLE Estado(
	IdEstado INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(35) NOT NULL,
	IdPais INT NOT NULL,
	Primary key(IdEstado),
	Foreign key(IdPais) references Pais(IdPais)
)AUTO_INCREMENT=1000;



CREATE TABLE Municipio(
	IdMunicipio INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(50) NOT NULL,
	IdEstado INT NOT NULL,
	Primary key(IdMunicipio),
	Foreign key(IdEstado) references Estado(IdEstado)
)AUTO_INCREMENT=1000;

CREATE TABLE Tipo_acentamiento(
	IdTipo_acentamiento INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(35),
	Primary key(IdTipo_acentamiento)
)AUTO_INCREMENT=1000;

CREATE TABLE Acentamiento(
	IdAcentamiento INT NOT NULL AUTO_INCREMENT,
	CP INT,
	Nombre VARCHAR(80) NOT NULL,
	IdTipo_acentamiento INT NOT NULL,
	IdMunicipio INT NOT NULL,
	Primary key(IdAcentamiento),
	Foreign key(IdMunicipio) references Municipio(IdMunicipio),
	Foreign key(IdTipo_acentamiento) references Tipo_acentamiento(IdTipo_acentamiento)

)AUTO_INCREMENT=1000;

CREATE TABLE Humano(
	IdHumano INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(25) NOT NULL,
	APaterno VARCHAR(25) NOT NULL,
	AMaterno VARCHAR(25),
	Fecha_nacimiento DATE NOT NULL,
	Sexo ENUM('F','M'),
	Calle VARCHAR(50),
	Numero VARCHAR(5),
	Telefono NUMERIC(10,0),
	Celular NUMERIC(10,0),
	Correo VARCHAR(30),
	IdAcentamiento INT NOT NULL,
	Estatus BIT,
	Primary key (IdHumano),
	Foreign key(IdAcentamiento) references Acentamiento(IdAcentamiento)
)AUTO_INCREMENT=20000;

CREATE TABLE Instituto(
	IdInstituto INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(80),
	Colonia VARCHAR(50),
	Calle VARCHAR(50),
	Numero VARCHAR(5),
	Telefono NUMERIC(10,0),
	Celular NUMERIC(10,0),
	Correo VARCHAR(30),
	IdMunicipio INT,
	Estatus BIT,
	Primary key(IdInstituto)
)AUTO_INCREMENT=1000;

CREATE TABLE Carrera(
	IdCarrera INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(80) NOT NULL,
	Estatus BIT NOT NULL,
	IdInstituto INT NOT NULL,
	Primary key(IdCarrera),
	Foreign key(IdInstituto) references Instituto(IdInstituto) 
)AUTO_INCREMENT=1000;

CREATE TABLE Alumno(
	IdAlumno INT NOT NULL AUTO_INCREMENT,
	IdHumano INT NOT NULL,
	IdCarrera INT NOT NULL,
	Fecha_inscripcion DATE,
	Primary key(IdAlumno),
	Foreign key(IdHumano) references Humano(IdHumano) ,
	Foreign key(IdCarrera) references Carrera(IdCarrera) 
)AUTO_INCREMENT=30000;


CREATE TABLE Puesto(
	IdPuesto INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(35) NOT NULL,
	Descripcion VARCHAR(80),
	Sueldo_quincenal DOUBLE,
	Primary key(IdPuesto)	
)AUTO_INCREMENT=1000;

CREATE TABLE Empleado(
	IdEmpleado INT NOT NULL AUTO_INCREMENT,
	IdHumano INT NOT NULL,
	IdPuesto INT NOT NULL,
	Grado_estudios ENUM('Primaria','Segundaria','Preparatoria','Licenciatura','Maestria','Doctorado'),
	Primary key(IdEmpleado),
	Foreign key(IdPuesto) references Puesto(IdPuesto) 
)AUTO_INCREMENT=50000;

CREATE TABLE Profesor(
	IdProfesor INT NOT NULL AUTO_INCREMENT,
	IdEmpleado INT NOT NULL,
	Especialidad VARCHAR(50),
	Folio_titulo INT NOT NULL,
	Primary key(IdProfesor),
	Foreign key(IdEmpleado) references Empleado(IdEmpleado) 
)AUTO_INCREMENT=40000;

CREATE TABLE Usuario(
	IdUsuario INT NOT NULL AUTO_INCREMENT,
	IdEmpleado INT NOT NULL,
	Usuario VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	Correo VARCHAR(40) NOT NULL,
	Admin BIT NOT NULL,
	Estatus BIT NOT NULL,
	Primary key(IdUsuario),
	Foreign key(IdEmpleado) references Empleado(IdEmpleado) 
)AUTO_INCREMENT=60000;

CREATE TABLE Periodo(
	IdPeriodo INT NOT NULL AUTO_INCREMENT,
	Fecha_inicio DATE NOT NULL,
	Fecha_Fin DATE NOT NULL,
	Primary key(IdPeriodo)
)AUTO_INCREMENT=1000;

CREATE TABLE Inscripcion(
	IdInscripcion INT NOT NULL AUTO_INCREMENT,
	IdAlumno INT NOT NULL,
	IdPeriodo INT NOT NULL,
	Estatus BIT NOT NULL,
	Primary key(IdInscripcion),
	Foreign key(IdAlumno) references Alumno(IdAlumno) ,
	Foreign key(IdPeriodo) references Periodo(IdPeriodo) 
)AUTO_INCREMENT=1000;

CREATE TABLE Materia(
	IdMateria INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(45) NOT NULL,
	Creditos INT NOT NULL,
	Estatus BIT NOT NULL,
	Primary key(IdMateria)
)AUTO_INCREMENT=1000;

CREATE TABLE Grupo(
	IdGrupo INT NOT NULL AUTO_INCREMENT,
	IdMateria INT NOT NULL,
	IdPeriodo INT NOT NULL,
	IdProfesor INT NOT NULL,
	Estatus BIT NOT NULL,
	Primary key(IdGrupo), 
	Foreign key(IdMateria) references Materia(IdMateria) ,
	Foreign key(IdPeriodo) references Periodo(IdPeriodo) ,
	Foreign key(IdProfesor) references Profesor(IdProfesor) 
)AUTO_INCREMENT=70000;

CREATE TABLE Historial_alumno(
	IdAlumno INT NOT NULL,
	Calificacion DOUBLE NOT NULL,
	Oportunidad TINYINT,
	IdGrupo INT NOT NULL,
	Foreign key(IdAlumno) references Alumno(IdAlumno) ,
	Foreign key(IdGrupo) references Grupo(IdGrupo) 
)AUTO_INCREMENT=80000;

CREATE TABLE Tabla(
	IdTabla INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(20) NOT NULL,
	Primary key(IdTabla)
)AUTO_INCREMENT=1000;

DROP TABLE IF EXISTS Sesion;
CREATE TABLE Sesion(
IdUsuario INT NOT NULL
);

INSERT INTO Sesion (IdUsuario) VALUES(60000);


DROP TABLE IF EXISTS Auditoria;
CREATE TABLE Auditoria(
	IdAuditoria INT NOT NULL AUTO_INCREMENT,
	Accion ENUM('Insert','Delete','Update'),
	IdTabla INT NOT NULL,
	IdUsuario INT NOT NULL,
	Fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
	Primary key(IdAuditoria),
	Foreign key(IdTabla) references Tabla(IdTabla) ,
	Foreign key(IdUsuario) references Usuario(IdUsuario) 
)AUTO_INCREMENT=90000;







CREATE TABLE Tipo_beca(
	IdTipo_beca INT NOT NULL AUTO_INCREMENT,
	Nombre VARCHAR(25) NOT NULL, 
	Monto_mensual DOUBLE NOT NULL,
	Estatus BIT NOT NULL,
	Primary key(IdTipo_beca)
)AUTO_INCREMENT=1000;

CREATE TABLE Beca(
	IdBeca INT NOT NULL AUTO_INCREMENT,
	IdAlumno INT NOT NULL,
	IdTipo_beca INT NOT NULL,
	IdPeriodo INT NOT NULL,
	Estatus BIT,
	Primary key(IdBeca),
	Foreign key(IdAlumno) references Alumno(IdAlumno) ,
	Foreign key(IdTipo_beca) references Tipo_beca(IdTipo_beca) ,
	Foreign key(IdPeriodo) references Periodo(IdPeriodo) 
)AUTO_INCREMENT=10000;