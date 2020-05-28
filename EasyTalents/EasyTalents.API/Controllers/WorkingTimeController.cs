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
    public class WorkingTimeController : ControllerBase
    {

        private readonly ILogger<WorkingTimeController> _logger;
        private readonly IService<WorkingTime> _service;

        public WorkingTimeController(ILogger<WorkingTimeController> logger, IService<WorkingTime> service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WorkingTime>> Get()
        {
            try
            {
                return Ok(_service.ListAll());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when getting the working time list. Error: {}", ex.Message);
                return BadRequest();
            }
        }
    }
}
