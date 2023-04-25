using GymTEC_Backend.Dtos;

namespace GymTEC_Backend.Models.Interfaces
{
    public interface IBranchModel
    {
        BranchDto GetBranchByName(string name);

    }
}