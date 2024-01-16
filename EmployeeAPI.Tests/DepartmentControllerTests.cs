using EmployeeAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using EmployeeAPI.Helper;
using EmployeeAPI.Data;
using EmployeeAPI.Repository;
using DepartmentAPI.Services;

namespace EmployeeAPI.Tests
{
    [TestFixture]
    public class DepartmentControllerTests
    {
        private DataContext _context;

        [SetUp]
        public void Setup()
        {
            // Initialize the in-memory database
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeDb")
                .Options;

            _context = new DataContext(options);

            //_context.Employee.AddRange(new List<Employee>
            //{
            //    new Employee { Name = "John Doe", Email = "john@example.com", DOB = DateTime.Parse("1990-01-01"), CreatedOn = DateTime.Now.AddDays(-5) },
            //    new Employee { Name = "Jane Smith", Email = "jane@example.com", DOB = DateTime.Parse("1985-02-15"), CreatedOn = DateTime.Now.AddDays(-10) }
            //});
            
            _context.Department.AddRange(new List<Department>
            {
                new Department { Id = 3, Name = "Department 3" },
                new Department { Id = 4, Name = "Department 4" }
            });

            _context.SaveChanges();
        }

        [Test]
        public async Task GetAll()
        {
            // Arrange
            var departmentService = new DepartmentService(new UnitOfWork(_context));
            var controller = new DepartmentController(departmentService);
            
            // Act
            var result = await controller.GetAll();
            Assert.IsNotNull(result);

            var department = ((ResponseDTO<IEnumerable<Department>>)((ObjectResult)result.Result).Value).Result;
            Assert.IsNotNull(department);
            Assert.IsTrue(department.Count() == 2);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the in-memory database after each test
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
