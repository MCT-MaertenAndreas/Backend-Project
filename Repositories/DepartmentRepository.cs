using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Employees.DataContext;
using API.Employees.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Employees.Repositories
{
    public interface IDepartementRepository
    {
        Task<Department> GetDepartment(string id);
        Task<ICollection<Employee>> GetDepartmentEmployees(string id);
        Task<ICollection<Employee>> GetDepartmentManagers(string id);
        Task<ICollection<Department>> GetDepartments(int page, int limit);
    }

    public class DepartmentRepository : IDepartementRepository
    {
        private readonly IMySQLContext _context;

        public DepartmentRepository(IMySQLContext context)
        {
            this._context = context;
        }

        public async Task<Department> GetDepartment(string id)
        {
            return await this._context.Departments
                .Where(d => d.DeptNo == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Employee>> GetDepartmentEmployees(string id)
        {
            return await this._context.Departments
                .Where(d => d.DeptNo == id)
                .SelectMany(d => d.DeptEmps)
                .Select(d => d.EmpNoNavigation)
                .ToListAsync();
        }

        public async Task<ICollection<Employee>> GetDepartmentManagers(string id)
        {
            return await this._context.Departments
                .Where(d => d.DeptNo == id)
                .SelectMany(d => d.DeptManagers)
                .Select(d => d.EmpNoNavigation)
                .ToListAsync();
        }

        public async Task<ICollection<Department>> GetDepartments(int page, int limit)
        {
            int skip = limit * (page - 1);

            return await this._context.Departments
                .Skip(skip).Take(limit * page - skip)
                .ToListAsync();
        }
    }
}
