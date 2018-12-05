USE ControlEscolar;


INSERT INTO Humano(Nombre,APaterno,AMaterno,Fecha_nacimiento,Sexo,Calle,Numero,Telefono,Celular,Correo,IdAcentamiento,Estatus) VALUES
('XXX','XXX','XXX','1990-01-01','M','X','X',1234567890,1234567890,'b.quintinoguzman@ugto.mx',47603,1);



INSERT INTO Instituto(Nombre,Colonia,Calle,Numero,Telefono,Celular,Correo,IdMunicipio,Estatus) VALUES
('Departamento de Estudios Multidisciplinarios','Yacatitas','Universidad','123',1234567890,1234567890,'correo1@ugto.mx',1340,1);


INSERT INTO Carrera(Nombre,Estatus,IdInstituto) VALUES
('Licenciatura en Ingenieria en Sistemas computacionales',1,1000),
('Licenciatura en Ingenieria en Comunicaciones y Electronica',1,1000),
('Licenciatura en Gestion Empresarial',1,1000),
('Licenciatura en la Ensenanza del Ingles',1,1000);



INSERT INTO Puesto(Nombre,Descripcion,Sueldo_quincenal,Estatus) VALUES
('Profesor','Profesor',3000.00,1),
('Administrador','Modificacion del BD',3000.00,1),
('Secretario','Ver estadisticas',2000.00,1),
('Director','Director',5000.00,1),
('Aseo','Limpieza de las instalaciones',2000.00,1),
('Guardia','Seguridad y vigilancia',2000.00,1),
('Coordinador','Coordinador',2000.00,1),
('Mantenimiento','Mantenimiento',2000.00,1),
('Velador','Velador',2000.00,1),
('Contador','Gestion de presupuesto',3000.00,1);


INSERT INTO Empleado(IdHumano,IdPuesto) VALUES
(20000,1001);


INSERT INTO Usuario(IdEmpleado,Usuario,Password,Admin,Estatus) VALUES
(50000,'Admin',AES_ENCRYPT('1234','BQG'),2,1);


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


