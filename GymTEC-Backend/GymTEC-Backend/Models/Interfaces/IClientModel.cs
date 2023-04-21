using GymTEC_Backend.Dtos;
using Nest;

namespace GymTEC_Backend.Models.Interfaces
{
    public interface IClientModel
    {
        ClientDto GetClientById(int id);
        Result CreateClient(ClientDto client);
        ClientDto ClientLogIn(int id, string password);
    }
}
