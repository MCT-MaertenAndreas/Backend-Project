using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Employees.Models;
using API.Employees.Services;
using Microsoft.AspNetCore.Authorization;

namespace API.Employees.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/")]
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
        [Route("employee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            return new OkObjectResult(await this._employeeService.GetEmployee(id));
        }

        [HttpGet]
        [Route("employee/{id}/departments")]
        public async Task<ActionResult<ICollection<Department>>> GetEmployeeDepartments(int id)
        {
            return new OkObjectResult(await this._employeeService.GetEmployeeDepartments(id));
        }

        [HttpGet]
        [Route("employee/{id}/salaries")]
        public async Task<ActionResult<ICollection<Salary>>> GetEmployeeSalaries(int id)
        {
            return new OkObjectResult(await this._employeeService.GetEmployeeSalaries(id));
        }

        [HttpGet]
        [Route("employee/{id}/titles")]
        public async Task<ActionResult<ICollection<Title>>> GetEmployeeTitles(int id)
        {
            return new OkObjectResult(await this._employeeService.GetEmployeeTitles(id));
        }


        [HttpGet]
        [Route("employees/{page?}/{limit?}")]
        public async Task<ActionResult<ICollection<Employee>>> GetEmployees(int page = 1, int limit = 50)
        {
            return new OkObjectResult(await this._employeeService.GetEmployees(page, limit));
        }
    }
}
