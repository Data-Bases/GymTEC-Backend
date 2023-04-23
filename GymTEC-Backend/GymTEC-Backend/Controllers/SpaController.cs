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
    public class SpaController : ControllerBase
    {
        private readonly IGymTecRepository _gymTecRepository;

        public SpaController(IGymTecRepository gymTecRepository)
        {
            _gymTecRepository = gymTecRepository;
        }

        /*
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAllSpaTreatments", Name = "GetAllSpaTreatments")]
        public ActionResult<IEnumerable<SpaDto>> GetAllSpaTreatments()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spaTreatment = _gymTecRepository.GetAllSpaTreatments();


            if (string.IsNullOrEmpty(spaTreatment.Name))
            {
                return NotFound();
            }

            return Ok(spaTreatment);
        }
        */

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("GetSpaTreatmentByName/{name}", Name = "GetSpaTreatmentByName")]
        public ActionResult<SpaDto> GetSpaTreatmentByName([Required] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spaTreatment = _gymTecRepository.GetSpaTreatmentByName(name);


            if (string.IsNullOrEmpty(spaTreatment.Name))
            {
                return NotFound();
            }

            return Ok(spaTreatment);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("CreateSpaTreatment", Name = "CreateSpaTreatment")]
        public ActionResult<Result> CreateSpaTreatment(SpaNoIdDto spaDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.CreateSpaTreatment(spaDto);

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