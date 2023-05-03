namespace GymTEC_Backend.Dtos
{
    public class GetClassWithPeriodParamsDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BranchName { get; set; }
    }
}
