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
    public class MachineInventoryController : ControllerBase
    {
        private readonly IGymTecRepository _gymTecRepository;

        public MachineInventoryController(IGymTecRepository gymTecRepository)
        {
            _gymTecRepository = gymTecRepository;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetMachineInventoryInBranch/{branchName}", Name = "GetMachineInventoryInBranch")]
        public ActionResult<IEnumerable<MachineWithNamesDto>> GetMachineInventoriesInBranch(string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var machineInventories = _gymTecRepository.GetMachineInventoriesInBranch(branchName);


            if (machineInventories.IsNullOrEmpty())
            {
                return NotFound();
            }
            
            return Ok(machineInventories);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetMachineInventoriesNotInBranch/{branchName}", Name = "GetMachineInventoriesNotInBranch")]
        public ActionResult<IEnumerable<MachineWithNamesDto>> GetMachineInventoriesNotInBranch(string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machineInventories = _gymTecRepository.GetMachineInventoriesNotInBranch(branchName);


            if (machineInventories.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(machineInventories);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetMachineInventory/{branchName}/{equipmentId}", Name = "GetMachineInventory")]
        public ActionResult<IEnumerable<MachineWithNamesDto>> GetMachineInventory(string branchName, int equipmentId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machineInventories = _gymTecRepository.GetMachineInventory(branchName, equipmentId);


            if (machineInventories.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(machineInventories);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetAllMachineInventoryPerEquipment/{equipmentId}", Name = "GetAllMachineInventoryPerEquipment")]
        public ActionResult<IEnumerable<MachineWithNamesDto>> GetAllMachineInventoryPerEquipment(int equipmentId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var machineInventories = _gymTecRepository.GetAllMachineInventoryPerEquipment(equipmentId);


            if (machineInventories.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(machineInventories);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("CreateMachineInvetory", Name = "CreateMachineInvetory")]
        public ActionResult<Result> CreateMachineInvetory(MachineInventoryDto machineInventoryDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.CreateMachineInventory(machineInventoryDto);

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
        [HttpPost("DeleteMachineInventoryInBranch", Name = "DeleteMachineInventoryInBranch")]
        public ActionResult<Result> DeleteMachineInventoryInBranch([Required] int serialNumber, [Required] string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.DeleteMachineInventoryInBranch(serialNumber, branchName);

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
        [HttpPut("SetMachineInvetoryInBranch", Name = "SetMachineInvetoryInBranch")]
        public ActionResult<Result> SetMachineInvetoryInBranch([Required] int serialNumber, [Required] string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.SetMachineInvetoryInBranch(serialNumber, branchName);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

    }
}