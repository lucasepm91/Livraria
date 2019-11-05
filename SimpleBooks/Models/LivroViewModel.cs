using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBooks.Models
{
    public class LivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(80, ErrorMessage = "Mínimo de 2 e máximo de 80 caracteres ", MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, 2100)]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, 5000)]
        public int Paginas { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, 5, ErrorMessage = "Informe um valor entre 0 e 5")]
        public int Nota { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(200, ErrorMessage = "Mínimo de 15 e máximo de 200 caracteres ", MinimumLength = 15)]
        public string Resumo { get; set; }
    }
}
