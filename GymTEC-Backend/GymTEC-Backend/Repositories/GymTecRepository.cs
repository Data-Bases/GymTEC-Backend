﻿using Azure;
using GymTEC_Backend.Dtos;
using GymTEC_Backend.FuntionalExtensions;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Nest;
using System.Data;
using System.Data.SqlTypes;

namespace GymTEC_Backend.Repositories
{
    public class GymTecRepository:IBranchModel
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

            using(IDbCommand command = new SqlCommand { CommandText = query, CommandType = CommandType.Text })
            {
                command.CommandTimeout = Timeout;
                command.Connection = new SqlConnection(GymTecSqlVale);
                command.Connection.Open();
                return command.ExecuteReader();
            }
        }

        public string GetClientName(int id)
        {
            string query = string.Empty;
            string response = string.Empty;
            try
            {
                query = SqlHelper.GetClientById(id);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    response = reader.GetValue(0).ToString();
                }

                return response;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public BranchDto GetBranchByName(string name)
        {
            string query = string.Empty;
            var branchDtoResponse = new BranchDto();
            try
            {
                query = SqlHelper.GetBranchByName(name);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    branchDtoResponse.Name = reader["Nombre"].ToString();
                    branchDtoResponse.Province = reader["Provincia"].ToString();
                    branchDtoResponse.Canton = reader["Canton"].ToString();
                    branchDtoResponse.District = reader["Distrito"].ToString();
                    branchDtoResponse.Directions = reader["Senas"].ToString();
                    branchDtoResponse.MaxCapacity = reader["CapacidadMaxima"].ToString();
                    branchDtoResponse.StartDate = reader["FechaApertura"].ToString();
                    branchDtoResponse.OpenStore = reader["TiendaAbierta"].ToString();
                    branchDtoResponse.OpenSpa = reader["SpaAbierto"].ToString();
                    branchDtoResponse.IdEmployeeAdmin = reader["IdEmpleadoAdmin"].ToString();
            
                }

                return branchDtoResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
