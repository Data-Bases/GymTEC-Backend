namespace GymTEC_Backend.Dtos
{
    public class GetClassByServiceParamsDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BranchName { get; set; }
        public int ServiceId { get; set; }
    }
}
