using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EasyTalents.Domain.DTOs;
using EasyTalents.Domain.Entities;
using EasyTalents.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EasyTalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {

        private readonly ILogger<CandidateController> _logger;
        private readonly ICandidateService _service;
        private readonly IMapper _mapper;

        public CandidateController(ILogger<CandidateController> logger, ICandidateService service, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> Get()
        {
            try
            {
                return Ok(_mapper.Map<List<SimpleCandidateDTO>>(_service.ListAll().ToList()));
            }
            catch (Exception ex)
            {
                string message = "Error when getting the candidate list";
                _logger.LogError("{0}. Error: {1}", message, ex.Message);
                return BadRequest(message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Candidate> Get(Guid id)
        {
            try
            {
                return Ok(_service.GetByIdComplete(id));
            }
            catch (Exception ex)
            {
                string message = "Error when getting the candidate";
                _logger.LogError("{0}. Error: {1}", message, ex.Message);
                return BadRequest(message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] CandidateDTO candidate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var teste = _mapper.Map<List<CandidateBestTimes>>(candidate.BestTimes);

                _service.Add(_mapper.Map<Candidate>(candidate));

                return Ok();
            }
            catch (Exception ex)
            {
                string message = "Error when adding the candidate";
                _logger.LogError("{0}. Error: {1}", message, ex.Message);
                return BadRequest(message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] CandidateDTO candidate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _service.Update(candidate);

                return Ok();
            }
            catch (Exception ex)
            {
                string message = "Error when updating the candidate";
                _logger.LogError("{0}. Error: {1}", message, ex.Message);
                return BadRequest(message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _service.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                string message = "Error when deleting the candidate";
                _logger.LogError("{0}. Error: {1}", message, ex.Message);
                return BadRequest(message);
            }
        }
    }
}
