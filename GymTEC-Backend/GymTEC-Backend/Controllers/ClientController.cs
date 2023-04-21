using GymTEC_Backend.Dtos;
using GymTEC_Backend.Models.Interfaces;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNológico_Backend.Controllers
{
    [ApiController]
    [Route("gymtec/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientModel _model;

        public ClientController(ILogger<ClientController> logger, IClientModel clientModel)
        {
            _model = clientModel;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetClientById/{id}", Name = "GetClient")]
        public ActionResult<ClientDto> GetClientById([Required] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = _model.GetClientById(id);


            if (string.IsNullOrEmpty(client.Name))
            {
                return NotFound();
            }

            return Ok(client);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost("CreateClient", Name = "CreateClient")]
        public ActionResult<Result> CreateClient([Required] ClientDto client)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _model.CreateClient(client);


            if (result.Equals(Result.Error))
            {
                return NotFound();
            }

            if (result.Equals(Result.Noop))
            {
                return Forbid();
            }

            return Ok();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("ClientLogIn/{id}", Name = "ClientLogIn")]
        public ActionResult<ClientDto> ClientLogIn([Required] int id, [Required] string password)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = _model.ClientLogIn(id, password);

            return Ok(client);
        }


    }
}