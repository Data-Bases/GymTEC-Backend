using GymTEC_Backend.Dtos;
using Nest;
using Newtonsoft.Json.Linq;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace GymTEC_Backend.Helpers
{
    public class SqlHelper
    {
        /*
        *  ***** Client Treatments *****
        */

        // Get Client information according to its id
        public static string GetClientById(int id)
        {
            return $@"SELECT Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Email, Contrasena, FechaNacimiento, Peso, IMC FROM Cliente WHERE Cedula = {id}";
        }

        // Create a new tuple in Client Relationship
        public static string CreateClient(ClientDto client, string encodedPassword)
        {
            var birthday = new SqlDateTime(client.Birthday).Value.ToString("MM-dd-yyyy");

            if (string.IsNullOrEmpty(client.LastName2))
            {
                return $@"INSERT INTO Cliente(Cedula, Nombre, Apellido1, Provincia, Canton, Distrito, Email, Contrasena, FechaNacimiento, Peso, IMC) 
                            VALUES ({client.Id},'{client.Name}', '{client.LastName1}', '{client.Province}', '{client.Canton}', '{client.District}', '{client.Email}', '{encodedPassword}', '{birthday}', {client.Weight}, {client.IMC});";
            }
            return $@"INSERT INTO Cliente(Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Email, Contrasena, FechaNacimiento, Peso, IMC) 
                            VALUES ({client.Id},'{client.Name}', '{client.LastName1}', '{client.LastName2}', '{client.Province}', '{client.Canton}', '{client.District}', '{client.Email}', '{encodedPassword}', '{birthday}', {client.Weight}, {client.IMC});";
        }


        /*
        *  ***** Employee *****
        */

        // Get Employee information according to its id
        public static string GetEmployeeById(int id)
        {
            return $@"SELECT Empleado.Cedula, Empleado.Nombre, Empleado.Apellido1, Empleado.Apellido2, Empleado.Provincia, Empleado.Canton, Empleado.Distrito, Empleado.Salario, Empleado.Email, Empleado.Contrasena, Empleado.HorasLaboradas, Empleado.NombreSucursal,TipoPlanilla.Nombre as NombrePlanilla, Puesto.Nombre as Puesto
                        FROM Empleado 
                        LEFT JOIN TipoPlanilla ON Empleado.IdTipoPlanilla = TipoPlanilla.Id
                        LEFT JOIN Puesto ON Empleado.IdPuesto = Puesto.Id
                        WHERE Empleado.Cedula = {id};";
        }

        // Create a new tuple in Employee Relationship
        public static string CreateEmployee(EmployeeDto employee, string encodedPassword)
        {
            string requestHeaders = "INSERT INTO Empleado(Cedula, Nombre, Apellido1, Provincia, Canton, Distrito, Salario, Email, Contrasena";
            string requestValues = $@"VALUES({ employee.Id},'{employee.Name}', '{employee.LastName1}', '{employee.Province}', '{employee.Canton}', '{employee.District}', '{employee.Salary}', '{employee.Email}', '{encodedPassword}'";

            if (!string.IsNullOrEmpty(employee.LastName2))
            {
                requestHeaders = requestHeaders + ", Apellido2";
                requestValues = requestValues + $@", '{employee.LastName2}'";
            }

            if (!string.IsNullOrEmpty(employee.BranchName))
            {
                requestHeaders = requestHeaders + ", NombreSucursal";
                requestValues = requestValues + $@", '{employee.BranchName}'";
            }

            if (!employee.WorkedHours.Equals(null))
            {
                requestHeaders = requestHeaders + ", HorasLaboradas";
                requestValues = requestValues + $@", '{employee.WorkedHours}'";
            }

            if (!employee.JobId.Equals(null))
            {
                requestHeaders = requestHeaders + ", IdPuesto";
                requestValues = requestValues + $@", '{employee.JobId}'";
            }

            if (!employee.PayrollId.Equals(null))
            {
                requestHeaders = requestHeaders + ", IdTipoPlanilla";
                requestValues = requestValues + $@", '{employee.PayrollId}'";
            }

            requestHeaders = requestHeaders + ")";
            requestValues = requestValues + ");";
            return requestHeaders + " " + requestValues;
        }

        public static string DeleteEmployee(int employeeId)
        {
            return $@"DELETE FROM Empleado WHERE Cedula = {employeeId};";
        }

        public static string GetBranchEmployee(string branchName)
        {
            return $@"SELECT Nombre, Cedula 
                        FROM Empleado
                        WHERE NombreSucursal = '{branchName}';";
        }

        /*
        *  ***** Spa Treatments *****
        */


        // Create a new tuple in Spa Relationship
        public static string CreateSpaTreatment(SpaNoIdDto spaDto)
        {
            return $@"INSERT INTO TratamientoSpa(Nombre, Descripcion) 
                            VALUES ('{spaDto.Name}', '{spaDto.Description}');";
        }

        public static string DeleteSpaTreatment(string name)
        {
            return $@"DELETE FROM TratamientoSpa WHERE Nombre = '{name}';";
        }

        public static string IsSpaTreatmentRelatedToBranch()
        {
            return $@"SELECT TratamientoSpa.Nombre as NombreTratamiento
                        FROM TratamientoSpa 
                        Left Join TratamientoSucursal ON TratamientoSpa.Id = TratamientoSucursal.IdTratamientoSpa
                        Where TratamientoSucursal.NombreSucursal is NULL;";
        }

        public static string AddSpaTreatmentToBranch(int spaTreatmentId, string branchName)
        {
            return $@"INSERT INTO TratamientoSucursal(IdTratamientoSpa, NombreSucursal) 
                            VALUES ({spaTreatmentId}, '{branchName}');";
        }

        public static string DeleteSpaTreatmentInBranch(int spaTreatmentId, string branchName)
        {
            return $@"DELETE FROM TratamientoSucursal WHERE NombreSucursal = '{branchName}' AND IdTratamientoSpa = {spaTreatmentId};";
        }

        // Return Spa treatment description according to its name
        public static string GetSpaDescriptionByName(string name)
        {
            return $@"SELECT Descripcion FROM TratamientoSpa WHERE Nombre = '{name}'";
        }

        // Get all names and ids from spa treatment relationship
        public static string GetNamesSpaTreatments()
        {
            return $@"SELECT Id, Nombre FROM TratamientoSpa;";
        }

        // Update description of a certain spa treatment
        public static string UpdateDescriptionSpaTreatment(string name, string description)
        {
            return $@"UPDATE TratamientoSpa
                        SET Descripcion = '{description}'
                        WHERE Nombre = '{name}';";
        }

        /*
        *  ***** Equipment *****
        */

        public static string CreateEquipment(EquipmentNoIdDto equipmentDto)
        {
            return $@"INSERT INTO TipoEquipo(Nombre, Descripcion) 
                            VALUES ('{equipmentDto.Name}', '{equipmentDto.Description}');";
        }

        // Return Spa treatment description according to its name
        public static string GetEquipmentDescriptionByName(string name)
        {
            return $@"SELECT Descripcion FROM TipoEquipo WHERE Nombre = '{name}'";
        }

        // Get all names and ids from spa treatment relationship
        public static string GetEquipmentNames()
        {
            return $@"SELECT Id, Nombre FROM TipoEquipo;";
        }


        /*
        *  ***** Job *****
        */

        // Get a list of the Job Names in the DB
        public static string GetJobsNames()
        {
            return $@"SELECT Nombre FROM Puesto";
        }

        // Add a new tuple in Job relationship
        public static string CreateJob(JobNoIdDto jobDto)
        {
            return $@"INSERT INTO Puesto(Nombre, Descripcion) 
                            VALUES ('{jobDto.Name}', '{jobDto.Description}');";
        }

        //Delete a Job
        public static string DeleteJob(string name)
        {
            return $@"DELETE FROM Puesto WHERE Nombre = '{name}';";
        }

        // Return a tuple in Job relationship according to its name
        public static string GetJobByName(string name)
        {
            return $@"SELECT Id, Nombre, Descripcion FROM Puesto WHERE Nombre = '{name}'";
        }

        // Update description of a job description
        public static string UpdateDescriptionJob(string name, string description)
        {
            return $@"UPDATE Puesto
                        SET Descripcion = '{description}'
                        WHERE Nombre = '{name}';";
        }

        /*
        *  ***** ClassServices *****
        */

        // Get a list of the Class Service Names in the DB
        public static string GetClassServicesNames()
        {
            return $@"SELECT Nombre FROM ServiciosClases";
        }

        // Add a new tuple in Class Service relationship
        public static string CreateClassService(ClassServiceNoIdDto classServiceDto)
        {
            return $@"INSERT INTO ServiciosClases(Nombre, Descripcion) 
                            VALUES ('{classServiceDto.Name}', '{classServiceDto.Description}');";
        }

        //Delete a Class Service
        public static string DeleteClassService(string name)
        {
            return $@"DELETE FROM ServiciosClases WHERE Nombre = '{name}';";
        }

        // Return a tuple in Class Service relationship according to its name
        public static string GetClassServiceByName(string name)
        {
            return $@"SELECT Id, Nombre, Descripcion FROM ServiciosClases WHERE Nombre = '{name}'";
        }

        // Update description of a Class Service description
        public static string UpdateDescriptionClassService(string name, string description)
        {
            return $@"UPDATE ServiciosClases
                        SET Descripcion = '{description}'
                        WHERE Nombre = '{name}';";
        }

        /*
        *  ***** Branch *****
        */

        // Get branch information according to its name
        public static string GetBranchByName(string name)
        {
            return $@"SELECT Nombre, Provincia, Canton, Distrito, Senas, CapacidadMaxima, FechaApertura, TiendaAbierta, SpaAbierto, Horario, IdEmpleadoAdmin FROM Sucursal WHERE Nombre = '{name}'";
        }

        // Creates a new tuple in Branch relationship
        public static string CreateBranch(BranchDto branch)
        {
            var startDate = new SqlDateTime(branch.StartDate).Value.ToString("MM-dd-yyyy");
            return $@"INSERT INTO Sucursal(Nombre, Provincia, Canton, Distrito, Senas, CapacidadMaxima, FechaApertura, SpaAbierto, TiendaAbierta, Horario, IdEmpleadoAdmin) 
                            VALUES ('{branch.Name}','{branch.Province}', '{branch.Canton}', '{branch.District}', '{branch.Directions}', {branch.MaxCapacity}, '{startDate}', {branch.OpenSpa}, {branch.OpenStore}, '{branch.Schedule}', {branch.IdEmployeeAdmin});";
        }

        // Creates a new tuple in Branch and in NumerosTelefono
        public static string CreateBranchWithPhoneNumber(BranchPhoneNumberDto branch)
        {
            var startDate = new SqlDateTime(branch.StartDate).Value.ToString("MM-dd-yyyy");
            return $@"INSERT INTO Sucursal(Nombre, Provincia, Canton, Distrito, Senas, CapacidadMaxima, FechaApertura, SpaAbierto, TiendaAbierta, Horario, IdEmpleadoAdmin) 
                            VALUES ('{branch.Name}','{branch.Province}', '{branch.Canton}', '{branch.District}', '{branch.Directions}', {branch.MaxCapacity}, '{startDate}', {branch.OpenSpa}, {branch.OpenStore}, '{branch.Schedule}', {branch.IdEmployeeAdmin});
                        INSERT INTO NumerosTelefono (NumeroTelefono, NombreSucursal) 
                        VALUES ({branch.PhoneNumber}, '{branch.Name}');";
        }

        // Get all branches form Branch relationship
        public static string GetBranchesNames()
        {
            return $@"SELECT Nombre FROM Sucursal;";
        }

        // Get branch information including its phone numbers
        public static string GetBranchPhoneNumbers(string name)
        {
            return $@"SELECT Nombre, Provincia, Canton, Distrito, Senas, CapacidadMaxima, FechaApertura, SpaAbierto, TiendaAbierta, Horario, IdEmpleadoAdmin, NumeroTelefono
                        FROM (Sucursal AS S JOIN NumerosTelefono AS NT ON S.Nombre = NT.NombreSucursal)
                        WHERE Nombre = '{name}'";
        }

        // Updating a Branch schedule by its name
        public static string UpdateScheduleBranch(string name, string schedule)
        {
            return $@"UPDATE Sucursal
                        SET Horario = '{schedule}'
                        WHERE Nombre = '{name}';";
        }

        /*
        *  ***** Equipment *****
        */

        // Create a machine tuple into the data base
        public static string CreateMachineInvetory(MachineInventoryDto machineInventoryDto)
        {
            return $@"INSERT INTO Maquina(NumeroSerie, Marca, Costo, NombreSucursal, IdEquipo) 
                            VALUES ({machineInventoryDto.SerialNumber}, '{machineInventoryDto.Brand}', {machineInventoryDto.Price}, '{machineInventoryDto.BranchName}', {machineInventoryDto.EquipmentId});";
        }

        // Return Spa treatment description according to its name
        public static string DeleteMachineInvetoryInBranch(int serialNumber, string branchName)
        {
            return $@"DELETE FROM Maquina WHERE NombreSucursal = '{branchName}' AND NumeroSerie = {serialNumber};";
        }

        // Get all names and ids from spa treatment relationship
        public static string GetMachineInventoriesInBranch(string branchName)
        {
            return $@"SELECT  NumeroSerie, Marca, Costo, NombreSucursal, IdEquipo, Nombre as NombreEquipo
                    FROM ( Maquina AS M LEFT JOIN TipoEquipo AS TE ON M.IdEquipo = TE.Id)
                    WHERE NombreSucursal = '{branchName}';";
        }

        public static string GetMachineInventory(string branchName, int equipmentId)
        {
            return $@"SELECT  NumeroSerie, Marca, Costo, NombreSucursal, IdEquipo, Nombre as NombreEquipo
                    FROM ( Maquina AS M LEFT JOIN TipoEquipo AS TE ON M.IdEquipo = TE.Id)
                    WHERE NombreSucursal = '{branchName}' AND IdEquipo = {equipmentId};";
        }

        public static string GetAllMachineInventoryPerEquipment(int equipmentId)
        {
            return $@"SELECT  NumeroSerie, Marca, Costo, NombreSucursal, IdEquipo, Nombre as NombreEquipo
                    FROM ( Maquina AS M LEFT JOIN TipoEquipo AS TE ON M.IdEquipo = TE.Id)
                    WHERE IdEquipo = {equipmentId};";
        }

    }
}
