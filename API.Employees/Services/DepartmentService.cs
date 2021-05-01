using System.Collections.Generic;
using System.Threading.Tasks;
using API.Employees.Models;
using API.Employees.Repositories;

namespace API.Employees.Services
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartment(string id);
        Task<ICollection<Employee>> GetDepartmentEmployees(string id);
        Task<ICollection<Employee>> GetDepartmentManagers(string id);
        Task<ICollection<Department>> GetDepartments(int page, int limit);
    }

    public class DepartmentService : IDepartmentService
    {
        private IDepartementRepository _departmentRepository;

        public DepartmentService(IDepartementRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        public async Task<Department> GetDepartment(string id)
        {
            return await _departmentRepository.GetDepartment(id);
        }

        public async Task<ICollection<Employee>> GetDepartmentEmployees(string id)
        {
            return await _departmentRepository.GetDepartmentEmployees(id);
        }

        public async Task<ICollection<Employee>> GetDepartmentManagers(string id)
        {
            return await _departmentRepository.GetDepartmentManagers(id);
        }

        public async Task<ICollection<Department>> GetDepartments(int page, int limit)
        {
            return await this._departmentRepository.GetDepartments(page, limit);
        }
    }
}
