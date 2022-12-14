using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Models;

namespace BusinessLayer.Model.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeInfo>> GetAllEmployees();
        Task<EmployeeInfo> GetEmployeeByCode(string employeeCode);
        Task<bool> SaveEmployee(Employee employeeCode);
        Task<bool> UpdateEmployee(Employee employeeCode);
        Task<bool> DeleteEmployee(int id);
    }
}
