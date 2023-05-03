namespace GymTEC_Backend.Dtos
{
    public class ClientReservationsDto
    {
        public int IdClass { get; set; }
        public int IdService { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int EmployeeId { get; set; }
        public int Capacity { get; set; }
        public bool IsGrupal { get; set; }

    }
}
