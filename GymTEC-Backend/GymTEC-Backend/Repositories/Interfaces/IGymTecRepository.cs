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
        Result DeleteEmployee(int employeeId);
        List<EmployeeNameIdDto> GetBranchEmployee(string branchName);

        Result CreateSpaTreatment(SpaNoIdDto spaDto);
        string GetSpaDescriptionByName(string name);
        IEnumerable<SpaDto> GetNamesSpaTreatments();
        Result UpdateDescriptionSpaTreatment(string name, string desciption);
        Result DeleteSpaTreatment(string name);
        Result AddSpaTreatmentToBranch(int spaTreatmentId, string branchName);
        Result DeleteSpaTreatmentInBranch(int spaTreatmentId, string branchName);

        List<string> GetJobsNames();
        Result CreateJob(JobNoIdDto spaDto);
        Result DeleteJob(string name);
        JobDto GetJobByName(string name);
        Result UpdateDescriptionJob(string name, string description);

        List<string> GetClassServicesNames();
        Result CreateClassService(ClassServiceNoIdDto classServiceDto);
        Result DeleteClassService(string name);
        ClassServiceDto GetClassServiceByName(string name);
        Result UpdateDescriptionClassService(string name, string description);

        BranchDto GetBranchByName(string name);
        Result CreateBranch(BranchDto branch);
        Result CreateBranchWithPhoneNumber(BranchPhoneNumberDto branch);
        List<BranchPhoneNumberDto> GetBranchPhoneNumbers(string name);
        List<string> GetBranchesNames();
        Result UpdateScheduleBranch(string name, string schedule);

        List<string> GetPayrollNames();
        Result CreatePayroll(PayrollNoIdDto payrollNoIdDto);
        Result DeletePayroll(string name);
        PayrollDto GetPayrollByName(string name);
        Result UpdateDescriptionPayroll(string name, string description);


    }
}
