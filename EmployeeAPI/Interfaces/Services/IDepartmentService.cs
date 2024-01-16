using DataAccess;

namespace EmployeeAPI.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartmentAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task AddDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(Department department);
    }
}
