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
    public class JobController : ControllerBase
    {
        private readonly IGymTecRepository _gymTecRepository;

        public JobController(IGymTecRepository gymTecRepository)
        {
            _gymTecRepository = gymTecRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("GetJobByName/{name}", Name = "GetJobByName")]
        public ActionResult<JobDto> GetJobByName([Required] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobDto = _gymTecRepository.GetJobByName(name);


            if (string.IsNullOrEmpty(jobDto.Name))
            {
                return NotFound();
            }

            return Ok(jobDto);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("CreateJob", Name = "CreateJob")]
        public ActionResult<Result> CreateJob(JobNoIdDto jobDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.CreateJob(jobDto);

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