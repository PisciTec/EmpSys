using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpSys.Models
{
    public class Area
    {
            public int ID { get; set; }
            public string name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
