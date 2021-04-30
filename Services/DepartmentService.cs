using System.Collections.Generic;
using System.Threading.Tasks;
using API.IMDB.Models;
using API.IMDB.Repositories;

namespace API.IMDB.Services
{
    public interface IDepartmentService
    {
        Task<Department> GetDepartment(string id);
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

        public async Task<ICollection<Department>> GetDepartments(int page, int limit)
        {
            return await this._departmentRepository.GetDepartments(page, limit);
        }
    }
}
