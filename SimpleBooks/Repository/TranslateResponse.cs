using SimpleBooks.Data;
using SimpleBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleBooks.Repository
{
    public class TranslateResponse
    {
        private ServiceRepository repositorio = new ServiceRepository();

        public List<AutorViewModel> BuscarTodosAutores()
        {
            List<AutorViewModel> autores = null;
            List<Autor> cadastrados = null;

            HttpResponseMessage response = repositorio.GetResponse("api/autor");

            if(response.IsSuccessStatusCode == true)
            {
                cadastrados = response.Content.ReadAsAsync<List<Autor>>().Result;
                if(cadastrados.Count > 0)
                {
                    autores = TraduzirListaAutores(cadastrados);
                }
            }

            return autores;
        }

        public AutorViewModel BuscarAutor(int id ,out List<LivroViewModel> livros)
        {
            AutorViewModel autor = null;             

            HttpResponseMessage response = repositorio.GetResponse("api/autor/"+id);

            livros = null;
            if (response.IsSuccessStatusCode == true)
            {
                Autor cadastrado = response.Content.ReadAsAsync<Autor>().Result;
                autor = TraduzirAutor(cadastrado);                

                if(cadastrado.Livros.Count > 0)
                {                    
                    livros = TraduzirListaLivros(cadastrado.Livros);
                }
            }

            return autor;
        }
        
        public AutorViewModel AtualizarAutor(int id, AutorViewModel autor)
        {
            Autor autorPreparado = PrepararAutor(autor);

            HttpResponseMessage response = repositorio.PutResponse("api/autor/" + id, autorPreparado);

            if (response.IsSuccessStatusCode != true)
            {
                return null;
            }

            return autor;
        }

        public AutorViewModel CriarAutor(AutorViewModel autor)
        {
            Autor autorPreparado = PrepararAutor(autor);

            HttpResponseMessage response = repositorio.PostResponse("api/autor", autorPreparado);

            if (response.IsSuccessStatusCode != true)
            {
                return null;
            }

            return autor;
        }

        public AutorViewModel DeletarAutor(int id, AutorViewModel autor)
        {
            HttpResponseMessage response = repositorio.DeleteResponse("api/autor/" + id);

            if (response.IsSuccessStatusCode != true)
            {
                return null;
            }

            return autor;
        }

        public LivroViewModel BuscarLivro(int autorId, int id)
        {
            LivroViewModel livro = null;

            HttpResponseMessage response = repositorio.GetResponse("api/autor/" + autorId + "/livro/" + id);

            if (response.IsSuccessStatusCode == true)
            {
                Livro cadastrado = response.Content.ReadAsAsync<Livro>().Result;
                livro = TraduzirLivro(cadastrado);                
            }

            return livro;
        }

        public LivroViewModel AtualizarLivro(int autorId, int id, LivroViewModel livro)
        {
            Livro livroPreparado = PrepararLivro(livro,autorId);

            HttpResponseMessage response = repositorio.PutResponse("api/autor/" + autorId + "/livro/" + id, livroPreparado);

            if (response.IsSuccessStatusCode != true)
            {
                return null;
            }

            return livro;
        }

        public LivroViewModel CriarLivro(int autorId, LivroViewModel livro)
        {
            Livro livroPreparado = PrepararLivro(livro, autorId);

            HttpResponseMessage response = repositorio.PostResponse("api/autor/" + autorId + "/livro", livroPreparado);

            if (response.IsSuccessStatusCode != true)
            {
                return null;
            }

            return livro;
        }

        public bool DeletarLivro(int autorId, int id)
        {
            HttpResponseMessage response = repositorio.DeleteResponse("api/autor/" + autorId + "/livro/" + id);

            if (response.IsSuccessStatusCode != true)
            {
                return false;
            }

            return true;
        }


        private Autor PrepararAutor(AutorViewModel autor)
        {
            Autor autorPreparado = new Autor();
           
            autorPreparado.Nome = autor.Nome;
            autorPreparado.DataNascimento = autor.DataNascimento;
            autorPreparado.Biografia = autor.Biografia;            

            return autorPreparado;
        }

        private Livro PrepararLivro(LivroViewModel livro, int autorId)
        {
            Livro livroPreparado = new Livro();
            
            livroPreparado.Titulo = livro.Titulo;
            livroPreparado.Resumo = livro.Resumo;
            livroPreparado.Ano = livro.Ano;
            livroPreparado.Paginas = livro.Paginas;
            livroPreparado.Nota = livro.Nota;            

            return livroPreparado;
        }


        private AutorViewModel TraduzirAutor(Autor autor)
        {
            AutorViewModel autorTraduzido = new AutorViewModel();

            autorTraduzido.Id = autor.Id;
            autorTraduzido.Nome = autor.Nome;
            autorTraduzido.DataNascimento = autor.DataNascimento;
            autorTraduzido.Biografia = autor.Biografia;

            return autorTraduzido;
        }

        private LivroViewModel TraduzirLivro(Livro livro)
        {
            LivroViewModel livroTraduzido = new LivroViewModel();

            livroTraduzido.Id = livro.Id;
            livroTraduzido.Titulo = livro.Titulo;
            livroTraduzido.Resumo = livro.Resumo;
            livroTraduzido.Ano = livro.Ano;
            livroTraduzido.Paginas = livro.Paginas;
            livroTraduzido.Nota = livro.Nota;

            return livroTraduzido;
        }

        private List<AutorViewModel> TraduzirListaAutores(List<Autor> autores)
        {
            List<AutorViewModel> autoresTraduzidos = new List<AutorViewModel>();

            foreach(Autor a in autores)
            {
                AutorViewModel autor = TraduzirAutor(a);
                autoresTraduzidos.Add(autor);
            }

            return autoresTraduzidos;
        }

        private List<LivroViewModel> TraduzirListaLivros(List<Livro> livros)
        {
            List<LivroViewModel> livrosTraduzidos = new List<LivroViewModel>();

            foreach (Livro l in livros)
            {
                LivroViewModel livro = TraduzirLivro(l);
                livrosTraduzidos.Add(livro);
            }

            return livrosTraduzidos;
        }
    }
}
