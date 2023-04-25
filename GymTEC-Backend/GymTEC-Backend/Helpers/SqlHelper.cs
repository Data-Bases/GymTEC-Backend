﻿using GymTEC_Backend.Dtos;
using Nest;
using System.Diagnostics;

namespace GymTEC_Backend.Helpers
{
    public class SqlHelper
    {
        public static string GetClientById(int id)
        {
            return $@"SELECT Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Email, Contrasena, FechaNacimiento, Peso, IMC FROM Cliente WHERE Cedula = {id}";
        }

        public static string CreateClient(ClientDto client, string encodedPassword)
        {
            var weight = !client.Weight.Equals(null) ? client.Weight : (object)DBNull.Value;
            var imc = !client.Weight.Equals(null) ? client.IMC : (object)DBNull.Value;
            return $@"INSERT INTO Cliente(Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Email, Contrasena, FechaNacimiento, Peso, IMC) 
                            VALUES ({client.Id},'{client.Name}', '{client.LastName1}', '{client.LastName2}', '{client.Province}', '{client.Canton}', '{client.District}', '{client.Email}', '{encodedPassword}', '{client.Birthday}', {weight}, {imc});";
        }

        public static string GetEmployeeById(int id)
        {
            return $@"SELECT Empleado.Cedula, Empleado.Nombre, Empleado.Apellido1, Empleado.Apellido2, Empleado.Provincia, Empleado.Canton, Empleado.Distrito, Empleado.Salario, Empleado.Email, Empleado.Contrasena, Empleado.HorasLaboradas, Empleado.NombreSucursal,TipoPlanilla.Nombre as NombrePlanilla, Puesto.Nombre as Puesto
                        FROM Empleado 
                        LEFT JOIN TipoPlanilla ON Empleado.IdTipoPlanilla = TipoPlanilla.Id
                        LEFT JOIN Puesto ON Empleado.IdPuesto = Puesto.Id
                        WHERE Empleado.Cedula = {id};";
        }

        public static string CreateEmployee(EmployeeDto employee, string encodedPassword)
        {
            return $@"INSERT INTO Empleado(Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Salario, Email, Contrasena, HorasLaboradas, NombreSucursal, IdTipoPlanilla, IdPuesto) 
                            VALUES ({employee.Id},'{employee.Name}', '{employee.LastName1}', '{employee.LastName2}', '{employee.Province}', '{employee.Canton}', '{employee.District}', '{employee.Salary}', '{employee.Email}', '{encodedPassword}', {employee.WorkedHours}, '{employee.BranchName}', {employee.PayrollId}, {employee.JobId});";
        }

        public static string CreateSpaTreatment(SpaNoIdDto spaDto)
        {
            return $@"INSERT INTO TratamientoSpa(Nombre, Descripcion) 
                            VALUES ('{spaDto.Name}', '{spaDto.Description}');";
        }

        public static string GetSpaTreatmentByName(string name)
        {
            return $@"SELECT Id, Nombre, Descripcion FROM TratamientoSpa WHERE Nombre = '{name}'";
        }

        public static string CreateJob(JobNoIdDto jobDto)
        {
            return $@"INSERT INTO Puesto(Nombre, Descripcion) 
                            VALUES ('{jobDto.Name}', '{jobDto.Description}');";
        }

        public static string GetJobByName(string name)
        {
            return $@"SELECT Id, Nombre, Descripcion FROM Puesto WHERE Nombre = '{name}'";
        }
    }
}