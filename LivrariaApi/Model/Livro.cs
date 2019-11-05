using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBooksApi.Model
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Titulo { get; set; }

        [Required]
        [Range(0, 2100)]
        public int Ano { get; set; }

        [Required]
        [Range(0, 5000)]
        public int Paginas { get; set; }

        [Required]
        [Range(0, 5)]
        public int Nota { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 15)]
        public string Resumo { get; set; }

        public int AutorId { get; set; }
    }
}
