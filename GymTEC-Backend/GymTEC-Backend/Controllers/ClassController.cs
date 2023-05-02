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
        [HttpGet("GetClassNames", Name = "GetClassNames")]
        public ActionResult<List<string>> GetClassNames()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classServices = _gymTecRepository.GetServicesNamesIds();

            return Ok(classServices);
        }

    }
}
