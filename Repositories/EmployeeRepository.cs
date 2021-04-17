using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.IMDB.DataContext;
using API.IMDB.Models;
using Microsoft.EntityFrameworkCore;

namespace API.IMDB.Repositories
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetEmployees(int page, int limit);
        Task<Employee> GetEmployee(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMySQLContext _context;

        public EmployeeRepository(IMySQLContext context)
        {
            this._context = context;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await this._context.Employees.Where(e => e.EmployeeId == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Employee>> GetEmployees(int page, int limit)
        {
            int skip = limit * (page - 1);

            return await this._context.Employees.Skip(skip).Take(limit * page - skip).ToListAsync();
        }
    }
}
