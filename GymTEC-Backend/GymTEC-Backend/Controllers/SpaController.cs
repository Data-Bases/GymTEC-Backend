using GymTEC_Backend.Dtos;
using GymTEC_Backend.Models.Interfaces;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetNamesSpaTreatments", Name = "GetNamesSpaTreatments")]
        public ActionResult<IEnumerable<SpaDto>> GetNamesSpaTreatments()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spaTreatments = _gymTecRepository.GetNamesSpaTreatments();


            if (spaTreatments.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(spaTreatments);
        }
        

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("GetSpaDescriptionByName/{name}", Name = "GetSpaDescriptionByName")]
        public ActionResult<string> GetSpaDescriptionByName([Required] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var description = _gymTecRepository.GetSpaDescriptionByName(name);


            if (string.IsNullOrEmpty(description))
            {
                return NotFound();
            }

            return Ok(description);
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("DeleteSpaTreatment", Name = "DeleteSpaTreatment")]
        public ActionResult<Result> DeleteSpaTreatment([Required]string name) // hace falta validar que se pueda eliminar solo si no esta ligado a ninguna sucursal
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.DeleteSpaTreatment(name);

            if (result.Equals(Result.Noop))
            {
                return BadRequest();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("AddSpaTreatmentToBranch", Name = "AddSpaTreatmentToBranch")]
        public ActionResult<Result> AddSpaTreatmentToBranch([Required] int spaTreatmentId, [Required] string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.AddSpaTreatmentToBranch(spaTreatmentId, branchName);

            if (result.Equals(Result.Noop))
            {
                return BadRequest();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("DeleteSpaTreatmentInBranch", Name = "DeleteSpaTreatmentInBranch")]
        public ActionResult<Result> DeleteSpaTreatmentInBranch([Required] int spaTreatmentId, [Required] string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.DeleteSpaTreatmentInBranch(spaTreatmentId, branchName);

            if (result.Equals(Result.Noop))
            {
                return BadRequest();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("UpdateDescriptionSpaTreatment", Name = "UpdateDescriptionSpaTreatment")]
        public ActionResult<Result> UpdateDescriptionSpaTreatment([Required]string name, [Required]string newDescription)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.UpdateDescriptionSpaTreatment(name, newDescription);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

    }
}