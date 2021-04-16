using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.IMDB.Models
{
    [Table("titles")]
    public class Title
    {
        [Column("emp_no")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Column("title")]
        public string Name { get; set; }
        [Column("from_date")]
        public DateTime FromDate { get; set; }
        [Column("to_date")]
        public DateTime ToDate { get; set; }
    }
}