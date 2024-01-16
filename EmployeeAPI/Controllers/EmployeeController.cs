using DataAccess;
using EmployeeAPI.DTO;
using EmployeeAPI.Helper;
using EmployeeAPI.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ResponseDTO<IEnumerable<Employee>>>> GetAll()
        {
            var employeeList = await _employeeService.GetAllEmployeeAsync();

            return Ok(new ResponseDTO<IEnumerable<Employee>>
            {
                StatusCode = 200,
                Message = "Employee records retrieved.",
                Result = employeeList
            });
        }

        [HttpGet]
        [Route("Details/{id}")]
        public async Task<ActionResult<ResponseDTO<Employee>>> Details(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            return Ok(new ResponseDTO<Employee>
            {
                StatusCode = 200,
                Message = "Employee retrieved.",
                Result = employee
            });
        }


        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<ResponseDTO<bool>>> Create(Employee reqModal)
        {
            await _employeeService.AddEmployeeAsync(reqModal);

            return Ok(new ResponseDTO<bool>
            {
                StatusCode = 200,
                Message = "Employee Added.",
                Result = true
            });
        }

        [HttpPatch]
        [Route("Update/{id}")]
        public async Task<ActionResult<ResponseDTO<bool>>> Edit(int id, EmployeeDTO reqModal)
        {
            await _employeeService.UpdateEmployeeAsync(id, reqModal);

            return Ok(new ResponseDTO<bool>
            {
                StatusCode = 200,
                Message = "Employee Edited.",
                Result = true
            });
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseDTO<bool>>> Delete(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return BadRequest(new ResponseDTO<bool>
                {
                    StatusCode = 400,
                    Message = "Employee Not Found.",
                    Result = false
                });
            }

            await _employeeService.DeleteEmployeeAsync(employee);

            return Ok(new ResponseDTO<bool>
            {
                StatusCode = 200,
                Message = "Employee Deleted.",
                Result = true
            });
        }

    }
}
