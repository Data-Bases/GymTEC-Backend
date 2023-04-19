using GymTEC_Backend.FuntionalExtensions;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Nest;
using System.Data;
using System.Data.SqlTypes;

namespace GymTEC_Backend.Repositories
{
    public class GymTecRepository:IGymTecRepository
    {
        private const int Timeout = 1600;
        private const string GymTecSql = "Server=LAPTOP-SKUFJ66D\\SQLEXPRESS; Database=GymTEC; Trusted_Connection=True; Encrypt=False;";
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
                command.Connection = new SqlConnection(GymTecSql);
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
    }
}
