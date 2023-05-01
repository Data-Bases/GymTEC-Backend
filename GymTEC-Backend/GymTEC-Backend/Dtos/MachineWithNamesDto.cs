using Microsoft.OData.Edm;
namespace GymTEC_Backend.Dtos
{
    public class MachineWithNamesDto
    {
        public int SerialNumber { get; set; }
        public string Brand { get; set; }
        public int Price{ get; set; }
        public string BranchName { get; set; }
        public string EquipmentName { get; set; }
        public int EquipmentId { get; set; }
    }
}