using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpSys.Models
{
    public enum Gender { M, F }

    public class Employee    {
        public int ID { get; set; }
        public int AreaID { get; set; }
        public string name { get; set; }
        public string cpf { get; set; }
        public DateTime dateBirth { get; set; }
        public float paycheck { get; set; }
        public bool payment { get; set; }
        public Gender? Gender { get; set; }

        public Area Area { get; set; }

        public ICollection<Dependent> Dependents { get; set; }
    }
}
