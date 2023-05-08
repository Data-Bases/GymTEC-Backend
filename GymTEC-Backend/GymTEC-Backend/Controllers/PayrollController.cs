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
    public class PayrollController : ControllerBase
    {
        private readonly IGymTecRepository _gymTecRepository;

        public PayrollController(IGymTecRepository gymTecRepository)
        {
            _gymTecRepository = gymTecRepository;
        }

        /*
         * Descripton: Get payroll information except its description
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetPayrollNames", Name = "GetPayrollNames")]
        public ActionResult<IEnumerable<PayrollDto>> GetPayrollNames()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payrolls = _gymTecRepository.GetPayrollNames();


            if (payrolls.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(payrolls);
        }

        /*
         * Descripton: Get payroll information by name
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("GetPayrollDescriptionByName/{name}", Name = "GetPayrollDescriptionByName")]
        public ActionResult<string> GetPayrollByName([Required] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var description = _gymTecRepository.GetPayrollByName(name);


            if (string.IsNullOrEmpty(description))
            {
                return NotFound();
            }

            return Ok(description);
        }

        /*
         * Descripton: Create payroll
         */
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

        /*
         * Descripton: Delete payroll with a certain name
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("DeletePayroll", Name = "DeletePayroll")]
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

        /*
         * Descripton: Update description of a certain payroll or assign it
         */
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

