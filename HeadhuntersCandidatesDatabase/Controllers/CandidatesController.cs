using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HeadhuntersCandidatesDatabase.Core.Interfaces;
using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("candidates-api")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {    
        private readonly object _locker = new object();
        private readonly ICandidatesDataAccess _candidatesDataAccess;
        private readonly IEnumerable<ICandidateValidator> _validators;

        public CandidatesController(
            ICandidatesDataAccess candidatesDataAccess, IEnumerable<ICandidateValidator> validators)
        {
            _candidatesDataAccess = candidatesDataAccess;
            _validators = validators;
        }

        [HttpPost]
        [Route("createCandidate")]
        public IActionResult CreateCandidate(Candidate candidate)
        {
            if (!_validators.All(v => v.Validate(candidate)))
            {
                return BadRequest();
            }

            lock (_locker)
            {
                _candidatesDataAccess.Create(candidate);

                return Created("", candidate);
            }
        }

        [HttpGet]
        [Route("getallCandidates")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_candidatesDataAccess.GetAllCandidates());
            }
            catch(Exception ex)
            {
                return null;
            }            
        }

        [HttpPut]
        [Route("updateCandidate")]
        public IActionResult UpdateCandidate(Candidate candidate)
        {
            lock (_locker)
            {
                _candidatesDataAccess.Update(candidate);

                return Ok();
            }
        }

        [HttpDelete]
        [Route("deleteCandidate")]
        public IActionResult DeleteCandidate(int id)
        {
            lock (_locker)
            {
                _candidatesDataAccess.DeleteCandidate(id);

                return Ok();
            }
        }
    }
}
