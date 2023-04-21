using GymTEC_Backend.Dtos;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNológico_Backend.Controllers
{
    [ApiController]
    [Route("gymtec/[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly ILogger<BranchController> _logger;
        private readonly IBranchModel _model;

        public BranchController(ILogger<BranchController> logger, IBranchModel branchModel)
        {
            _logger = logger;
            _model = branchModel;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetBranch/{Name}", Name = "GetBranchByName")]
        public ActionResult<BranchDto> GetBranchByName([Required] string name)
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