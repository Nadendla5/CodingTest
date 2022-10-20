using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        // GET api/<controller>
        [HttpGet]
        [Route("api/employee/get")]
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            _logger.Info($"Getting All Employees");
            try
            {
                var items = await _employeeService.GetAllEmployees();
                return _mapper.Map<IEnumerable<EmployeeDto>>(items);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error while getting All Employees,Exception => {ex}");
                throw new Exception("Error While Getting Employees");
            }
            
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/employee/get/{employeeCode}")]
        public async Task<EmployeeDto> Get(string employeeCode)
        {
            _logger.Info($"Getting details for EmployeeCode {employeeCode}");
            try
            {
                var item = await _employeeService.GetEmployeeByCode(employeeCode);
                return _mapper.Map<EmployeeDto>(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error while getting All CompanyDetails,Exception => {ex.Message}");
                throw new Exception("Error While Getting company details");
            }
           
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/employee/save")]
        public async Task<string> Post([FromBody]Employee employee)
        {
            _logger.Info($"Saving Company Details");
            try
            {
                var result = await _employeeService.SaveEmployee(employee);
                if (result)
                    return "Saved Succesfully";
                _logger.Error($"Error While saving Employee Details");
                throw new Exception("Error While saving Employee Details");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error While saving Employee Details,Exception => {ex.Message}");
                throw new Exception("Error While saving Employee Details");
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/employee/update/{id}")]
        public async Task<string> Put(int id, [FromBody] Employee employee)
        {
            try
            {
                var result = await _employeeService.SaveEmployee(employee);
                if (result)
                    return "Updated Succesfully";
                _logger.Error($"Error While Updating Employee Details");
                throw new Exception("Error While Updating Employee Details");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error While Updating Employee Details,Exception => {ex.Message}");
                throw new Exception("Error While Updating Employee Details");
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/employee/delete/{id}")]
        public async Task<string> Delete(int id)
        {
            try
            {
                var result = await _employeeService.DeleteEmployee(id);

                if (result)
                    return "Removed Succesfully";
                _logger.Error($"Error While Removing Employee Details");
                throw new Exception("Error While Removing Employee Details");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error While Removing Employee Details,Exception => {ex.Message}");
                throw new Exception("Error While Removing Employee Details");
            }
        }
    }
}