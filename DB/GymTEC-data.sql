-- Agregar datos a la tabla de empleados
INSERT INTO Empleado(cedula, nombre, apellido1, apellido2, provincia, canton, distrito, email, contrasena, HorasLaboradas, NombreSucursal, IdTipoPlanilla, IdPuesto, salario)
VALUES 
(123456789, 'Juan', 'Perez', 'Gonzalez', 'San Jose', 'San Jose', 'Catedral', 'juan.perez@gmail.com', CONVERT(VARCHAR(32), HashBytes('MD5', 'pepe'), 2), 40, 'GymASETEC', 1, 2, 15000),
(987654321, 'Maria', 'Gomez', 'Rodriguez', 'Heredia', 'Heredia', 'San Francisco', 'maria.gomez@gmail.com', CONVERT(VARCHAR(32), HashBytes('MD5', 'pepe'), 2), 35, 'GymASETEC', 2, 3, 17000),
(147258369, 'Maria', 'Guitierrez', 'Gonzalez', 'San Jose', 'San Jose', 'Catedral', 'maria.guitierres@gmail.com', CONVERT(VARCHAR(32), HashBytes('MD5', 'pepe'), 2), 40, 'GymAlajuela', 2, 2, 15000),
(741852963, 'Julio', 'Mejias', 'Rodriguez', 'Puntarenas', 'Buenos Aires', 'Buenos Aires Francisco', 'julio.mejias@gmail.com', CONVERT(VARCHAR(32), HashBytes('MD5', 'pepe'), 2), 35, 'GymSC', 2, 2, 17000)


-- Agregar datos a la tabla de clientes
INSERT INTO Cliente(Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Email, contrasena, FechaNacimiento, Peso, IMC)
VALUES 
(208200172, 'Carlos', 'Sanchez', 'Garcia', 'San Jose', 'Escazu', 'San Rafael', 'carlos.sanchez@gmail.com', CONVERT(VARCHAR(32), HashBytes('MD5', 'pepe'), 2), '02/14/1985', 70, 22),
(204750170, 'Ana', 'Martinez', 'Fernandez', 'Heredia', 'Belén', 'San Antonio', 'ana.martinez@gmail.com', CONVERT(VARCHAR(32), HashBytes('MD5', 'pepe'), 2), '06/24/1992', 65, 20)


-- Agregar datos a la tabla de equipos
INSERT INTO Maquina(NumeroSerie, Marca, Costo, NombreSucursal, IdEquipo)
VALUES 
(1, 'LifeFitness', 500000, 'GymAlajuela', 1),
(2, 'Precor', 750000, 'GymASETEC', 2)

-- Agregar datos en tratamiento sucursal
INSERT INTO TratamientoSucursal(IdTratamientoSpa, NombreSucursal) VALUES (1, 'GymASETEC');
INSERT INTO TratamientoSucursal(IdTratamientoSpa, NombreSucursal) VALUES (2, 'GymASETEC');
INSERT INTO TratamientoSucursal(IdTratamientoSpa, NombreSucursal) VALUES (2, 'GymLimon');

-- Agregar datos en servicios sucursal
INSERT INTO ServiciosSucursal(IdServicio, NombreSucursal) VALUES (1, 'GymASETEC'), (2, 'GymASETEC'), (2, 'GymLimon');

-- Agregar datos en producto sucursal
INSERT INTO ProductoSucursal(CodigoBarrasProducto, NombreSucursal) VALUES (564897, 'GymASETEC'), (456875, 'GymASETEC'), (784569, 'GymAlajuela');


INSERT INTO Clase(IdServicio, HoraInicio, HoraFinalizacion, Fecha, Capacidad, EsGrupal, CedulaEmpleado, NombreSucursal)
                            VALUES  (1, '8/5/2023 14:00:00', '8/5/2023 15:00:00', '05-09-2023', 1, 1, 123456789, 'GymASETEC');

INSERT INTO Clase(IdServicio, HoraInicio, HoraFinalizacion, Fecha, Capacidad, EsGrupal, CedulaEmpleado, NombreSucursal)
                            VALUES  (1, '8/5/2023 14:00:00', '8/5/2023 15:00:00', '05-10-2023', 1, 1, 123456789, 'GymASETEC');

INSERT INTO Clase(IdServicio, HoraInicio, HoraFinalizacion, Fecha, Capacidad, EsGrupal, CedulaEmpleado, NombreSucursal)
                            VALUES  (2, '8/5/2023 14:00:00', '8/5/2023 15:00:00', '05-10-2023', 10, 1, 987654321, 'GymASETEC');

INSERT INTO Clase(IdServicio, HoraInicio, HoraFinalizacion, Fecha, Capacidad, EsGrupal, CedulaEmpleado, NombreSucursal)
                            VALUES  (3, '8/5/2023 14:00:00', '8/5/2023 15:00:00', '05-09-2023', 10, 1, 741852963, 'GymSC');

INSERT INTO Clase(IdServicio, HoraInicio, HoraFinalizacion, Fecha, Capacidad, EsGrupal, CedulaEmpleado, NombreSucursal)
                            VALUES  (1, '8/5/2023 14:00:00', '8/5/2023 15:00:00', '05-10-2023', 10, 1, 741852963, 'GymSC');

INSERT INTO Clase(IdServicio, HoraInicio, HoraFinalizacion, Fecha, Capacidad, EsGrupal, CedulaEmpleado, NombreSucursal)
                            VALUES  (3, '8/5/2023 14:00:00', '8/5/2023 15:00:00', '05-11-2023', 10, 1, 741852963, 'GymSC');

INSERT INTO Clase(IdServicio, HoraInicio, HoraFinalizacion, Fecha, Capacidad, EsGrupal, CedulaEmpleado, NombreSucursal)
                            VALUES  (2, '8/5/2023 14:00:00', '8/5/2023 15:00:00', '05-10-2023', 1, 0, 147258369, 'GymAlajuela');

INSERT INTO Clase(IdServicio, HoraInicio, HoraFinalizacion, Fecha, Capacidad, EsGrupal, CedulaEmpleado, NombreSucursal)
                            VALUES  (3, '8/5/2023 14:00:00', '8/5/2023 15:00:00', '05-11-2023', 15, 1, 147258369, 'GymAlajuela');

Insert into ClienteClase(IdClase, CedulaCliente) Values(1,208200172);
Insert into ClienteClase(IdClase, CedulaCliente) Values(3,123456789);
Insert into ClienteClase(IdClase, CedulaCliente) Values(7,204750170);