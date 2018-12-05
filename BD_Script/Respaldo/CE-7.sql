USE ControlEscolar;


INSERT INTO Humano(Nombre,APaterno,AMaterno,Fecha_nacimiento,Sexo,Calle,Numero,Telefono,Celular,Correo,IdAcentamiento,Estatus) VALUES
('Bernardo','Quintino','Guzman','1996-06-19','M','San pablo','11A',1234567890,1234567890,'b.quintinoguzman@ugto.mx',47603,1),
('Erick','Franco','Gaona','1996-01-25','M','calle1','66',1234567890,1234567890,'e.francogaona@ugto.mx',47001,1),
('Alumno1','AP1','AP2','1999-11-11','M','Calle1','123',1234567890,1234567890,'correo1@ugto.mx',47603,1),
('Alumno2','AP1','AP2','1999-11-11','F','Calle1','123',1234567890,1234567890,'correo1@ugto.mx',47001,1),
('Alumno3','AP1','AP2','1999-11-11','M','Calle1','123',1234567890,1234567890,'correo1@ugto.mx',43090,1),
('Profesor1','AP1','AP2','1999-11-11','F','Calle1','123',1234567890,1234567890,'correo1@ugto.mx',43090,0),
('Profesor2','AP1','AP2','1999-11-11','M','Calle1','123',1234567890,1234567890,'correo1@ugto.mx',43090,1),
('Empleado1','AP1','AP2','1999-11-11','F','Calle1','123',1234567890,1234567890,'correo1@ugto.mx',34396,0),
('Empleado2','AP1','AP2','1999-11-11','M','Calle1','123',1234567890,1234567890,'correo1@ugto.mx',34396,0);


INSERT INTO Instituto(Nombre,Colonia,Calle,Numero,Telefono,Celular,Correo,IdMunicipio,Estatus) VALUES
('Departamento de Estudios Multidisciplinarios','Yacatitas','Universidad','123',1234567890,1234567890,'correo1@ugto.mx',1340,1);


INSERT INTO Carrera(Nombre,Estatus,IdInstituto) VALUES
('Licenciatura en Ingenieria en Sistemas computacionales',1,1000),
('Licenciatura en Ingenieria en Comunicaciones y Electronica',1,1000),
('Licenciatura en Gestion Empresarial',1,1000),
('Licenciatura en la Ensenanza del Ingles',1,1000);


INSERT INTO Alumno(IdHumano,IdCarrera,Fecha_inscripcion) VALUES
(20000,1000,'2014-08-07'),
(20001,1000,'2014-08-07'),
(20002,1001,'2014-08-07'),
(20003,1001,'2014-08-07'),
(20004,1002,'2014-08-07');




INSERT INTO Puesto(Nombre,Descripcion,Sueldo_quincenal,Estatus) VALUES
('Profesor','Profesor',3000.00,1),
('Administrador','Modificacion del BD',3000.00,1),
('Secretario','Ver estadisticas',2000.00,1);


INSERT INTO Empleado(IdHumano,IdPuesto) VALUES
(20007,1000),
(20008,1001);


INSERT INTO Usuario(IdEmpleado,Usuario,Password,Admin,Estatus) VALUES
(50000,'Admin1',AES_ENCRYPT('123','BQG'),2,1),
(50001,'User',AES_ENCRYPT('123','BQG'),1,1),
(50001,'User',AES_ENCRYPT('123','BQG'),0,1);


INSERT INTO Periodo(Fecha_inicio,Fecha_Fin) VALUES
('2014-08-07','2014-12-7'),
('2015-01-07','2015-06-7'),
('2015-08-07','2015-12-7'),
('2016-01-07','2016-06-7'),
('2016-08-07','2016-12-7'),
('2017-01-07','2017-06-7'),
('2017-08-07','2017-12-7'),
('2018-01-07','2018-06-7'),
('2018-08-07','2018-12-7');



INSERT INTO Inscripcion(IdAlumno,IdPeriodo,Estatus) VALUES
(30000,1000,1),
(30001,1000,1),
(30002,1000,1),
(30003,1000,1),
(30004,1000,1),
(30000,1001,1),
(30001,1001,1),
(30002,1001,1),
(30003,1001,1),
(30004,1001,1),
(30000,1001,1),
(30001,1002,1),
(30002,1002,1),
(30003,1002,1),
(30004,1002,1),
(30000,1000,1),
(30001,1003,1),
(30002,1003,1),
(30003,1003,1),
(30004,1003,1),
(30000,1004,1),
(30001,1004,1),
(30002,1004,1),
(30003,1004,1),
(30004,1004,1),
(30000,1005,1),
(30001,1005,1),
(30002,1005,1),
(30003,1005,1),
(30004,1005,1),
(30000,1006,1),
(30001,1006,1),
(30002,1006,1),
(30003,1006,1),
(30004,1006,1),
(30000,1007,1),
(30001,1007,1),
(30002,1007,1),
(30003,1007,1),
(30004,1007,1),
(30000,1008,1),
(30001,1008,1),
(30002,1008,1),
(30003,1008,0),
(30004,1008,0);


INSERT INTO Materia(Nombre,Creditos,Estatus) VALUES
('Redes I', 6,1),
('Matematicas', 6,1),
('Ciencia', 6,0);

/*
INSERT INTO Grupo(IdMateria,IdPeriodo,IdProfesor,Estatus) VALUES
(1000,1008,40000,1),
(1001,1008,40000,1),
(1001,1008,40000,1);


INSERT INTO Historial_alumno(IdAlumno,Calificacion,Oportunidad,IdGrupo) VALUES
(30000,10,2,70000),
(30001,9,1,70000),
(30002,8.9,1,70000),
(30003,9.8,1,70000),
(30004,5,1,70000);
*/

INSERT INTO Tabla(Nombre) VALUES
('Humano'),
('Instituto'),
('Carrera'),
('Alumno'),
('Profesor'),
('Puesto'),
('Empleado'),
('Usuario'),
('Periodo'),
('Inscripcion'),
('Materia'),
('Grupo'),
('Instituto'),
('Historial_alumno'),
('Tabla'),
('Auditoria'),
('Tipo_beca'),
('Beca');


INSERT INTO Tipo_beca(Nombre,Monto_mensual,Estatus) VALUES
('SubeT',1000.00,1),
('Exelencia',3000.00,1),
('Manutencion',970.00,1);


INSERT INTO Beca(IdAlumno,IdTipo_beca,IdPeriodo,Estatus) VALUES
(30000,1000,1000,1);

















