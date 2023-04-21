using System;
using GymTEC_Backend.Dtos;
using System.ComponentModel.DataAnnotations;
using GymTEC_Backend.Models.Interfaces;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace GymTEC_Backend.Models
{
	public class BranchModel : IBranchModel
	{
        private readonly ILogger<BranchModel> _logger;
        private readonly IGymTecRepository _gymTecRepository;
        public BranchModel(ILogger<BranchModel> logger, IGymTecRepository gymTecRepository)
        {
            _logger = logger;
            _gymTecRepository = gymTecRepository;
        }
        public BranchDto GetBranchByName(string name)
        {
            var branch = _gymTecRepository.GetBranchByName(name);
            if (branch == null)
            {
                return null;
            }
            return (BranchDto)branch;
        }
    }

}

