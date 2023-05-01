using GymTEC_Backend.Dtos;
using GymTEC_Backend.Helpers;
using GymTEC_Backend.Models.Interfaces;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.Build.Utilities;
using Nest;

namespace GymTEC_Backend.Models
{
    public class EmployeeModel : IEmployeeModel
    {
        private readonly IGymTecRepository _gymRepository;
        public EmployeeModel(IGymTecRepository gymRepository)
        {
            _gymRepository = gymRepository;
        }
        public EmployeeWithNamesDto GetEmployeeById(int id)
        {
            var employee = _gymRepository.GetEmployeeById(id);

            return employee;

        }

        public EmployeeWithNamesDto EmployeeLogIn(int id, string password)
        {
            var employee = _gymRepository.GetEmployeeById(id);

            if (string.IsNullOrEmpty(password))
            {
                return new EmployeeWithNamesDto();
            }

            var expectedEncodedPassword = PassowordHelper.EncodePassword(password);

            if (!expectedEncodedPassword.Equals(employee.Password))
            {
                return new EmployeeWithNamesDto();
            }

            return employee;

        }

        public Result CreateEmployee(EmployeeDto employee)
        {
            var insertClient = _gymRepository.CreateEmployee(employee);

            return insertClient;
        }

        public Result DeleteEmployee(int employeeId)
        {
            var deleteEmployee = _gymRepository.DeleteEmployee(employeeId);

            return deleteEmployee;
        }

        public List<EmployeeNameIdDto> GetBranchEmployee(string branchName)
        {
            var employeeList = _gymRepository.GetBranchEmployee(branchName);
            
            return employeeList;
        }
    }
}
