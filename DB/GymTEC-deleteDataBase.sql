ALTER TABLE ClaseFecha DROP CONSTRAINT ClaseEnFecha;
ALTER TABLE Clase DROP CONSTRAINT EmpleadoEncargadoClase;
ALTER TABLE Empleado DROP CONSTRAINT TipoPlanillaEmpleado;
ALTER TABLE Empleado DROP CONSTRAINT TrabajaEn;
ALTER TABLE Empleado DROP CONSTRAINT PuestoEmpleado;
ALTER TABLE NumerosTelefono DROP CONSTRAINT NumeroTelefonoSucursal;
ALTER TABLE ServiciosSucursal DROP CONSTRAINT TipoClaseImpartida;
ALTER TABLE ServiciosSucursal DROP CONSTRAINT SucursalClaseImpartida;
ALTER TABLE Maquina DROP CONSTRAINT UbicacionSucursalMaquina;
ALTER TABLE Maquina DROP CONSTRAINT TipoMaquina;
ALTER TABLE ClienteClase DROP CONSTRAINT ClienteRecibeClase;
ALTER TABLE ClienteClase DROP CONSTRAINT TipoDeClase;
ALTER TABLE Sucursal DROP CONSTRAINT EmpleadoAdministraSucursal;
ALTER TABLE TratamientoSucursal DROP CONSTRAINT TipoTratamiento;
ALTER TABLE TratamientoSucursal DROP CONSTRAINT SucursalRealizaTratamiento;
ALTER TABLE ProductoSucursal DROP CONSTRAINT TipoProducto;
ALTER TABLE ProductoSucursal DROP CONSTRAINT SucursalTieneProducto;
ALTER TABLE Cliente DROP CONSTRAINT df_peso;
ALTER TABLE Cliente DROP CONSTRAINT df_imc;
ALTER TABLE Empleado DROP CONSTRAINT df_horasLaboradas;
ALTER TABLE Producto DROP CONSTRAINT df_descripcionProducto;
DROP TABLE ClienteClase;
DROP TABLE TipoEquipo;
DROP TABLE TratamientoSpa;
DROP TABLE ServiciosClases;
DROP TABLE Producto;
DROP TABLE Clase;
DROP TABLE Maquina;
DROP TABLE NumerosTelefono;
DROP TABLE ServiciosSucursal;
DROP TABLE TratamientoSucursal;
DROP TABLE ProductoSucursal;
DROP TABLE TipoPlanilla;
DROP TABLE Puesto;
DROP TABLE Cliente;
DROP TABLE Sucursal;
DROP TABLE Empleado;
DROP TABLE ClaseFecha;
