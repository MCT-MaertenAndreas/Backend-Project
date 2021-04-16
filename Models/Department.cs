using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.IMDB.Models
{
    [Table("departments")]
    public class Department
    {
        [Column("dept_no")]
        public int DepartmentId { get; set; }
        [Column("dept_name")]
        public string Name { get; set; }

        public ICollection<DepartmentEmployee> Employees { get; set; }
        public ICollection<DepartmentManager> Managers { get; set; }
    }
}