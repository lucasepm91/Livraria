using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBooks.Data
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Biografia { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
