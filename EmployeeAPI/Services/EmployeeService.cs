using DataAccess;
using EmployeeAPI.DTO;
using EmployeeAPI.Interfaces.Repository;
using EmployeeAPI.Interfaces.Services;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            return await _unitOfWork.repository<Employee>().GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _unitOfWork.repository<Employee>().GetByIdAsync(id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            employee.CreatedOn = DateTime.Now;
            await _unitOfWork.repository<Employee>().Add(employee);
            await _unitOfWork.Complete();
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeDTO employee)
        {
            var isExist = await _unitOfWork.repository<Employee>().GetByIdAsync(id);

            if (isExist != null)
            {
                isExist.Name = employee.Name;
                isExist.Email = employee.Email;
                isExist.DOB = employee.DOB;
                isExist.DepartmentId = employee.DepartmentId;
                isExist.UpdatedOn = DateTime.Now;
                await _unitOfWork.repository<Employee>().Update(isExist);
                await _unitOfWork.Complete();
            }
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            await _unitOfWork.repository<Employee>().Delete(employee);
            await _unitOfWork.Complete();
        }
    }
}
