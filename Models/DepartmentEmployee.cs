using System.ComponentModel.DataAnnotations.Schema;

namespace API.IMDB.Models
{
    [Table("dept_emp")]
    public class DepartmentEmployee
    {
        [Column("emp_no")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Column("dept_no")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}