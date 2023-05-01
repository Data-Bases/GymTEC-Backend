using GymTEC_Backend.Dtos;
using Nest;

namespace GymTEC_Backend.Models.Interfaces
{
    public interface IEmployeeModel
    {
        EmployeeWithNamesDto GetEmployeeById(int id);
        EmployeeWithNamesDto EmployeeLogIn(int id, string password);
        Result CreateEmployee(EmployeeDto client);
        Result DeleteEmployee(int employeeId);
        List<EmployeeNameIdDto> GetBranchEmployee(string branchName);
    }
}
