using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.IMDB.Models;
using API.IMDB.Services;

namespace API.IMDB.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            this._logger = logger;
            this._employeeService = employeeService;
        }

        [HttpGet]
        [Route("employees/")]
        public async Task<ActionResult<ICollection<Employee>>> GetEmployees()
        {
            return new OkObjectResult(await this._employeeService.GetEmployees());
        }
    }
}
