using GymTEC_Backend.Dtos;
using GymTEC_Backend.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.ComponentModel.DataAnnotations;

namespace GymTEC_Backend.Controllers
{
    [ApiController]
    [Route("gymtec/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeModel _model;

        public EmployeeController(IEmployeeModel employeeModel)
        {
            _model = employeeModel;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetEmployeeById/{id}", Name = "GetEmployeeById")]
        public ActionResult<EmployeeWithNamesDto> GetEmployeeById([Required] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _model.GetEmployeeById(id);


            if (string.IsNullOrEmpty(employee.Name))
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost("CreateEmployee", Name = "CreateEmployee")]
        public ActionResult<Result> CreateEmployee([Required] EmployeeDto employeeDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _model.CreateEmployee(employeeDto);


            if (result.Equals(Result.Error))
            {
                return NotFound();
            }

            if (result.Equals(Result.Noop))
            {
                return Forbid();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost("DeleteEmployee/{employeeId}", Name = "DeleteEmployee")]
        public ActionResult<Result> DeleteEmployee([Required] int employeeId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _model.DeleteEmployee(employeeId);


            if (result.Equals(Result.Error))
            {
                return NotFound();
            }

            if (result.Equals(Result.Noop))
            {
                return Forbid();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("EmployeeLogIn/{id}", Name = "EmployeeLogIn")]
        public ActionResult<EmployeeWithNamesDto> EmployeeLogIn([Required] int id, [Required] string password)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = _model.EmployeeLogIn(id, password);

            return Ok(employee);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetBranchEmployee/{branchName}", Name = "GetBranchEmployee")]
        public ActionResult<List<EmployeeNameIdDto>> GetBranchEmployee([Required] string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeList = _model.GetBranchEmployee(branchName);

            return Ok(employeeList);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("AssignPayrollToEmployee/{employeeId}/{payrollId}", Name = "AssignPayrollToEmployee")]
        public ActionResult<Result> AssignPayrollToEmployee(int employeeId, int payrollId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _model.AssignPayrollToEmployee(employeeId, payrollId);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("AssignJobToEmployee/{employeeId}/{jobId}", Name = "AssignJobToEmployee")]
        public ActionResult<Result> AssignJobToEmployee(int employeeId, int jobId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _model.AssignJobToEmployee(employeeId, jobId);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("AssignBranchToEmployee/{employeeId}/{branchName}", Name = "AssignBranchToEmployee")]
        public ActionResult<Result> AssignBranchToEmployee(int employeeId, string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _model.AssignBranchToEmployee(employeeId, branchName);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("AssignWorkedHoursToEmployee/{employeeId}/{workedHours}", Name = "AssignWorkedHoursToEmployee")]
        public ActionResult<Result> AssignWorkedHoursToEmployee(int employeeId, int workedHours)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _model.AssignWorkedHoursToEmployee(employeeId, workedHours);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetEmployeesSalaryByBranch/{branchName}", Name = "GetEmployeesSalaryByBranch")]
        public ActionResult<List<EmployeesPayrollDto>> GetEmployeesSalaryByBranch([Required] string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeList = _model.GetEmployeesSalaryByBranch(branchName);

            return Ok(employeeList);
        }
    }
}