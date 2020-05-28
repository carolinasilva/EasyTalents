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
    public class BestTimeController : ControllerBase
    {

        private readonly ILogger<BestTimeController> _logger;
        private readonly IService<BestTime> _service;

        public BestTimeController(ILogger<BestTimeController> logger, IService<BestTime> service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BestTime>> Get()
        {
            try
            {
                return Ok(_service.ListAll());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when getting the best time to work list. Error: {}", ex.Message);
                return BadRequest();
            }
        }
    }
}
