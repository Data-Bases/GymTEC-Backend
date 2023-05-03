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

        IEnumerable<JobDto> GetJobsNames();
        Result CreateJob(JobNoIdDto spaDto);
        Result DeleteJob(string name);
        string GetJobByName(string name);
        Result UpdateDescriptionJob(string name, string description);

        List<ServiceIdNameDto> GetServicesNamesIds();
        Result CreateService(ServiceNoIdDto classServiceDto);
        Result DeleteService(string name);
        ServiceDto GetClassServiceByName(string name);
        Result UpdateDescriptionService(string name, string description);
        Result AddServiceToBranch(int serviceId, string branchName);
        List<ServiceIdNameDto> GetServicesInBranch(string branchName);
        List<ServiceIdNameDto> GetServicesNotInBranch(string branchName);
        ServiceDto GetServiceById(int id);


        BranchDto GetBranchByName(string name);
        Result CreateBranch(BranchDto branch);
        Result CreateBranchWithPhoneNumber(BranchPhoneNumberDto branch);
        List<BranchPhoneNumberDto> GetBranchPhoneNumbers(string name);
        List<string> GetBranchesNames();
        Result UpdateScheduleBranch(string name, string schedule);

        IEnumerable<PayrollDto> GetPayrollNames();
        Result CreatePayroll(PayrollNoIdDto payrollNoIdDto);
        Result DeletePayroll(string name);
        string GetPayrollByName(string name);
        Result UpdateDescriptionPayroll(string name, string description);

        IEnumerable<EquipmentDto> GetEquipmentsName();
        Result CreateEquipment(EquipmentNoIdDto equipmentNoIdDto);
        string GetEquipmentDescriptionByName(string name);

        Result CreateMachineInventory(MachineInventoryDto machineInventoryDto);
        Result DeleteMachineInventoryInBranch(int serialNumber, string branchName);
        IEnumerable<MachineWithNamesDto> GetMachineInventoriesInBranch(string branchName);
        public IEnumerable<MachineWithNamesDto> GetMachineInventory(string branchName, int equipmentId);
        IEnumerable<MachineWithNamesDto> GetAllMachineInventoryPerEquipment(int equipmentId);

        IEnumerable<ProductNoDescriptionDto> GetProducts();
        Result CreateProduct(ProductDto productDto);
        Result DeleteProductInBranch(int barcode, string branchName);
        ProductNoBarcodeDto GetProductByBarcode(int barcode);
        Result UpdateDescriptionProduct(int barcode, string description);
        Result UpdateCostProduct(int barcode, int cost);
        Result UpdateNameProduct(int barcode, string name);
        Result AddProductToBranch(int productBarcode, string branchName);
        List<ProductDto> GetProductsInBranch(string branchName);
        List<ProductDto> GetProductsNotInBranch(string branchName);

        Result CreateClass(ClassNoIdDto classDto);
        IEnumerable<ClassDto> GetClasses();
        IEnumerable<ClassDto> GetClassesWithinPeriodInBranch(DateTime startDate, DateTime endDate, string branchName);
        IEnumerable<ClassDto> GetClassesByServicesId(DateTime startDate, DateTime endDate, string branchName, int serviceId);
        Result ClientReserveClass(int clientId, int classId);
        Result ClientDeleteReservation(int clientId, int classId);
        IEnumerable<ClientReservationsDto> GetClientReservations(int clientId);
        IEnumerable<ClientReservationsDto> GetNotReservedClasesByClient(int clientId);
        IEnumerable<ClientReservationsDto> GetClientClasesWithinPeriodByBranch(DateTime startDate, DateTime endDate, string branchName, int clientId);
        IEnumerable<ClientReservationsDto> GetClassesForClientByServiceId(DateTime startDate, DateTime endDate, string branchName, int serviceId, int clientId);

    }
}
