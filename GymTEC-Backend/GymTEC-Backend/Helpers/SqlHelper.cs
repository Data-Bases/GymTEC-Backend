using GymTEC_Backend.Dtos;
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
            return $@"INSERT INTO Cliente(Cedula, Nombre, Apellido1, Apellido2, Provincia, Canton, Distrito, Email, Contrasena, FechaNacimiento, Peso, IMC) VALUES ({client.Id},'{client.Name}', '{client.LastName1}', '{client.LastName2}', '{client.Province}', '{client.Canton}', '{client.District}', '{client.Email}', '{encodedPassword}', '{client.Birthday}', {weight}, {imc});";
        }
    }
}
