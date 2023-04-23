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
        SpaDto GetSpaTreatmentByName(string name);
        Result CreateJob(JobNoIdDto spaDto);
        JobDto GetJobByName(string name);
    }
}
