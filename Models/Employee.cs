using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpSys.Models
{
    public enum Gender { M, F }

    public class Employee    {
        public int ID { get; set; }
        public int AreaID { get; set; }

        [Display(Name = "Nome do Funcionário")]
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome não pode ser maior que 50 caracteres.")]
        public string name { get; set; }
        public string cpf { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime dateBirth { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Salário")]
        public decimal paycheck { get; set; }
        public bool payment { get; set; }
        [Display(Name = "Gênero")]
        public Gender? Gender { get; set; }

        public Area Area { get; set; }

        public ICollection<Dependent> Dependents { get; set; }
    }
}
