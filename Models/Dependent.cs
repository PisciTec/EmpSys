using System;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Nome do Dependente")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome não pode ser maior que 50 caracteres.")]
        public string name { get; set; }
        public string cpf { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime dateBirth { get; set; }
        [Display(Name = "Gênero")]
        public Gender? Gender { get; set; }

        public Employee Employee { get; set; }
    }
}
