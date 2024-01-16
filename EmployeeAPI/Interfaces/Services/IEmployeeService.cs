using DataAccess;
using EmployeeAPI.DTO;

namespace EmployeeAPI.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(int id, EmployeeDTO employee);
        Task DeleteEmployeeAsync(Employee employee);
    }
}
