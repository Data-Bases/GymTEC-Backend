using GymTEC_Backend.Dtos;
using GymTEC_Backend.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.ComponentModel.DataAnnotations;

namespace GymTEC_Backend.Controllers
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
        [HttpGet("GetBranch/{name}", Name = "GetBranchByName")]
        public ActionResult<BranchDto> GetBranchByName([Required] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var branchDto = _model.GetBranchByName(name);

            if (string.IsNullOrEmpty(branchDto.Name))
            {
                return NotFound();
            }

            return Ok(branchDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetBranchesNames", Name = "GetBranchesNames")]
        public ActionResult<List<string>> GetBranchesNames()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var branches = _model.GetBranchesNames();

            return Ok(branches);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetBranchPhoneNumbers/{name}", Name = "GetBranchPhoneNumbers")]
        public ActionResult<IEnumerable<BranchPhoneNumberDto>> GetBranchPhoneNumbers([Required] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var branches = _model.GetBranchPhoneNumbers(name);

            return Ok(branches);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost("CreateBranch", Name = "CreateBranch")]
        public ActionResult<Result> CreateBranch([Required] BranchDto branch)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _model.CreateBranch(branch);


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
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost("CreateBranchWithPhoneNumber", Name = "CreateBranchWithPhoneNumber")]
        public ActionResult<Result> CreateBranchWithPhoneNumber([Required] BranchPhoneNumberDto branch)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _model.CreateBranchWithPhoneNumber(branch);


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
        [HttpPut("UpdateScheduleBranch", Name = "UpdateScheduleBranch")]
        public ActionResult<Result> UpdateScheduleBranch([Required] string name, [Required] string newSchedule)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _model.UpdateScheduleBranch(name, newSchedule);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

    }

}
