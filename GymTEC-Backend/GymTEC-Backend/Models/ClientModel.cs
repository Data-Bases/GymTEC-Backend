using GymTEC_Backend.Dtos;
using GymTEC_Backend.Helpers;
using GymTEC_Backend.Models.Interfaces;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.Build.Utilities;
using Nest;

namespace GymTEC_Backend.Models
{
    public class ClientModel : IClientModel
    {
        private readonly IGymTecRepository _gymRepository;
        public ClientModel(IGymTecRepository gymRepository)
        {
            _gymRepository = gymRepository;
        }

        public ClientDto GetClientById(int id)
        {
            var client = _gymRepository.GetClientById(id);

            return client;

        }

        public ClientDto ClientLogIn(int id, string password)
        {
            var client = _gymRepository.GetClientById(id);

            if (string.IsNullOrEmpty(password))
            {
                return new ClientDto();
            }

            var expectedEncodedPassword = PassowordHelper.EncodePassword(password);

            if (!expectedEncodedPassword.Equals(client.Password))
            {
                return new ClientDto();
            }

            return client;

        }

        public Result CreateClient(ClientDto client)
        {
            var insertClient = _gymRepository.CreateClient(client);

            return insertClient;
        }
    }
}
