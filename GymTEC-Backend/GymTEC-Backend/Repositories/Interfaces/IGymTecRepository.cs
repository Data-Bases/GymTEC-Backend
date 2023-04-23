using GymTEC_Backend.Dtos;
using Nest;

namespace GymTEC_Backend.Repositories.Interfaces
{
    public interface IGymTecRepository
    {
        ClientDto GetClientById(int id);
        Result CreateClient(ClientDto client);
        EmployeeDto GetEmployeeById(int id);
        Result CreateEmployee(EmployeeDto employee);
    }
}
