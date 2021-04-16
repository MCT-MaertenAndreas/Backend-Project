using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.IMDB.Models
{
    [Table("salaries")]
    public class Salary
    {
        [Column("emp_no")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Column("salary")]
        public int Amount { get; set; }
        [Column("from_date")]
        public DateTime FromDate { get; set; }
        [Column("to_date")]
        public DateTime ToDate { get; set; }
    }
}