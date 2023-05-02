namespace GymTEC_Backend.Dtos
{
    public class ClassNoIdDto
    {
        public string ClassName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; set; }
        public bool IsGrupal { get; set; }
        public int EmployeeId { get; set; }
    }
}
