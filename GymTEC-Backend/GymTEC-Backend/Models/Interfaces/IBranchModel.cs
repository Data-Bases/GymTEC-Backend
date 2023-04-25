using GymTEC_Backend.Dtos;
using Nest;

namespace GymTEC_Backend.Models.Interfaces
{
    public interface IBranchModel
    {
        BranchDto GetBranchByName(string name);
        Result CreateBranch(BranchDto branch);
        IEnumerable<BranchDto> GetBranches();

    }
}