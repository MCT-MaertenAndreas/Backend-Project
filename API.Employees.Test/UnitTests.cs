using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Employees.DataContext;
using API.Employees.Models;
using API.Employees.Repositories;
using API.Employees.Services;
using Xunit;

namespace API.Employees.Test
{
    public class UnitTests
    {
        private MySQLContext _context { get; }

        private DepartmentRepository _departmentRepository { get; }
        private DepartmentService _departmentService { get;}

        private EmployeeRepository _employeeRepository { get; }
        private EmployeeService _employeeService { get; }

        public UnitTests()
        {
            this._context = new MySQLContext(new Config.ConnectionStrings { MySQL = "server=127.0.0.1;database=employees;user=root;password=jEzX4bedSHdeWx" });

            this._departmentRepository = new DepartmentRepository(this._context);
            this._departmentService = new DepartmentService(this._departmentRepository);

            this._employeeRepository = new EmployeeRepository(this._context);
            this._employeeService = new EmployeeService(this._employeeRepository);
        }

        [Fact]
        public async Task CheckEmployeePagination()
        {
            const int pageSize = 50;

            ICollection<Employee> employees = await this._employeeService.GetEmployees(1, pageSize);

            Assert.True(employees.Count <= pageSize);
        }

        [Fact]
        public async Task CheckDepartments()
        {
            ICollection<Department> departments = await this._departmentService.GetDepartments(1, 50);

            Assert.True(departments.Count > 0); // exact value is 9 but is likely to change in the future
        }

        [Fact]
        public async Task CheckEmployeeDepartments()
        {
            ICollection<Department> departments = await this._employeeService.GetEmployeeDepartments(10701);

            Assert.True(departments.Count > 0);
        }
    }
}
