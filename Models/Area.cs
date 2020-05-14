using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EmpSys.Models
{
    public class AreaVM
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Area
    {
         public int ID { get; set; }
        [Display(Name = "Nome da Área")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome não pode ser maior que 50 caracteres.")]
        public string name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
