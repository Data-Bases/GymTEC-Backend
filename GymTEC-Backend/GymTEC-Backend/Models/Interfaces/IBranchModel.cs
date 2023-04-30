using GymTEC_Backend.Dtos;
using Nest;

namespace GymTEC_Backend.Models.Interfaces
{
    public interface IBranchModel
    {
        BranchDto GetBranchByName(string name);
        Result CreateBranch(BranchDto branch);
        Result CreateBranchWithPhoneNumber(BranchPhoneNumberDto branch);
        List<string> GetBranchesNames();
        IEnumerable<BranchPhoneNumberDto> GetBranchPhoneNumbers(string name);
        Result UpdateScheduleBranch(string name, string schedule);
    }
}