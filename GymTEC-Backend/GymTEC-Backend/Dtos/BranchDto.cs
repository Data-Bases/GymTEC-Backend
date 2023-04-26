using Microsoft.OData.Edm;
namespace GymTEC_Backend.Dtos
{
    public class BranchDto
    {
        public string Name { get; set; }
        public string Province { get; set; }
        public string Canton{ get; set; }
        public string District { get; set; }
        public string Directions { get; set; }
        public int MaxCapacity { get; set; }
        public DateTime StartDate { get; set; }
        public int OpenStore { get; set; }
        public int OpenSpa { get; set; }
        public string Schedule { get; set; }
        public int IdEmployeeAdmin { get; set; }
    }
}