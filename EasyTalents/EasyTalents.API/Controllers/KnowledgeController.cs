using System;
using System.Collections.Generic;
using EasyTalents.Domain.Entities;
using EasyTalents.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EasyTalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KnowledgeController : ControllerBase
    {

        private readonly ILogger<KnowledgeController> _logger;
        private readonly IService<Knowledge> _service;

        public KnowledgeController(ILogger<KnowledgeController> logger, IService<Knowledge> service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Knowledge>> Get()
        {
            try
            {
                return Ok(_service.ListAll());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when getting the knowledge list. Error: {}", ex.Message);
                return BadRequest();
            }
        }
    }
}
