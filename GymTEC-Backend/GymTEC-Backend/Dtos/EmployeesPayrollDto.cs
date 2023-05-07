namespace GymTEC_Backend.Dtos
{
    public class EmployeesPayrollDto
    {
        public string BranchName { get; set; }
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public int WorkedHours_GivenClasses { get; set; }
        public int SalaryToPay { get; set; }
    }
}
