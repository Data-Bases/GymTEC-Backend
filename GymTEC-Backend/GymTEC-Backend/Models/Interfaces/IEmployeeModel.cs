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
        Result AssignBranchToEmployee(int employeeId, string branchName);
        Result AssignJobToEmployee(int employeeId, int jobId);
        Result AssignWorkedHoursToEmployee(int employeeId, int workedHours);
        Result AssignPayrollToEmployee(int employeeId, int payrollId);
        List<EmployeesPayrollDto> GetEmployeesSalaryByBranch(string branchName);
    }
}
