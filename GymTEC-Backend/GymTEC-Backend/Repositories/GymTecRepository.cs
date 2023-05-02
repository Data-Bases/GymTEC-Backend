using GymTEC_Backend.Dtos;
using GymTEC_Backend.FuntionalExtensions;
using GymTEC_Backend.Helpers;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Nest;
using System.Data;
using System.Data.SqlTypes;
using System.Text;
using Tweetinvi.Security;


namespace GymTEC_Backend.Repositories
{
    public class GymTecRepository : IGymTecRepository
    {
        private const int Timeout = 1600;
        private const string GymTecSqlDiani = "Server=LAPTOP-SKUFJ66D\\SQLEXPRESS; Database=GymTEC; Trusted_Connection=True; Encrypt=False;";
        private const string GymTecSqlVale = "Server=ValesskasEnvy\\SQLEXPRESS; Database=GymTEC; Trusted_Connection=True; Encrypt=False;";
        private readonly SqlOptions _sqlOptions;

        public GymTecRepository(IOptions<SqlOptions> options)
        {
            _sqlOptions = options.Value;
        }

        private IDataReader ExecuteQuery(string query)
        {

            using (IDbCommand command = new SqlCommand { CommandText = query, CommandType = CommandType.Text })
            {
                command.CommandTimeout = Timeout;
                command.Connection = new SqlConnection(GymTecSqlVale);
                command.Connection.Open();
                return command.ExecuteReader();
            }
        }

        /*
         **** Client Repository ****
        */
        public ClientDto GetClientById(int id)
        {
            string query = string.Empty;
            ClientDto clientDto = new ClientDto();
            try
            {
                query = SqlHelper.GetClientById(id);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {

                    clientDto.Id = (int)reader["Cedula"];
                    clientDto.Name = reader.GetString(1);
                    clientDto.LastName1 = reader.GetString(2);
                    clientDto.LastName2 = reader.GetString(3);
                    clientDto.Province = reader.GetString(4);
                    clientDto.Canton = reader.GetString(5);
                    clientDto.District = reader.GetString(6);
                    clientDto.Email = reader.GetString(7);
                    clientDto.Password = reader.GetString(8);
                    clientDto.Birthday = (DateTime)reader.GetValue(9);
                    clientDto.Weight = Convert.IsDBNull(reader["Peso"]) ? null : (float)reader["Peso"];
                    clientDto.IMC = Convert.IsDBNull(reader["IMC"]) ? null : (float)reader["IMC"];
                };


                return clientDto;
            }
            catch (Exception ex)
            {
                return new ClientDto();
            }
        }

        public Result CreateClient(ClientDto client)
        {
            string query = string.Empty;
            var password = PassowordHelper.EncodePassword(client.Password);
            try
            {
                query = SqlHelper.CreateClient(client, password);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        /*
        **** Employee Repository ****
        */
        public EmployeeWithNamesDto GetEmployeeById(int id)
        {
            string query = string.Empty;
            EmployeeWithNamesDto employeeDto = new EmployeeWithNamesDto();
            try
            {
                query = SqlHelper.GetEmployeeById(id);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {

                    employeeDto.Id = (int)reader["Cedula"];
                    employeeDto.Name = reader.GetString(1);
                    employeeDto.LastName1 = reader.GetString(2);
                    employeeDto.LastName2 = reader.GetString(3);
                    employeeDto.Province = reader.GetString(4);
                    employeeDto.Canton = reader.GetString(5);
                    employeeDto.District = reader.GetString(6);
                    employeeDto.Salary = (int)reader["Salario"];
                    employeeDto.Email = reader.GetString(8);
                    employeeDto.Password = reader.GetString(9);
                    employeeDto.WorkedHours = (int)reader["HorasLaboradas"];
                    employeeDto.BranchName = (string?)(Convert.IsDBNull(reader["NombreSucursal"]) ? null : reader["NombreSucursal"]);
                    employeeDto.PayrollName = Convert.IsDBNull(reader["NombrePlanilla"]) ? null : reader["NombrePlanilla"].ToString();
                    employeeDto.JobName = Convert.IsDBNull(reader["Puesto"]) ? null : reader["Puesto"].ToString();
                };


                return employeeDto;
            }
            catch (Exception ex)
            {
                return new EmployeeWithNamesDto();
            }
        }

        public Result CreateEmployee(EmployeeDto employee)
        {
            string query = string.Empty;
            var password = PassowordHelper.EncodePassword(employee.Password);
            try
            {
                query = SqlHelper.CreateEmployee(employee, password);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public Result DeleteEmployee(int employeeId)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.DeleteEmployee(employeeId);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public List<EmployeeNameIdDto> GetBranchEmployee(string branchName)
        {
            string query = string.Empty;
            List<EmployeeNameIdDto> employeeNameIdDtos = new List<EmployeeNameIdDto>();
            try
            {
                query = SqlHelper.GetBranchEmployee(branchName);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    employeeNameIdDtos.Add(new EmployeeNameIdDto
                    {
                        EmployeeId = (int)reader["Cedula"],
                        EmployeeName = reader["Nombre"].ToString(),
                    });

                };


                return employeeNameIdDtos;
            }
            catch (Exception ex)
            {
                return new List<EmployeeNameIdDto>();
            }
        }

        /*
        **** Spa Repository ****
        */
        public Result CreateSpaTreatment(SpaNoIdDto spaDto)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.CreateSpaTreatment(spaDto);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public Result DeleteSpaTreatment(string name)
        {
            string query = string.Empty;
            try
            {
                if (IsSpaTreatmentNotRelatedToBranch(name))
                {
                    query = SqlHelper.DeleteSpaTreatment(name);

                    var reader = ExecuteQuery(query);

                    return Result.Created;
                }

                return Result.NotFound; 
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public Result AddSpaTreatmentToBranch(int spaTreatmentId, string branchName)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.AddSpaTreatmentToBranch(spaTreatmentId, branchName);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public Result DeleteSpaTreatmentInBranch(int spaTreatmentId, string branchName)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.DeleteSpaTreatmentInBranch(spaTreatmentId, branchName);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public string GetSpaDescriptionByName(string name)
        {
            string query = string.Empty;
            var description = string.Empty;
            try
            {
                query = SqlHelper.GetSpaDescriptionByName(name);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    description = reader["Descripcion"].ToString();
                };


                return description;
            }
            catch (Exception ex)
            {
                return description;
            }
        }

        public IEnumerable<SpaDto> GetNamesSpaTreatments()
        {
            string query = string.Empty;
            List<SpaDto> spaDtos = new List<SpaDto>();
            try
            {
                query = SqlHelper.GetNamesSpaTreatments();
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    spaDtos.Add(new SpaDto
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Nombre"].ToString(),
                    });
                };


                return spaDtos;
            }
            catch (Exception ex)
            {
                return new List<SpaDto>();
            }
        }

        public Result UpdateDescriptionSpaTreatment(string name, string description)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.UpdateDescriptionSpaTreatment(name, description);
                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        private bool IsSpaTreatmentNotRelatedToBranch(string name)
        {
            string query = string.Empty;
            List<string> branchList  = new List<string>();  

            try
            {
                query = SqlHelper.IsSpaTreatmentRelatedToBranch();

                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    branchList.Add(reader["NombreTratamiento"].ToString());
                };

                return branchList.Contains(name) ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*
        **** Job Repository ****
        */
        public IEnumerable<JobDto> GetJobsNames()
        {
            string query = string.Empty;
            List<JobDto> jobDtos = new List<JobDto>();
            try
            {
                query = SqlHelper.GetJobsNames();
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    jobDtos.Add(new JobDto
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Nombre"].ToString(),
                    });
                };


                return jobDtos;
            }
            catch (Exception ex)
            {
                return new List<JobDto>();
            }
        }
        public Result CreateJob(JobNoIdDto spaDto)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.CreateJob(spaDto);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }
        public Result DeleteJob(string name)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.DeleteJob(name);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public string GetJobByName(string name)
        {
            string query = string.Empty;
            var description = string.Empty;
            try
            {
                query = SqlHelper.GetJobByName(name);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    description = reader["Descripcion"].ToString();
                };


                return description;
            }
            catch (Exception ex)
            {
                return description;
            }
        }
        public Result UpdateDescriptionJob(string name, string description)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.UpdateDescriptionJob(name, description);
                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        /*
        **** Services Repository ****
        */
        public List<ServiceIdNameDto> GetServicesNamesIds()
        {
            List<ServiceIdNameDto> services = new List<ServiceIdNameDto>();
            string query;
            try
            {
                query = SqlHelper.GetServicesNames();
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    services.Add(new ServiceIdNameDto
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Nombre"].ToString(),
                    });
                };

                return services;
            }
            catch (Exception ex)
            {
                return new List<ServiceIdNameDto>();
            }
        }

        public Result CreateService(ServiceNoIdDto classServiceDto)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.CreateService(classServiceDto);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }
        public Result DeleteService(string name)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.DeleteService(name);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public ServiceDto GetClassServiceByName(string name)
        {
            string query = string.Empty;
            ServiceDto classServiceDto = new ServiceDto();
            try
            {
                query = SqlHelper.GetServiceByName(name);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    classServiceDto.Id = (int)reader["Id"];
                    classServiceDto.Name = reader["Nombre"].ToString();
                    classServiceDto.Description = reader["Descripcion"].ToString();
                };


                return classServiceDto;
            }
            catch (Exception ex)
            {
                return new ServiceDto();
            }
        }
        public Result UpdateDescriptionService(string name, string description)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.UpdateDescriptionService(name, description);
                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public Result AddServiceToBranch(int serviceId, string branchName)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.AddServiceToBranch(serviceId, branchName);
                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public List<ServiceIdNameDto> GetServicesInBranch(string branchName)
        {
            List<ServiceIdNameDto> services = new List<ServiceIdNameDto>();
            string query;
            try
            {
                query = SqlHelper.GetServicesInBranch(branchName);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    services.Add(new ServiceIdNameDto
                    {
                        Id = (int)reader["IdServicio"],
                        Name = reader["Nombre"].ToString(),
                    });
                };

                return services;
            }
            catch (Exception ex)
            {
                return new List<ServiceIdNameDto>();
            }
        }

        public List<ServiceIdNameDto> GetServicesNotInBranch(string branchName)
        {
            List<ServiceIdNameDto> services = new List<ServiceIdNameDto>();
            string query;
            try
            {
                query = SqlHelper.GetServicesNotInBranch(branchName);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    services.Add(new ServiceIdNameDto
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Nombre"].ToString(),
                    });
                };

                return services;
            }
            catch (Exception ex)
            {
                return new List<ServiceIdNameDto>();
            }
        }

        /*
        **** Payroll Repository ****
        */
        public IEnumerable<PayrollDto> GetPayrollNames()
        {
            string query = string.Empty;
            List<PayrollDto> payrollDtos = new List<PayrollDto>();
            try
            {
                query = SqlHelper.GetJobsNames();
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    payrollDtos.Add(new PayrollDto
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Nombre"].ToString(),
                    });
                };


                return payrollDtos;
            }
            catch (Exception ex)
            {
                return new List<PayrollDto>();
            }
        }

        public Result CreatePayroll(PayrollNoIdDto payrollNoIdDto)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.CreatePayroll(payrollNoIdDto);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }
        public Result DeletePayroll(string name)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.DeletePayroll(name);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public string GetPayrollByName(string name)
        {
            string query = string.Empty;
            string description = string.Empty;
            try
            {
                query = SqlHelper.GetPayrollByName(name);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    description = reader["Descripcion"].ToString();
                };


                return description;
            }
            catch (Exception ex)
            {
                return description;
            }
        }
        public Result UpdateDescriptionPayroll(string name, string description)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.UpdateDescriptionPayroll(name, description);
                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        /*
         **** Branch Repository ****
        */
        public BranchDto GetBranchByName(string name)
        {
            string query;
            BranchDto branchDtoResponse = new BranchDto();
            try
            {
                query = SqlHelper.GetBranchByName(name);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    branchDtoResponse.Name = reader.GetString(reader.GetOrdinal("Nombre"));
                    branchDtoResponse.Province = reader.GetString(reader.GetOrdinal("Provincia"));
                    branchDtoResponse.Canton = reader.GetString(reader.GetOrdinal("Canton"));
                    branchDtoResponse.District = reader.GetString(reader.GetOrdinal("Distrito"));
                    branchDtoResponse.Directions = reader.GetString(reader.GetOrdinal("Senas"));
                    branchDtoResponse.MaxCapacity = (int)reader["CapacidadMaxima"];
                    branchDtoResponse.StartDate = (DateTime)reader.GetValue(6);
                    branchDtoResponse.OpenStore = reader["TiendaAbierta"].Equals(1)? true: false;
                    branchDtoResponse.OpenSpa = reader["SpaAbierto"].Equals(1) ? true : false;
                    branchDtoResponse.Schedule = reader.GetString(reader.GetOrdinal("Horario"));
                    branchDtoResponse.IdEmployeeAdmin = (int)reader["IdEmpleadoAdmin"];

                };

                return branchDtoResponse;
            }
            catch (Exception ex)
            {
                return new BranchDto();
            }
        }
        public Result CreateBranch(BranchDto branch)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.CreateBranch(branch);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }
        public Result CreateBranchWithPhoneNumber(BranchPhoneNumberDto branch)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.CreateBranchWithPhoneNumber(branch);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public List<string> GetBranchesNames()
        {
            List<string> names = new List<string>();
            string query;
            try
            {
                query = SqlHelper.GetBranchesNames();
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    string name = reader.GetString(reader.GetOrdinal("Nombre"));

                    names.Add(name);
                };

                return names;
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }
        public List<BranchPhoneNumberDto> GetBranchPhoneNumbers(string name)
        {
            string query;
            List<BranchPhoneNumberDto> branches = new List<BranchPhoneNumberDto>();
            try
            {
                query = SqlHelper.GetBranchPhoneNumbers(name);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    BranchPhoneNumberDto branch = new BranchPhoneNumberDto();
                    branch.Name = reader.GetString(reader.GetOrdinal("Nombre"));
                    branch.Province = reader.GetString(reader.GetOrdinal("Provincia"));
                    branch.Canton = reader.GetString(reader.GetOrdinal("Canton"));
                    branch.District = reader.GetString(reader.GetOrdinal("Distrito"));
                    branch.Directions = reader.GetString(reader.GetOrdinal("Senas"));
                    branch.MaxCapacity = (int)reader["CapacidadMaxima"];
                    branch.StartDate = (DateTime)reader.GetValue(6);
                    branch.OpenStore = (int)reader["TiendaAbierta"];
                    branch.OpenSpa = (int)reader["SpaAbierto"];
                    branch.Schedule = reader.GetString(reader.GetOrdinal("Horario"));
                    branch.IdEmployeeAdmin = (int)reader["IdEmpleadoAdmin"];
                    branch.PhoneNumber = (int)reader["NumeroTelefono"];

                    branches.Add(branch);
                };

                return branches;
            }
            catch (Exception ex)
            {
                return new List<BranchPhoneNumberDto>();
            }
        }
        public Result UpdateScheduleBranch(string name, string schedule)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.UpdateScheduleBranch(name, schedule);
                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }


        /*
        **** Equipment Repository ****
        */

        public Result CreateEquipment(EquipmentNoIdDto equipmentNoIdDto)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.CreateEquipment(equipmentNoIdDto);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public string GetEquipmentDescriptionByName(string name)
        {
            string query = string.Empty;
            var description = string.Empty;
            try
            {
                query = SqlHelper.GetEquipmentDescriptionByName(name);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    description = reader["Descripcion"].ToString();
                };


                return description;
            }
            catch (Exception ex)
            {
                return description;
            }
        }

        public IEnumerable<EquipmentDto> GetEquipmentsName()
        {
            string query = string.Empty;
            List<EquipmentDto> equipmentDtos = new List<EquipmentDto>();
            try
            {
                query = SqlHelper.GetEquipmentNames();
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    equipmentDtos.Add(new EquipmentDto
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Nombre"].ToString(),
                    });
                };


                return equipmentDtos;
            }
            catch (Exception ex)
            {
                return new List<EquipmentDto>();
            }
        }


        /*
        **** MachineInventory Repository ****
        */

        public Result CreateMachineInventory(MachineInventoryDto machineInventoryDto)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.CreateMachineInvetory(machineInventoryDto);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public Result DeleteMachineInventoryInBranch(int serialNumber, string branchName)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.DeleteMachineInvetoryInBranch(serialNumber, branchName);
                    
                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        public IEnumerable<MachineWithNamesDto> GetMachineInventoriesInBranch(string branchName)
        {
            string query = string.Empty;
            List<MachineWithNamesDto> equipmentDtos = new List<MachineWithNamesDto>();
            try
            {
                query = SqlHelper.GetMachineInventoriesInBranch(branchName);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    equipmentDtos.Add(new MachineWithNamesDto
                    {
                        SerialNumber = (int)reader["NumeroSerie"],
                        Brand = reader["Marca"].ToString(),
                        Price = (int)reader["Costo"],
                        BranchName = reader["NombreSucursal"].ToString(),
                        EquipmentId = (int)reader["IdEquipo"],
                        EquipmentName = reader["NombreEquipo"].ToString(),
                    });
                };


                return equipmentDtos;
            }
            catch (Exception ex)
            {
                return new List<MachineWithNamesDto>();
            }
        }
        public IEnumerable<MachineWithNamesDto> GetMachineInventory(string branchName, int equipmentId)
        {
            string query = string.Empty;
            List<MachineWithNamesDto> equipmentDtos = new List<MachineWithNamesDto>();
            try
            {
                query = SqlHelper.GetMachineInventory(branchName, equipmentId);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    equipmentDtos.Add(new MachineWithNamesDto
                    {
                        SerialNumber = (int)reader["NumeroSerie"],
                        Brand = reader["Marca"].ToString(),
                        Price = (int)reader["Costo"],
                        BranchName = branchName,
                        EquipmentId = equipmentId,
                        EquipmentName = reader["NombreEquipo"].ToString(),
                    });
                };


                return equipmentDtos;
            }
            catch (Exception ex)
            {
                return new List<MachineWithNamesDto>();
            }
        }

        public IEnumerable<MachineWithNamesDto> GetAllMachineInventoryPerEquipment(int equipmentId)
        {
            string query = string.Empty;
            List<MachineWithNamesDto> equipmentDtos = new List<MachineWithNamesDto>();
            try
            {
                query = SqlHelper.GetAllMachineInventoryPerEquipment(equipmentId);
                var reader = ExecuteQuery(query);

                while (reader.Read())
                {
                    equipmentDtos.Add(new MachineWithNamesDto
                    {
                        SerialNumber = (int)reader["NumeroSerie"],
                        Brand = reader["Marca"].ToString(),
                        Price = (int)reader["Costo"],
                        BranchName = reader["NombreSucursal"].ToString(),
                        EquipmentId = equipmentId,
                        EquipmentName = reader["NombreEquipo"].ToString(),
                    });
                };


                return equipmentDtos;
            }
            catch (Exception ex)
            {
                return new List<MachineWithNamesDto>();
            }
        }

        /*
        **** Class Repository ****
        public Result CreateClase(ClassNoIdDto classDto)
        {
            string query = string.Empty;
            try
            {
                query = SqlHelper.CreateClase(classDto);

                var reader = ExecuteQuery(query);

                return Result.Created;
            }
            catch (Exception ex)
            {
                return Result.Noop;
            }
        }

        */


    }
}
