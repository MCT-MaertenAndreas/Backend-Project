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
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _employeeService;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService employeeService)
        {
            this._logger = logger;
            this._employeeService = employeeService;
        }

        [HttpGet]
        [Route("department/{id}")]
        public async Task<ActionResult<Department>> GetDepartment(string id)
        {
            return new OkObjectResult(await this._employeeService.GetDepartment(id));
        }


        [HttpGet]
        [Route("departments/{page?}/{limit?}")]
        public async Task<ActionResult<ICollection<Department>>> GetDepartments(int page = 1, int limit = 50)
        {
            return new OkObjectResult(await this._employeeService.GetDepartments(page, limit));
        }
    }
}
