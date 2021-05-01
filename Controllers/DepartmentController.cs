using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Employees.Models;
using API.Employees.Services;

namespace API.Employees.Controllers
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
        [Route("department/{id}/employees")]
        public async Task<ActionResult<Department>> GetDepartmentEmployees(string id)
        {
            return new OkObjectResult(await this._employeeService.GetDepartmentEmployees(id));
        }

        [HttpGet]
        [Route("department/{id}/managers")]
        public async Task<ActionResult<Department>> GetDepartmentManagers(string id)
        {
            return new OkObjectResult(await this._employeeService.GetDepartmentManagers(id));
        }


        [HttpGet]
        [Route("departments/{page?}/{limit?}")]
        public async Task<ActionResult<ICollection<Department>>> GetDepartments(int page = 1, int limit = 50)
        {
            return new OkObjectResult(await this._employeeService.GetDepartments(page, limit));
        }
    }
}
