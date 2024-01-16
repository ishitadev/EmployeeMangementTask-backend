using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Department? Department { get; set; }
    }
}
