-- MM/dd/yyyy insert date format
-- dd/MM/yyyy output date format

-- Insert SuperAdmin
INSERT INTO Empleado(Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Salario, Email, Contrasena)
            VALUES  (305320066,'Valesska', 'Blanco', 'Montoya', 'Cartago', 'Central', 'Aguacaliente', 2500000, 'valesskablanco@estudiantec.cr', 'pepe');

Update Empleado
Set Contrasena = CONVERT(VARCHAR(32), HashBytes('MD5', 'pepe'), 2)
Where Cedula = 305320066;

-- Insert Branches

INSERT INTO Sucursal(Nombre, Provincia, Canton, Distrito, Senas, CapacidadMaxima, FechaApertura, SpaAbierto, TiendaAbierta, Horario, IdEmpleadoAdmin)
            VALUES  ('GymASETEC', 'Cartago', 'Central', 'Oriental', '50m oeste y 200m norte de la entrada del ITCR', 100, '01-01-2000', 0,0, 'Lunes a Viernes: 7am-10pm, Sábado: 7am-12md, Domingo: CERRADO', 305320066),
		    ('GymLimon', 'Limon', 'Limon', 'Roosevelt', '100m norte de parque central de Roosevelt', 50, '05-08-2010', 1, 0, 'Lunes a Viernes: 5am-7pm, Sabado y Domingo: CERRADO', 305320066),
		    ('GymAlajuela', 'Alajuela', 'Alajuela', 'Alajuela', '25m este y 25m sur de la entrada principal del TEC', 100, '03-04-2009', 0, 1, 'Lunes a Viernes: 7am-10pm, Sábado: 7am-12md, Domingo: CERRADO', 305320066),
		    ('GymSC', 'Alajuela', 'San Carlos', 'Ciudad Quesada', '250m norte del ebais San Roque', 75, '08-09-2007', 1, 1, 'Lunes a Viernes: 7am-10pm, Sábado: 7am-12md, Domingo: CERRADO', 305320066);

-- Insert Tratamiento Spa
INSERT INTO TratamientoSpa(Nombre, Descripcion)
            VALUES  ('Masaje Relajante', 'Masaje relajante utilizando vapor y aceites esenciales'),
                    ('Masaje descarga muscular', 'Masaje perfecto para la recuperacion de los musculos'),
                    ('Sauna', 'Ideal sesion para desestresarse'),
                    ('bannos a vapor', 'Son utiles para liberar toxinas y limpiar poros')

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
INSERT INTO Servicios(Nombre, Descripcion)
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

-- Insert Productos 
INSERT INTO Producto(CodigoBarras, Nombre, Costo, Descripcion)
	VALUES (564897, 'SPORT REGIMEN PRE WORKOUT', 29950, 'Un producto avanzado para producir una sesión de entrenamiento más productiva.'),
               (456875, 'AMINO DECANATE', 25885, 'Hace que tus músculos se recuperen y se reconstruyan de forma rápida y efectiva.'),
               (784569, 'AP CREATINA - 60 SERVIDAS', 24900, 'Este suplemento de grado farmacéutico contiene monohidrato de creatina');

-- Insert Numero de Telefono
INSERT INTO NumerosTelefono (NumeroTelefono, NombreSucursal) VALUES (25521659, 'GymASETEC')
INSERT INTO NumerosTelefono (NumeroTelefono, NombreSucursal) VALUES (25517294, 'GymASETEC')
INSERT INTO NumerosTelefono (NumeroTelefono, NombreSucursal) VALUES (27356981, 'GymLimon')
INSERT INTO NumerosTelefono (NumeroTelefono, NombreSucursal) VALUES (27356999, 'GymLimon')
INSERT INTO NumerosTelefono (NumeroTelefono, NombreSucursal) VALUES (25896431, 'GymSC')
INSERT INTO NumerosTelefono (NumeroTelefono, NombreSucursal) VALUES (25884632, 'GymSC')


