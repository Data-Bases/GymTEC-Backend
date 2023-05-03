
namespace GymTEC_Backend.Dtos
{
    public class ClassDto
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public bool IsGrupal { get; set; }
        public int EmployeeId { get; set; }
        public int IdServices { get; set; }
        public string BranchName { get; set; }
    }
}