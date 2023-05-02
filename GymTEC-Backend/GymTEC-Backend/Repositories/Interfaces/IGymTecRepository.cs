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
        Result AssignBranchToEmployee(int employeeId, string branchName);
        Result AssignJobToEmployee(int employeeId, int jobId);
        Result AssignWorkedHoursToEmployee(int employeeId, int workedHours);
        Result AssignPayrollToEmployee(int employeeId, int payrollId);

        Result CreateSpaTreatment(SpaNoIdDto spaDto);
        string GetSpaDescriptionByName(string name);
        IEnumerable<SpaDto> GetNamesSpaTreatments();
        Result UpdateDescriptionSpaTreatment(string name, string desciption);
        Result DeleteSpaTreatment(string name);
        Result AddSpaTreatmentToBranch(int spaTreatmentId, string branchName);
        Result DeleteSpaTreatmentInBranch(int spaTreatmentId, string branchName);
        List<SpaDto> GetSpaTreatmentsInBranch(string branchName);
        List<SpaDto> GetSpaTreatmentsNotInBranch(string branchName);

        List<string> GetJobsNames();
        Result CreateJob(JobNoIdDto spaDto);
        Result DeleteJob(string name);
        JobDto GetJobByName(string name);
        Result UpdateDescriptionJob(string name, string description);

        List<ServiceIdNameDto> GetServicesNamesIds();
        Result CreateService(ServiceNoIdDto classServiceDto);
        Result DeleteService(string name);
        ServiceDto GetClassServiceByName(string name);
        Result UpdateDescriptionService(string name, string description);
        Result AddServiceToBranch(int serviceId, string branchName);
        List<ServiceIdNameDto> GetServicesInBranch(string branchName);
        List<ServiceIdNameDto> GetServicesNotInBranch(string branchName);


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

        IEnumerable<EquipmentDto> GetEquipmentsName();
        Result CreateEquipment(EquipmentNoIdDto equipmentNoIdDto);
        string GetEquipmentDescriptionByName(string name);

        Result CreateMachineInventory(MachineInventoryDto machineInventoryDto);
        Result DeleteMachineInventoryInBranch(int serialNumber, string branchName);
        IEnumerable<MachineWithNamesDto> GetMachineInventoriesInBranch(string branchName);
        public IEnumerable<MachineWithNamesDto> GetMachineInventory(string branchName, int equipmentId);
        IEnumerable<MachineWithNamesDto> GetAllMachineInventoryPerEquipment(int equipmentId);
    }
}
