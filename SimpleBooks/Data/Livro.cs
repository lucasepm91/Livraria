using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBooks.Data
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public int Nota { get; set; }
        public string Resumo { get; set; }
        public int AutorId { get; set; }
    }
}
