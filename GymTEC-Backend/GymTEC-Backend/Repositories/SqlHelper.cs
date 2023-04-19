namespace GymTEC_Backend.Repositories
{
    public class SqlHelper
    {
        public static string GetClientById(int id)
        {
            return $@"SELECT Nombre FROM Cliente WHERE Cedula = {id}";
        }
    }
}
