using GymTEC_Backend.Dtos;
using Nest;

namespace GymTEC_Backend.Repositories.Interfaces
{
    public interface IGymTecRepository
    {
        ClientDto GetClientById(int id);
        Result CreateClient(ClientDto client);
        EmployeeWithNamesDto GetEmployeeById(int id);
        Result CreateEmployee(EmployeeDto employee);
        Result CreateSpaTreatment(SpaNoIdDto spaDto);
        string GetSpaDescriptionByName(string name);
        Result CreateJob(JobNoIdDto spaDto);
        JobDto GetJobByName(string name);
        BranchDto GetBranchByName(string name);
        Result CreateBranch(BranchDto branch);
        List<BranchDto> GetBranches();
        IEnumerable<SpaDto> GetNamesSpaTreatments();
        Result UpdateDescriptionSpaTreatment(string name, string desciption);
        Result DeleteSpaTreatment(string name);
        Result AddSpaTreatmentToBranch(int spaTreatmentId, string branchName);
        Result DeleteSpaTreatmentInBranch(int spaTreatmentId, string branchName);
    }
}
