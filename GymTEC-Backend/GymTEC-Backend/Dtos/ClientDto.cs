using Microsoft.OData.Edm;

namespace GymTEC_Backend.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string? LastName2 { get; set; }
        public string Province { get; set;}
        public string Canton { get; set;}
        public string District { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public float? Weight { get; set; }
        public float? IMC { get; set; }
        public DateTime Birthday { get; set; }
    }
}
