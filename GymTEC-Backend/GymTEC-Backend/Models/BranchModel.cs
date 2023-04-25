﻿using System;
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
        private readonly IGymTecRepository _gymTecRepository;
        public BranchModel(IGymTecRepository gymTecRepository)
        {
            _gymTecRepository = gymTecRepository;
        }
        public BranchDto GetBranchByName(string name)
        {
            var branch = _gymTecRepository.GetBranchByName(name);

            return branch;
        }
        public Result CreateBranch(BranchDto branch)
        {
            var insertBranch = _gymTecRepository.CreateBranch(branch);

            return insertBranch;
        }

        public IEnumerable<BranchDto> GetBranches()
        {
            var branches = _gymTecRepository.GetBranches();

            return branches;
        }
    }

}

