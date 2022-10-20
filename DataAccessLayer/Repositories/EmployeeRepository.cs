using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
	    private readonly IDbWrapper<Employee> _employeeDbWrapper;

	    public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper)
	    {   
            _employeeDbWrapper = employeeDbWrapper;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeDbWrapper.FindAllAsync();
        }

        public async Task<Employee> GetByCode(string employeeCode)
        {
            var Result = await _employeeDbWrapper.FindAsync(t => t.EmployeeCode.Equals(employeeCode));
            return Result.FirstOrDefault();
        }

        public async Task<bool> SaveEmployee(Employee employee)
        {
            var item = await _employeeDbWrapper.FindAsync(t =>
                t.SiteId.Equals(employee.SiteId) && t.EmployeeCode.Equals(employee.EmployeeCode));
            var itemRepo = item.FirstOrDefault();
            if (itemRepo !=null)
            {
                itemRepo.EmployeeName = employee.EmployeeName;
                itemRepo.EmployeeStatus = employee.EmployeeStatus;
                itemRepo.Occupation = employee.Occupation;
                itemRepo.EmailAddress = employee.EmailAddress;
                itemRepo.Phone = employee.Phone;
                itemRepo.LastModified = employee.LastModified;
                return await _employeeDbWrapper.UpdateAsync(itemRepo);
            }

            return await _employeeDbWrapper.InsertAsync(employee);
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            return await _employeeDbWrapper.DeleteAsync(t => t.SiteId.Equals(id));
        }

    }
}
