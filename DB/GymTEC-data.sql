INSERT INTO Empleado(cedula, nombre, apellido1, apellido2, provincia, canton, distrito, email, contrasena, HorasLaboradas, NombreSucursal, IdTipoPlanilla, IdPuesto, salario)
VALUES 
(123456789, 'Juan', 'Perez', 'Gonzalez', 'San Jose', 'San Jose', 'Catedral', 'juan.perez@gmail.com', '1234', 40, 'GymASETEC', 1, 2, 15000),
(987654321, 'Maria', 'Gomez', 'Rodriguez', 'Heredia', 'Heredia', 'San Francisco', 'maria.gomez@gmail.com', '1234', 35, 'GymAlajuela', 2, 3, 17000)


-- Agregar datos a la tabla de clientes
INSERT INTO Cliente(Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Email, contrasena, FechaNacimiento, Peso, IMC)
VALUES 
(123456789, 'Carlos', 'Sanchez', 'Garcia', 'San Jose', 'Escazu', 'San Rafael', 'carlos.sanchez@gmail.com', '1234', '02/14/1985', 70, 22),
(987654321, 'Ana', 'Martinez', 'Fernandez', 'Heredia', 'Belén', 'San Antonio', 'ana.martinez@gmail.com', '1234', '06/24/1992', 65, 20)


-- Agregar datos a la tabla de equipos
INSERT INTO Maquina(NumeroSerie, Marca, Costo, NombreSucursal, IdEquipo)
VALUES 
(1, 'LifeFitness', 500000, 'GymAlajuela', 1),
(2, 'Precor', 750000, 'GymASETEC', 2)