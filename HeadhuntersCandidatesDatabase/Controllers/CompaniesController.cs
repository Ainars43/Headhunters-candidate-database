using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Services;
using System.Linq;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesDataAccess _companiesDataAccess;
        private readonly IEnumerable<ICompanyValidator> _validators;
        private readonly object _locker = new object();

        public CompaniesController(
            ICompaniesDataAccess companiesDataAccess, IEnumerable<ICompanyValidator> validators)
        {
            _companiesDataAccess = companiesDataAccess;
            _validators = validators;
        }

        [HttpPost]
        [Route("createCompany")]
        public IActionResult CreateCompany(Company company)
        {
            if (!_validators.All(v => v.Validate(company)))
            {
                return BadRequest();
            }

            lock (_locker)
            {
                _companiesDataAccess.Create(company);

                return Created("", company);
            }
        }

        [HttpGet]
        [Route("getallCompanies")]
        public IActionResult GetAll()
        {
            return Ok(_companiesDataAccess.GetAllCompanies());
        }

        [HttpPut]
        [Route("updateCompany")]
        public IActionResult UpdateCompany(Company company)
        {
            lock (_locker)
            {
                _companiesDataAccess.Update(company);

                return Ok();
            }
        }

        [HttpDelete]
        [Route("deleteCompany")]
        public IActionResult DeleteCompany(int id)
        {
            lock (_locker)
            {
                _companiesDataAccess.DeleteCompany(id);

                return Ok();
            }
        }
    }
}
