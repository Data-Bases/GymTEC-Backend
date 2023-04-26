-- Insert SuperAdmin
INSERT INTO Empleado(Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Salario, Email, Contrasena)
            VALUES  (305320066,'Valesska', 'Blanco', 'Montoya', 'Cartago', 'Central', 'Aguacaliente', 2500000, 'valesskablanco@estudiantec.cr', 'pepe');


-- Insert Branches

INSERT INTO Sucursal(Nombre, Provincia, Canton, Distrito, Senas, CapacidadMaxima, FechaApertura, SpaAbierto, TiendaAbierta, Horario, IdEmpleadoAdmin)
            VALUES  ('GymASETEC', 'Cartago', 'Central', 'Oriental', '50m oeste y 200m norte de la entrada del ITCR', 100, '01-01-2000', 0,0, 'Lunes a Viernes: 7am-10pm, Sábado: 7am-12md, Domingo: CERRADO', 305320066)


-- Insert Tratamiento Spa
INSERT INTO TratamientoSpa(Nombre, Descripcion)
            VALUES  ('Masaje Relajante', 'Masaje relajante utilizando vapor y aceites esenciales'),
                    ('Masaje descarga muscular', 'Masaje perfecto para la recuperacion de los musculos'),
                    ('Sauna', 'Ideal sesion para desestresarse'),
                    ('ba�os a vapor', 'Son utiles para liberar toxinas y limpiar poros')

-- Insert Puestos
INSERT INTO Puesto(Nombre, Descripcion)
            VALUES  ('Administrador', 'Encargado de una sucursal'),
                    ('Instructor', 'Encargado de impartir una clase'),
                    ('Dependiente Spa', 'Encargado de los clientes en el spa'),
                    ('Dependiente tienda', 'Encargado de vender y atender clientes en la tienda')

-- Insert Tipos de Planillas
INSERT INTO TipoPlanilla(Nombre, Descripcion)
            VALUES  ('Mensual', 'Mes a mes se deposita el salario correspondiente'),
                    ('Pago por horas', 'Se calcula multiplicando las horas laboradas por el salario correspondiente'),
                    ('Pago por clase', 'Se calcula segun las clases impartidas multiplicado por el salario correspondiente')

-- Insert Empleados

-- Insert Servicios 
INSERT INTO ServiciosClases(Nombre, Descripcion)
            VALUES  ('Indoor Cycling', 'Clase de bicicleta estacionaria'),
                    ('Pilates', 'Clase de pilates relajante'),
                    ('Yoga', 'Clase de yoga para la flexibilidad'),
                    ('Zumba', 'Clase de Zumba con musica latina'),
                    ('Natacion', 'Clase de natacion ideal para principiantes')

-- Insert Equipo 
INSERT INTO TipoEquipo(Nombre, Descripcion)
            VALUES  ('Cintas de correr', 'Maquina para correr de manera estacionaria'),
                    ('Bicicleta', 'Maquina para practicar el ciclismo estacionario'),
                    ('Multigimnasios', 'Maquina para realizar gran cantidad de ejercicios'),
                    ('Remos', 'Maquina para entrenar el tren superior'),
                    ('Pesas', 'Necesario para cualquier entrenamiento')

SELECT * FROM Cliente;
SELECT * FROM Sucursal;