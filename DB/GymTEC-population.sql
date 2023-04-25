INSERT INTO Cliente(Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Email, Contrasena, FechaNacimiento)
VALUES	(305320066,'Valesska', 'Blanco', 'Montoya', 'Cartago', 'Central', 'Aguacaliente', 'valesskablanco@estudiantec.cr', 'pepe', '2001-05-22');

INSERT INTO Cliente(Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Email, Contrasena, FechaNacimiento)
VALUES	(208200172,'Diana', 'Mejias', 'Hernandez', 'Cartago', 'Central', 'Oriental', 'dmejias@estudiantec.cr', 'Chloe', '2001-08-08');

INSERT INTO Empleado(Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Salario, Email, Contrasena, HorasLaboradas)
VALUES (305320066,'Valesska', 'Blanco', 'Montoya', 'Cartago', 'Central', 'Aguacaliente', 2300000, 'valesskablanco@estudiantec.cr', 'pepe', 48);

INSERT INTO Sucursal (Nombre, Provincia, Canton, Distrito, Senas, CapacidadMaxima, FechaApertura, TiendaAbierta, SpaAbierto, IdEmpleadoAdmin)
VALUES ('GymASETEC', 'Cartago', 'Cartago', 'Oriental', '50m este y 200m Norte de la entrada del ITCR', 100, '01-01-2000', 0, 1, 305320066)

SELECT * FROM Cliente;
SELECT * FROM Sucursal;