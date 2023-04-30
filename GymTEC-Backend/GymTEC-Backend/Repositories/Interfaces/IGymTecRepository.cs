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
        List<string> GetJobsNames();
        Result CreateJob(JobNoIdDto spaDto);
        JobDto GetJobByName(string name);
        BranchDto GetBranchByName(string name);
        Result CreateBranch(BranchDto branch);
        Result CreateBranchWithPhoneNumber(BranchPhoneNumberDto branch);
        List<BranchPhoneNumberDto> GetBranchPhoneNumbers(string name);
        List<string> GetBranchesNames();
        Result UpdateScheduleBranch(string name, string schedule);
        IEnumerable<SpaDto> GetNamesSpaTreatments();
        Result UpdateDescriptionSpaTreatment(string name, string desciption);
        Result DeleteSpaTreatment(string name);
        Result AddSpaTreatmentToBranch(int spaTreatmentId, string branchName);
        Result DeleteSpaTreatmentInBranch(int spaTreatmentId, string branchName);
    }
}
