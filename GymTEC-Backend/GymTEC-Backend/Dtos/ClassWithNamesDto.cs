namespace GymTEC_Backend.Dtos
{
    public class ClassWithNamesDto
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public bool IsGrupal { get; set; }
        public int EmployeeId { get; set; }
        public int IdServices { get; set; }
        public string ServiceName { get; set; }
        public string BranchName { get; set; }

    }
}
