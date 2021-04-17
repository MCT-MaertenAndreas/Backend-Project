using System.Collections.Generic;
using System.Threading.Tasks;
using API.IMDB.Models;
using API.IMDB.Repositories;

namespace API.IMDB.Services
{
    public interface IEmployeeService
    {
        Task<ICollection<Employee>> GetEmployees(int page, int limit);
        Task<Employee> GetEmployee(int id);
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

        public async Task<ICollection<Employee>> GetEmployees(int page, int limit)
        {
            return await this._employeeRepository.GetEmployees(page, limit);
        }
    }
}
