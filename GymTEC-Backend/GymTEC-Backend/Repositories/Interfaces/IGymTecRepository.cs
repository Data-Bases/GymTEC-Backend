using GymTEC_Backend.Dtos;
namespace GymTEC_Backend.Repositories.Interfaces
{
    public interface IGymTecRepository
    {
        BranchDto GetBranchByName(string name);
        string GetClientName(int id);
    }
}
