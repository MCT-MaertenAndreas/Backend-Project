using System.Collections.Generic;
using System.Threading.Tasks;
using API.IMDB.Models;
using API.IMDB.Repositories;

namespace API.IMDB.Services
{
    public interface IEmployeeService
    {
        Task<ICollection<Employee>> GetEmployees();
    }

    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<ICollection<Employee>> GetEmployees()
        {
            return await this._employeeRepository.GetEmployees();
        }
    }
}