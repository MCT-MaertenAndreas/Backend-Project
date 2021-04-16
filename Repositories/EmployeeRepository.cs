using System.Collections.Generic;
using System.Threading.Tasks;
using API.IMDB.DataContext;
using API.IMDB.Models;
using Microsoft.EntityFrameworkCore;

namespace API.IMDB.Repositories
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetEmployees();
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMySQLContext _context;

        public EmployeeRepository(IMySQLContext context)
        {
            this._context = context;
        }

        public async Task<ICollection<Employee>> GetEmployees()
        {
            return await this._context.Employees.ToListAsync();
        }
    }
}