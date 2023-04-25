using GymTEC_Backend.Dtos;
using GymTEC_Backend.FuntionalExtensions;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Nest;
using System.Data;
using System.Data.SqlTypes;
using System.Text;


namespace GymTEC_Backend.Repositories
{
    public class GymTecRepository:IGymTecRepository
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
