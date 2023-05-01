using GymTEC_Backend.Dtos;
using GymTEC_Backend.Models.Interfaces;
using GymTEC_Backend.Repositories.Interfaces;
using Hospital_TECNológico_Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.ComponentModel.DataAnnotations;

namespace GymTEC_Backend.Controllers
{
    [ApiController]
    [Route("gymtec/[controller]")]
    public class PayrollController : ControllerBase
    {
        private readonly IGymTecRepository _gymTecRepository;

        public PayrollController(IGymTecRepository gymTecRepository)
        {
            _gymTecRepository = gymTecRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetPayrollNames", Name = "GetPayrollNames")]
        public ActionResult<List<string>> GetPayrollNames()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payrolls = _gymTecRepository.GetPayrollNames();

            return Ok(payrolls);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("GetPayrollByName/{name}", Name = "GetPayrollByName")]
        public ActionResult<PayrollDto> GetPayrollByName([Required] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payrollDto = _gymTecRepository.GetPayrollByName(name);


            if (string.IsNullOrEmpty(payrollDto.Name))
            {
                return NotFound();
            }

            return Ok(payrollDto);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("DeletePayroll", Name = "DeletePayroll")]
        public ActionResult<Result> DeletePayroll([Required] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.DeletePayroll(name);

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
        [HttpPost("CreatePayroll", Name = "CreatePayroll")]
        public ActionResult<Result> CreatePayroll(PayrollNoIdDto payrollNoIdDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.CreatePayroll(payrollNoIdDto);

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
        [HttpPut("UpdateDescriptionPayroll", Name = "UpdateDescriptionPayroll")]
        public ActionResult<Result> UpdateDescriptionPayroll([Required] string name, [Required] string newDescription)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.UpdateDescriptionPayroll(name, newDescription);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

    }
}

