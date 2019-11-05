using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBooks.Models
{
    public class AutorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(80, ErrorMessage = "Mínimo de 2 e máximo de 80 caracteres ", MinimumLength = 2)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(200, ErrorMessage = "Mínimo de 10 e máximo de 200 caracteres ", MinimumLength = 10)]
        public string Biografia { get; set; }
    }
}
