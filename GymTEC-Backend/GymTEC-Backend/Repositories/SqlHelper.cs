using GymTEC_Backend.Dtos;

namespace GymTEC_Backend.Repositories
{
    public class SqlHelper
    {
        public static string GetClientById(int id)
        {   
            return $@"SELECT Nombre FROM Cliente WHERE Cedula = {id}";
        }

        public static string GetBranchByName(string name)
        {
            return $@"SELECT Nombre, Provincia, Canton, Distrito, Senas, CapacidadMaxima, FechaApertura, TiendaAbierta, SpaAbierto, IdEmpleadoAdmin FROM Sucursal WHERE Nombre = '{name}'";
        }
    }
}
