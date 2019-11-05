using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleBooksApi.Data;
using SimpleBooksApi.Model;

namespace SimpleBooksApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Autor/{autorId}/[controller]")]    
    public class LivroController : ControllerBase
    {
        private readonly SimpleBooksDbContext _context = new SimpleBooksDbContext();

        // GET: api/autor/3/livro
        [HttpGet]
        public IEnumerable<Livro> BuscarLivrosDoAutor([FromRoute] int autorId)
        {
            return _context.Livros.Where(l => l.AutorId == autorId);
        }

        // GET: api/autor/3/livro/5
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarLivro([FromRoute] int autorId, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var livro = await _context.Livros.SingleOrDefaultAsync(l => l.Id == id && l.AutorId == autorId);

            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        // PUT: api/autor/3/livro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLivro([FromRoute] int autorId, [FromRoute] int id, [FromBody] Livro livro)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livroOriginal = await _context.Livros.FindAsync(id);

            if (livroOriginal != null)
            {
                livroOriginal.Titulo = livro.Titulo;
                livroOriginal.Paginas = livro.Paginas;
                livroOriginal.Nota = livro.Nota;
                livroOriginal.Resumo = livro.Resumo;
                livroOriginal.Ano = livro.Ano;

                _context.SaveChanges();

                return Ok(livro);
            }

            return NotFound();
        }

        // POST: api/autor/3/livro        
        [HttpPost]
        public async Task<IActionResult> CriarLivro([FromRoute] int autorId, [FromBody] Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            livro.AutorId = autorId;
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("BuscarLivro", new { autorId = autorId, id = livro.Id }, livro);
        }

        // DELETE: api/autor/3/livro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirLivro([FromRoute] int autorId, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return Ok(livro);
        }

    }
}