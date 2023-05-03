using GymTEC_Backend.Dtos;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.ComponentModel.DataAnnotations;

namespace GymTEC_Backend.Controllers
{
    [ApiController]
    [Route("gymtec/[controller]")]
    public class ClassController : ControllerBase
    {
        private readonly IGymTecRepository _gymTecRepository;

        public ClassController(IGymTecRepository gymTecRepository)
        {
            _gymTecRepository = gymTecRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("CreateClass", Name = "CreateClass")]
        public ActionResult<Result> CreateClass(ClassNoIdDto classDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.CreateClass(classDto);

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
        [HttpGet("GetClasses", Name = "GetClasses")]
        public ActionResult<IEnumerable<ClassDto>> GetClasses()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.GetClasses();

            if (result.Equals(Result.Error))
            {
                return NotFound();
            }

            if (result.Equals(Result.Noop))
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("GetClassesWithinPeriodInBranch", Name = "GetClassesWithinPeriodInBranch")]
        public ActionResult<IEnumerable<ClassDto>> GetClassesWithinPeriodInBranch(DateTime startDate, DateTime endDate, string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.GetClassesWithinPeriodInBranch(startDate, endDate, branchName);

            if (result.Equals(Result.Error))
            {
                return NotFound();
            }

            if (result.Equals(Result.Noop))
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("GetClassesByServiceId", Name = "GetClassesByServiceId")]
        public ActionResult<IEnumerable<ClassDto>> GetClassesByServiceId(DateTime startDate, DateTime endDate, string branchName, int serviceId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.GetClassesByServicesId(startDate, endDate, branchName, serviceId);

            if (result.Equals(Result.Error))
            {
                return NotFound();
            }

            if (result.Equals(Result.Noop))
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
