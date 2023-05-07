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

        public Result AssignPayrollToEmployee(int employeeId, int payrollId)
        {
            var employee = _gymRepository.AssignPayrollToEmployee(employeeId, payrollId);

            return employee;
        }
        public Result AssignWorkedHoursToEmployee(int employeeId, int workedHours)
        {
            var employee = _gymRepository.AssignWorkedHoursToEmployee(employeeId, workedHours);

            return employee;
        }

        public Result AssignJobToEmployee(int employeeId, int jobId)
        {
            var employee = _gymRepository.AssignJobToEmployee(employeeId, jobId);

            return employee;
        }

        public Result AssignBranchToEmployee(int employeeId, string branchName)
        {
            var employee = _gymRepository.AssignBranchToEmployee(employeeId, branchName);

            return employee;
        }


        public List<EmployeeNameIdDto> GetBranchEmployee(string branchName)
        {
            var employeeList = _gymRepository.GetBranchEmployee(branchName);
            
            return employeeList;
        }

        public List<EmployeesPayrollDto> GetEmployeesSalaryByBranch(string branchName)
        {
            var employeeList = _gymRepository.GetEmployeesSalaryByBranch(branchName);

            List<EmployeesPayrollDto> employeesPayrollDtos = new List<EmployeesPayrollDto>();

            foreach (var employee in employeeList)
            {   
                EmployeesPayrollDto employeePayroll = new EmployeesPayrollDto();

                employeePayroll.BranchName = employee.BranchName;
                employeePayroll.EmployeeId = employee.Id;
                employeePayroll.FullName = employee.Name + " " + employee.LastName1 + " " + employee.LastName2;
                employeePayroll.WorkedHours_GivenClasses = (int)employee.WorkedHours;

                switch(employee.PayrollName)
                {
                    case "Mensual":
                        employeePayroll.SalaryToPay = (int)(employee.Salary);
                        break;
                    case "Pago por clase":
                        employeePayroll.SalaryToPay = (int)(employee.Salary * employee.WorkedHours);
                        break;
                    case "Pago por horas":
                        employeePayroll.SalaryToPay = (int)(employee.Salary * employee.WorkedHours);
                        break;
                    default:
                        employeePayroll.SalaryToPay = (int)(employee.Salary);
                        break;
                }

                employeesPayrollDtos.Add(employeePayroll);
            }

            return employeesPayrollDtos;
        }
    }
}
