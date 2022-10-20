using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using System.Threading.Tasks;
using DataAccessLayer.Model.Models;

namespace BusinessLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteEmployee(int employeeCode)
        {
            return await _employeeRepository.DeleteEmployee(employeeCode);
        }

        public async Task<IEnumerable<EmployeeInfo>> GetAllEmployees()
        {
            var res = await _employeeRepository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeInfo>>(res);
        }

        public async Task<EmployeeInfo> GetEmployeeByCode(string employeeCode)
        {
            var result = await _employeeRepository.GetByCode(employeeCode);
            return _mapper.Map<EmployeeInfo>(result);
        }

        public async Task<bool> SaveEmployee(Employee employeeCode)
        {
            return await _employeeRepository.SaveEmployee(employeeCode);
        }

        public async Task<bool> UpdateEmployee(Employee employeeCode)
        {
            return await _employeeRepository.SaveEmployee(employeeCode);
        }
    }
}
