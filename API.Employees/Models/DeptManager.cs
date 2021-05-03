using System;
using System.Collections.Generic;
using Newtonsoft.Json;

#nullable disable

namespace API.Employees.Models
{
    public partial class DeptManager
    {
        public int EmpNo { get; set; }
        public string DeptNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }


        [JsonIgnore]
        public virtual Department DeptNoNavigation { get; set; }

        [JsonIgnore]
        public virtual Employee EmpNoNavigation { get; set; }
    }
}
