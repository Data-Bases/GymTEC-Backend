using Microsoft.OData.Edm;

namespace GymTEC_Backend.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string? LastName2 { get; set; }
        public string Province { get; set;}
        public string Canton { get; set;}
        public string District { get; set; }
        public int Salary { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? WorkedHours { get; set; }
        public string? BranchName { get; set; }
        public int? PayrollId { get; set; }
        public int? JobId { get; set; }
    }
}
