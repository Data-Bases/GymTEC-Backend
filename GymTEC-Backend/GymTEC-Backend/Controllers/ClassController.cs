using GymTEC_Backend.Dtos;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.ComponentModel.DataAnnotations;
using Tweetinvi.Core.Extensions;

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

        /*
         * Descripton: Create class
         */
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

        /*
         * Descripton: Creates clients reservation to a class
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("ClientReserveClass", Name = "ClientReserveClass")]
        public ActionResult<Result> ClientReserveClass(int clientId, int classId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.ClientReserveClass(clientId, classId);

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
         * Descripton: Copy class in a certain period to another 
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("CopyClassCalendar", Name = "CopyClassCalendar")]
        public ActionResult<Result> CopyClassCalendar(DateTime startDate, DateTime endDate, string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.CopyClassCalendar(startDate, endDate, branchName);

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
         * Descripton: Deletes client reservation
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("ClientDeleteReservation", Name = "ClientDeleteReservation")]
        public ActionResult<Result> ClientDeleteReservation(int clientId, int classId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.ClientDeleteReservation(clientId, classId);

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
         * Descripton: Get all classes created
         */
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

            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(result);
        }

        /*
         * Descripton: Get classes with a period of time
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetClassesWithinPeriodInBranch", Name = "GetClassesWithinPeriodInBranch")]
        public ActionResult<IEnumerable<ClassDto>> GetClassesWithinPeriodInBranch(DateTime startDate, DateTime endDate, string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.GetClassesWithinPeriodInBranch(startDate, endDate, branchName);

            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(result);
        }

        /*
         * Descripton: Get classes according to its service id
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetClassesByServiceId", Name = "GetClassesByServiceId")]
        public ActionResult<IEnumerable<ClassDto>> GetClassesByServiceId(DateTime startDate, DateTime endDate, string branchName, int serviceId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.GetClassesByServicesId(startDate, endDate, branchName, serviceId);

            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(result);
        }

        /*
         * Descripton: Get reservations of a certain client
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetClientReservations/{clientId}", Name = "GetClientReservations")]
        public ActionResult<IEnumerable<ClientReservationsDto>> GetClientReservations(int clientId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.GetClientReservations(clientId);

            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(result);
        }

        /*
         * Descripton: Get classes that certain client is not registered
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetNotReservedClasesByClient/{clientId}", Name = "GetNotReservedClasesByClient")]
        public ActionResult<IEnumerable<ClientReservationsDto>> GetNotReservedClasesByClient(int clientId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.GetNotReservedClasesByClient(clientId);

            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(result);
        }

        /*
         * Descripton: Get classes with a period of time of a certain branch
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetClientClasesWithinPeriodByBranch", Name = "GetClientClasesWithinPeriodByBranch")]
        public ActionResult<IEnumerable<ClientReservationsDto>> GetClientClasesWithinPeriodByBranch(DateTime startDate, DateTime endDate, string branchName, int clientId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.GetClientClasesWithinPeriodByBranch(startDate, endDate, branchName, clientId);

            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(result);
        }

        /*
         * Descripton: Get client's classes within a certain period of time and a service id in a certain branch
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetClassesForClientByServiceId", Name = "GetClassesForClientByServiceId")]
        public ActionResult<IEnumerable<ClientReservationsDto>> GetClassesForClientByServiceId(DateTime startDate, DateTime endDate, string branchName, int serviceId, int clientId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.GetClassesForClientByServiceId(startDate, endDate, branchName, serviceId, clientId);

            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
} 
