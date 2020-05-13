using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpSys.Models
{

    public class Dependent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string name { get; set; }
        public string cpf { get; set; }
        public DateTime dateBirth { get; set; }
        public Gender? Gender { get; set; }

        public Employee Employee { get; set; }
    }
}
