using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNológico_Backend.Controllers
{
    [ApiController]
    [Route("gymtec/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IGymTecRepository _model;

        public ClientController(ILogger<ClientController> logger, IGymTecRepository gymTecRepository)
        {
            _logger = logger;
            _model = gymTecRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetClientById/{id}", Name = "GetClient")]
        public ActionResult<string> GetClientNameById([Required] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patient = _model.GetClientName(id);



            if (patient.Equals(string.Empty))
            {
                return NotFound();
            }

            return Ok(patient);
        }



    }
}