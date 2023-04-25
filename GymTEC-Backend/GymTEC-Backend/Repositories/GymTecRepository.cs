﻿using GymTEC_Backend.Dtos;
using GymTEC_Backend.FuntionalExtensions;
using GymTEC_Backend.Helpers;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Nest;
using System.Data;
using System.Data.SqlTypes;
using System.Text;
using Tweetinvi.Security;


namespace GymTEC_Backend.Repositories
{
    public class GymTecRepository : IGymTecRepository
    {
        private const int Timeout = 1600;
        private const string GymTecSqlDiani = "Server=LAPTOP-SKUFJ66D\\SQLEXPRESS; Database=GymTEC; Trusted_Connection=True; Encrypt=False;";
        private const string GymTecSqlVale = "Server=ValesskasEnvy\\SQLEXPRESS; Database=GymTEC; Trusted_Connection=True; Encrypt=False;";
        private readonly SqlOptions _sqlOptions;

        public GymTecRepository(IOptions<SqlOptions> options)
        {
            _sqlOptions = options.Value;
        }

        private IDataReader ExecuteQuery(string query)
        {

            using (IDbCommand command = new SqlCommand { CommandText = query, CommandType = CommandType.Text })
            {
                command.CommandTimeout = Timeout;
                command.Connection = new SqlConnection(GymTecSqlVale);
                command.Connection.Open();
                return command.ExecuteReader();
            }
        }

        /*
         **** Client Repository ****
        */
        public ClientDto GetClientById(int id)
        {
            string query = string.Empty;
            ClientDto clientDto = new ClientDto();
            try
            {
                query = SqlHelper.GetClientById(id);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {

                    clientDto.Id = (int)reader["Cedula"];
                    clientDto.Name = reader.GetString(1);
                    clientDto.LastName1 = reader.GetString(2);
                    clientDto.LastName2 = reader.GetString(3);
                    clientDto.Province = reader.GetString(4);
                    clientDto.Canton = reader.GetString(5);
                    clientDto.District = reader.GetString(6);
                    clientDto.Email = reader.GetString(7);
                    clientDto.Password = reader.GetString(8);
                    clientDto.Birthday = (DateTime)reader.GetValue(9);
                    clientDto.Weight = Convert.IsDBNull(reader["Peso"]) ? null : (float)reader["Peso"];
                    clientDto.IMC = Convert.IsDBNull(reader["IMC"]) ? null : (float)reader["IMC"];
                };


                return clientDto;
            }
            catch (Exception ex)
            {
                return new ClientDto();
            }
        }

        public Result CreateClient(ClientDto client)
        {
            string query = string.Empty;
            var password = PassowordHelper.EncodePassword(client.Password);
            try
            {
                query = SqlHelper.CreateClient(client, password);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        /*
        **** Employee Repository ****
        */
        public EmployeeWithNamesDto GetEmployeeById(int id)
        {
            string query = string.Empty;
            EmployeeWithNamesDto employeeDto = new EmployeeWithNamesDto();
            try
            {
                query = SqlHelper.GetEmployeeById(id);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {

                    employeeDto.Id = (int)reader["Cedula"];
                    employeeDto.Name = reader.GetString(1);
                    employeeDto.LastName1 = reader.GetString(2);
                    employeeDto.LastName2 = reader.GetString(3);
                    employeeDto.Province = reader.GetString(4);
                    employeeDto.Canton = reader.GetString(5);
                    employeeDto.District = reader.GetString(6);
                    employeeDto.Salary = (int)reader["Salario"];
                    employeeDto.Email = reader.GetString(8);
                    employeeDto.Password = reader.GetString(9);
                    employeeDto.WorkedHours = (int)reader["HorasLaboradas"];
                    employeeDto.BranchName = (string?)(Convert.IsDBNull(reader["NombreSucursal"]) ? null : reader["NombreSucursal"]);
                    employeeDto.PayrollName = Convert.IsDBNull(reader["NombrePlanilla"]) ? null : reader["NombrePlanilla"].ToString();
                    employeeDto.JobName = Convert.IsDBNull(reader["Puesto"]) ? null : reader["Puesto"].ToString();
                };


                return employeeDto;
            }
            catch (Exception ex)
            {
                return new EmployeeWithNamesDto();
            }
        }

        public Result CreateEmployee(EmployeeDto employee)
        {
            string query = string.Empty;
            var password = PassowordHelper.EncodePassword(employee.Password);
            try
            {
                query = SqlHelper.CreateEmployee(employee, password);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        /*
        **** Spa Repository ****
        */
        public Result CreateSpaTreatment(SpaNoIdDto spaDto)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.CreateSpaTreatment(spaDto);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        } 

        public SpaDto GetSpaTreatmentByName(string name)
        {
            string query = string.Empty;
            SpaDto spaDto = new SpaDto();
            try
            {
                query = SqlHelper.GetSpaTreatmentByName(name);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    spaDto.Id = (int)reader["Id"];
                    spaDto.Name = reader["Nombre"].ToString();
                    spaDto.Description = reader["Descripcion"].ToString();
                };


                return spaDto;
            }
            catch (Exception ex)
            {
                return new SpaDto();
            }
        }

        /*
        **** Job Repository ****
        */
        public Result CreateJob(JobNoIdDto spaDto)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.CreateJob(spaDto);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public JobDto GetJobByName(string name)
        {
            string query = string.Empty;
            JobDto jobDto = new JobDto();
            try
            {
                query = SqlHelper.GetJobByName(name);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    jobDto.Id = (int)reader["Id"];
                    jobDto.Name = reader["Nombre"].ToString();
                    jobDto.Description = reader["Descripcion"].ToString();
                };


                return jobDto;
            }
            catch (Exception ex)
            {
                return new JobDto();
            }
        }

        /*
         **** Branch Repository ****
        */
        public BranchDto GetBranchByName(string name)
        {
            string query;
            BranchDto branchDtoResponse = new BranchDto();
            try
            {
                query = SqlHelper.GetBranchByName(name);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    branchDtoResponse.Name = reader.GetString(reader.GetOrdinal("Nombre"));
                    branchDtoResponse.Province = reader.GetString(reader.GetOrdinal("Provincia"));
                    branchDtoResponse.Canton = reader.GetString(reader.GetOrdinal("Canton"));
                    branchDtoResponse.District = reader.GetString(reader.GetOrdinal("Distrito"));
                    branchDtoResponse.Directions = reader.GetString(reader.GetOrdinal("Senas"));
                    branchDtoResponse.MaxCapacity = reader.GetInt32(reader.GetOrdinal("CapacidadMaxima")).ToString();
                    branchDtoResponse.StartDate = reader.GetDateTime(reader.GetOrdinal("FechaApertura")).ToString();
                    branchDtoResponse.OpenStore = reader.GetBoolean(reader.GetOrdinal("TiendaAbierta")).ToString();
                    branchDtoResponse.OpenSpa = reader.GetBoolean(reader.GetOrdinal("SpaAbierto")).ToString();
                    branchDtoResponse.IdEmployeeAdmin = reader.GetInt32(reader.GetOrdinal("IdEmpleadoAdmin")).ToString();

                };

                return branchDtoResponse;
            }
            catch (Exception ex)
            {
                return new BranchDto();
            }
        }

    }
}
