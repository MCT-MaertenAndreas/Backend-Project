using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.IMDB.Models
{
    [Table("employees")]
    public class Employee
    {
        [Column("emp_no")]
        public int EmployeeId { get; set; }
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("gender")]
        public string Gender { get; set; } // enum M/F
        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        public ICollection<DepartmentEmployee> DepartmentsEmployed { get; set; }
        public ICollection<DepartmentManager> DepartmentsManaging { get; set; }

        public ICollection<Title> Titles { get; set; }
        public ICollection<Salary> Salaries { get; set; }
    }
}