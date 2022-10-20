using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>]
        [HttpGet]
        [Route("api/company/get")]
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            _logger.Info($"Getting All Companies");
            try
            {
                var items = await _companyService.GetAllCompanies();
                return _mapper.Map<IEnumerable<CompanyDto>>(items);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error while getting All Companies,Exception => {ex}");
                throw new Exception("Error While Getting companies details");
            }           
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/company/get/{companyCode}")]
        public async Task<CompanyDto> Get(string companyCode)
        {
            _logger.Info($"Getting details for CompanyCode {companyCode}");
            try
            {
                var item = await _companyService.GetCompanyByCode(companyCode);
                return _mapper.Map<CompanyDto>(item);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error while getting All CompanyDetails,Exception => {ex.Message}");
                throw new Exception("Error While Getting company details");
            }
      
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/company/save")]
        public async Task<string> Post([FromBody] Company company)
        {
            _logger.Info($"Saving Company Details");
            try
            {
                var result = await _companyService.SaveCompany(company);
                if (result)
                    return "Saved Succesfully";
                _logger.Error($"Error While saving Company Details");
                throw new Exception("Error While saving Company Details");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error While saving Company Details,Exception => {ex.Message}");
                throw new Exception("Error While saving Company Details");
            }
            
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/company/update/{id}")]
        public async Task<string> Put(int id, [FromBody] Company company)
        {
            try
            {
                var result = await _companyService.SaveCompany(company);        
                if (result)
                    return "Updated Succesfully";
                _logger.Error($"Error While Updating Company Details");
                throw new Exception("Error While Updating Company Details");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error While Updating Company Details,Exception => {ex.Message}");
                throw new Exception("Error While Updating Company Details");
            }
            
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/company/delete/{id}")]
        public async Task<string> Delete(int id)
        {
            try
            {
                var result = await _companyService.DeleteCompany(id);
                
                if (result)
                    return "Removed Succesfully";
                _logger.Error($"Error While Removing Company Details");
                throw new Exception("Error While Removing Company Details");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error While Removing Company Details,Exception => {ex.Message}");
                throw new Exception("Error While Removing Company Details");
            }
           
        }
    }
}