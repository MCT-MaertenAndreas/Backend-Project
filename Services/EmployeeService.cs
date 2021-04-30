using System.Collections.Generic;
using System.Threading.Tasks;
using API.Employees.Models;
using API.Employees.Repositories;

namespace API.Employees.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(int id);
        Task<ICollection<Salary>> GetEmployeeSalaries(int id);
        Task<ICollection<Title>> GetEmployeeTitles(int id);
        Task<ICollection<Employee>> GetEmployees(int page, int limit);
    }

    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        public async Task<ICollection<Salary>> GetEmployeeSalaries(int id)
        {
            return await _employeeRepository.GetEmployeeSalaries(id);
        }

        public async Task<ICollection<Title>> GetEmployeeTitles(int id)
        {
            return await _employeeRepository.GetEmployeeTitles(id);
        }

        public async Task<ICollection<Employee>> GetEmployees(int page, int limit)
        {
            return await this._employeeRepository.GetEmployees(page, limit);
        }
    }
}
