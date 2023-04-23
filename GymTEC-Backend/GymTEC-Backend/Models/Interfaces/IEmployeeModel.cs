using GymTEC_Backend.Dtos;
using Nest;

namespace GymTEC_Backend.Models.Interfaces
{
    public interface IEmployeeModel
    {
        EmployeeDto GetEmployeeById(int id);
        EmployeeDto EmployeeLogIn(int id, string password);
        Result CreateEmployee(EmployeeDto client);
    }
}
