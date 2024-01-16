using DataAccess;
using EmployeeAPI.Helper;
using EmployeeAPI.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ResponseDTO<IEnumerable<Department>>>> GetAll()
        {
            var departmentList = await _departmentService.GetAllDepartmentAsync();

            return Ok(new ResponseDTO<IEnumerable<Department>>
            {
                StatusCode = 200,
                Message = "Department records retrieved.",
                Result = departmentList
            });
        }

    }
}
