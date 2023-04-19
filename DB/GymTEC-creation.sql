DROP TABLE IF EXISTS Maquina;
CREATE TABLE Maquina
(
	NumeroSerie			INT NOT NULL,
	Marca				VARCHAR(100) NOT NULL,
	Costo				INT NOT NULL,
	NombreSucursal		VARCHAR(100) NOT NULL,
	IdEquipo			INT,

	PRIMARY KEY (NumeroSerie)
);

DROP TABLE IF EXISTS ServiciosSucursal;
CREATE TABLE ServiciosSucursal
(
	Id					INT NOT NULL,
	IdServicioClase		INT NOT NULL,
	NombreSucursal		VARCHAR(100) NOT NULL,

	PRIMARY KEY (Id)
);



DROP TABLE IF EXISTS TratamientoSucursal;
CREATE TABLE TratamientoSucursal
(
	Id					INT NOT NULL,
	IdTratamientoSpa    INT NOT NULL,
	NombreSucursal	    VARCHAR(100) NOT NULL,

	PRIMARY KEY (Id)
);


DROP TABLE IF EXISTS HorariosSucursal;
CREATE TABLE HorariosSucursal
(
	Id					INT NOT NULL,
	IdHorario 			INT NOT NULL,
	NombreSucursal		VARCHAR(100) NOT NULL,

	PRIMARY KEY (Id)
);

DROP TABLE IF EXISTS ProductoSucursal;
CREATE TABLE ProductoSucursal
(
	Id					    INT NOT NULL,
    CodigoBarrasProducto    INT NOT NULL,
    NombreSucursal          VARCHAR(100) NOT NULL,

	PRIMARY KEY (Id)
);

DROP TABLE IF EXISTS NumerosTelefono;
CREATE TABLE NumerosTelefono
(
	Id					INT NOT NULL,
	NumeroTelefono		INT NOT NULL,
	NombreSucursal		VARCHAR(100),

	PRIMARY KEY (Id)
);

DROP TABLE IF EXISTS Clase;
CREATE TABLE Clase
(
	Id					INT NOT NULL,
	HoraInicio			TIME(0) NOT NULL, --'15:30'
	HoraFinalizacion	TIME(0) NOT NULL,
	Fecha				DATE NOT NULL,					
	Capacidad			INT NOT NULL,				
	EsGrupal			BIT NOT NULL, -- 1 true or 0 false
	CedulaEmpleado		INT,

	PRIMARY KEY (Id)
);
 

DROP TABLE IF EXISTS ClienteClase;
CREATE TABLE ClienteClase
(
	Id					INT NOT NULL,
    IdClase             INT NOT NULL,
    CedulaCliente       INT NOT NULL,

	PRIMARY KEY (Id)
);


DROP TABLE IF EXISTS Empleado;
CREATE TABLE Empleado
(
	Cedula              INT NOT NULL,
    Nombre				VARCHAR(100) NOT NULL,
	Apellido1			VARCHAR(100) NOT NULL,
	Apellido2           VARCHAR(100),
	Provincia			VARCHAR(100) NOT NULL,
	Canton				VARCHAR(100) NOT NULL,
	Distrito			VARCHAR(100) NOT NULL,
	Salario				INT NOT NULL,
	Email				VARCHAR(100) NOT NULL,
	Contrasena			VARCHAR(100) NOT NULL,
	HorasLaboradas		INT,
	NombreSucursal		VARCHAR(100),
	IdTipoPlanilla		INT,
	IdPuesto			INT,

	PRIMARY KEY (Cedula)
);

DROP TABLE IF EXISTS Sucursal;
CREATE TABLE Sucursal
(
	Nombre              VARCHAR(100) NOT NULL,
	Provincia			VARCHAR(100) NOT NULL,
	Canton				VARCHAR(100) NOT NULL,
	Distrito			VARCHAR(100) NOT NULL,
    Senas			    VARCHAR(100) NOT NULL,
	CapacidadMaxima     INT NOT NULL,
	FechaApertura		DATE NOT NULL,
	TiendaAbierta	    BIT NOT NULL, -- 1 true, 0 false
	SpaAbierto          BIT NOT NULL, -- 1 true, 0 false
	IdEmpleadoAdmin		INT NOT NULL,

	PRIMARY KEY (Nombre)
);



DROP TABLE IF EXISTS Cliente;
CREATE TABLE Cliente
(
	Cedula              INT NOT NULL,
    Nombre				VARCHAR(100) NOT NULL,
	Apellido1			VARCHAR(100) NOT NULL,
	Apellido2           VARCHAR(100),
	Provincia			VARCHAR(100) NOT NULL,
	Canton				VARCHAR(100) NOT NULL,
	Distrito			VARCHAR(100) NOT NULL,
	Email				VARCHAR(100) NOT NULL,
	Contrasena		VARCHAR(100) NOT NULL,
	FechaNacimiento		DATE NOT NULL,
	Peso	            FLOAT(2),
	IMC	                FLOAT(2),

	PRIMARY KEY (Cedula)
);


DROP TABLE IF EXISTS Producto;
CREATE TABLE Producto
(
	CodigoBarras        INT NOT NULL,
    Nombre				VARCHAR(100) NOT NULL,
	Costo				INT NOT NULL,
	Descripcion			VARCHAR(100),

	PRIMARY KEY (CodigoBarras)
);

DROP TABLE IF EXISTS Horario;
CREATE TABLE Horario
(
	Id					INT NOT NULL,
	Dia				    DATE NOT NULL,					
	HoraApertura		TIME(0) NOT NULL, --'15:30'
	HoraCierra	        TIME(0) NOT NULL,

	PRIMARY KEY (Id)
);

DROP TABLE IF EXISTS Puesto;
CREATE TABLE Puesto
(
	Id					INT NOT NULL,
	Descripcion			VARCHAR(100) NOT NULL UNIQUE,

	PRIMARY KEY (Id)
);

DROP TABLE IF EXISTS TipoPlanilla;
CREATE TABLE TipoPlanilla
(
	Id					INT NOT NULL,
	Descripcion			VARCHAR(100) NOT NULL UNIQUE,

	PRIMARY KEY (Id)
);

DROP TABLE IF EXISTS ServiciosClases;
CREATE TABLE ServiciosClases
(
	Id					INT NOT NULL,
	Descripcion			VARCHAR(100) NOT NULL UNIQUE,

	PRIMARY KEY (Id)
);


DROP TABLE IF EXISTS TratamientoSpa;
CREATE TABLE TratamientoSpa
(
	Id					INT NOT NULL,
	Nombre			    VARCHAR(100) NOT NULL UNIQUE,

	PRIMARY KEY (Id)
);

DROP TABLE IF EXISTS TipoEquipo;
CREATE TABLE TipoEquipo
(
	Id					INT NOT NULL,
	Descripcion			VARCHAR(100) NOT NULL UNIQUE,

	PRIMARY KEY (Id)
);


-- RELACIONES

-- Clase-Empleado
ALTER TABLE Clase
ADD CONSTRAINT EmpleadoEncargadoClase FOREIGN KEY (CedulaEmpleado)
REFERENCES Empleado(Cedula);

-- Empleado - Sucursal
ALTER TABLE Empleado
ADD CONSTRAINT TrabajaEn FOREIGN KEY (NombreSucursal)
REFERENCES Sucursal(Nombre);

-- Empleado - TipoPlanilla
ALTER TABLE Empleado
ADD CONSTRAINT TipoPlanillaEmpleado FOREIGN KEY (IdTipoPlanilla)
REFERENCES TipoPlanilla(Id);

-- Empleado - Puesto
ALTER TABLE Empleado
ADD CONSTRAINT PuestoEmpleado FOREIGN KEY (IdPuesto)
REFERENCES Puesto(Id);

-- NumerosTelefono - Sucursal
ALTER TABLE NumerosTelefono
ADD CONSTRAINT NumeroTelefonoSucursal FOREIGN KEY (NombreSucursal)
REFERENCES Sucursal(Nombre);

-- ServiciosSucursal - ServciosClases
ALTER TABLE ServiciosSucursal
ADD CONSTRAINT TipoClaseImpartida FOREIGN KEY (IdServicioClase)
REFERENCES ServiciosClases(Id);

-- ServiciosSucursal - Sucursal
ALTER TABLE ServiciosSucursal
ADD CONSTRAINT SucursalClaseImpartida FOREIGN KEY (NombreSucursal)
REFERENCES Sucursal(Nombre);

-- Maquina - Sucursal
ALTER TABLE Maquina
ADD CONSTRAINT UbicacionSucursalMaquina FOREIGN KEY (NombreSucursal)
REFERENCES Sucursal(Nombre);

-- Maquina - TipoEquipo
ALTER TABLE Maquina
ADD CONSTRAINT TipoMaquina FOREIGN KEY (IdEquipo)
REFERENCES TipoEquipo(Id);

-- HorariosSucursal - Horario
ALTER TABLE HorariosSucursal
ADD CONSTRAINT TipoHorario FOREIGN KEY (IdHorario)
REFERENCES Horario(Id);

-- HorariosSucursal - Sucursal
ALTER TABLE HorariosSucursal
ADD CONSTRAINT HorarioSucursal FOREIGN KEY (NombreSucursal)
REFERENCES Sucursal(Nombre);

-- ClienteClase - Cliente
ALTER TABLE ClienteClase
ADD CONSTRAINT ClienteRecibeClase FOREIGN KEY (CedulaCliente)
REFERENCES Cliente(Cedula);

-- ClienteClase - Clase
ALTER TABLE ClienteClase
ADD CONSTRAINT TipoDeClase FOREIGN KEY (IdClase)
REFERENCES Clase(Id);

-- Sucursal - Empleado
ALTER TABLE Sucursal
ADD CONSTRAINT EmpleadoAdministraSucursal FOREIGN KEY (IdEmpleadoAdmin)
REFERENCES Empleado(Cedula);

-- TratamientoSucursal - Tratamiento Spa
ALTER TABLE TratamientoSucursal
ADD CONSTRAINT TipoTratamiento FOREIGN KEY (IdTratamientoSpa)
REFERENCES TratamientoSpa(Id);

-- TratamientoSucursal - Sucursal
ALTER TABLE TratamientoSucursal
ADD CONSTRAINT SucursalRealizaTratamiento FOREIGN KEY (NombreSucursal)
REFERENCES Sucursal(Nombre);

-- ProductoSucursal - Producto
ALTER TABLE ProductoSucursal
ADD CONSTRAINT TipoProducto FOREIGN KEY (CodigoBarrasProducto)
REFERENCES Producto(CodigoBarras);

-- ProductoSucursal - Sucursal
ALTER TABLE ProductoSucursal
ADD CONSTRAINT SucursalTieneProducto FOREIGN KEY (NombreSucursal)
REFERENCES Sucursal(Nombre);