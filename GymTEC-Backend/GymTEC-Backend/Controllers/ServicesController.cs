﻿using GymTEC_Backend.Dtos;
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
    public class ServicesController : ControllerBase
    {
        private readonly IGymTecRepository _gymTecRepository;

        public ServicesController(IGymTecRepository gymTecRepository)
        {
            _gymTecRepository = gymTecRepository;
        }

        /*
         * Descripton: Gett a list of all services names and ids  
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetServicesNames", Name = "GetServicesNames")]
        public ActionResult<List<ServiceIdNameDto>> GetServicesNamesIds()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classServices = _gymTecRepository.GetServicesNamesIds();

            if (string.IsNullOrEmpty(classServices[0].Name))
            {
                return NotFound();
            }

            return Ok(classServices);
        }

        /*
         * Descripton: Get service information by its name
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("GetServiceByName/{name}", Name = "GetServiceByName")]
        public ActionResult<ServiceDto> GetServiceByName([Required] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classServiceDto = _gymTecRepository.GetClassServiceByName(name);


            if (string.IsNullOrEmpty(classServiceDto.Name))
            {
                return NotFound();
            }

            return Ok(classServiceDto);
        }

        /*
         * Descripton: Get service inforomation by its id
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("GetServiceById/{name}", Name = "GetServiceById")]
        public ActionResult<ServiceDto> GetServiceById([Required] int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classServiceDto = _gymTecRepository.GetServiceById(id);


            if (string.IsNullOrEmpty(classServiceDto.Name))
            {
                return NotFound();
            }

            return Ok(classServiceDto);
        }

        /*
         * Descripton: Get a list of services assign to branch
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetServicesInBranch/{branchName}", Name = "GetServicesInBranch")]
        public ActionResult<List<ServiceIdNameDto>> GetServicesInBranch(string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classServices = _gymTecRepository.GetServicesInBranch(branchName);

            if (classServices.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(classServices);
        }

        /*
         * Descripton: Get a list of services not assign to brancc
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetServicesNotInBranch/{branchName}", Name = "GetServicesNotInBranch")]
        public ActionResult<List<ServiceIdNameDto>> GetServicesNotInBranch(string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var classServices = _gymTecRepository.GetServicesNotInBranch(branchName);

            if (string.IsNullOrEmpty(classServices[0].Name))
            {
                return NotFound();
            }

            return Ok(classServices);
        }

        /*
         * Descripton: assign service to branch
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("AddServiceToBranch/{serviceId}/{branchName}", Name = "AddServiceToBranch")]
        public ActionResult<Result> AddServiceToBranch(int serviceId, string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.AddServiceToBranch(serviceId, branchName);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

        /*
         * Descripton: Create a service for gym to choose
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("CreateService", Name = "CreateService")]
        public ActionResult<Result> CreateService(ServiceNoIdDto classServiceDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.CreateService(classServiceDto);

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
         * Descripton: Delete service not assign to branch
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("DeleteService", Name = "DeleteService")]
        public ActionResult<Result> DeleteService([Required] string name)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.DeleteService(name);

            if (result.Equals(Result.Noop))
            {
                return BadRequest();
            }

            return Ok();
        }

        /*
         * Descripton: Asisgn service description or update it
         */
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("UpdateDescriptionService", Name = "UpdateDescriptionService")]
        public ActionResult<Result> UpdateDescriptionService([Required] string name, [Required] string newDescription)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.UpdateDescriptionService(name, newDescription);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
