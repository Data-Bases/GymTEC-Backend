using GymTEC_Backend.Dtos;
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
                command.Connection = new SqlConnection(GymTecSqlDiani);
                command.Connection.Open();
                return command.ExecuteReader();
            }
        }

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
                    clientDto.Weight = Convert.IsDBNull(reader["Peso"]) ? null : (int?)reader["Peso"];
                    clientDto.IMC = Convert.IsDBNull(reader["IMC"]) ? null : (int?)reader["IMC"];
                };


                return clientDto;
            }
            catch (Exception ex)
            {
                return clientDto;
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
    }
}
