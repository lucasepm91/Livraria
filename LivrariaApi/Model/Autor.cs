using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBooksApi.Model
{
    public class Autor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Biografia { get; set; }

        public ICollection<Livro> Livros { get; set; }
    }
}
