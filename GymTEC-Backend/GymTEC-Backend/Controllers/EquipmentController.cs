using GymTEC_Backend.Dtos;
using GymTEC_Backend.Models.Interfaces;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Nest;
using System.ComponentModel.DataAnnotations;

namespace GymTEC_Backend.Controllers
{
    [ApiController]
    [Route("gymtec/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IGymTecRepository _gymTecRepository;

        public EquipmentController(IGymTecRepository gymTecRepository)
        {
            _gymTecRepository = gymTecRepository;
        }

        /*
         * Descripton: Get a list of all equipment information except description
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetEquipmentNames", Name = "GetEquipmentNames")]
        public ActionResult<IEnumerable<EquipmentDto>> GetEquipmentNames()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipments = _gymTecRepository.GetEquipmentsName();


            if (equipments.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(equipments);
        }

        /*
         * Descripton: Get description of equipment by name
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("GetEquipmentDescriptionByName/{name}", Name = "GetEquipmentDescriptionByName")]
        public ActionResult<string> GetEquipmentDescriptionByName([Required] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var description = _gymTecRepository.GetEquipmentDescriptionByName(name);


            if (string.IsNullOrEmpty(description))
            {
                return NotFound();
            }

            return Ok(description);
        }

        /*
         * Descripton: Create equipment
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("CreateEquipment", Name = "CreateEquipment")]
        public ActionResult<Result> CreateEquipment(EquipmentNoIdDto equipmentNoIdDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.CreateEquipment(equipmentNoIdDto);

            if (result.Equals(Result.Error))
            {
                return NotFound();
            }

            if (result.Equals(Result.Noop))
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}