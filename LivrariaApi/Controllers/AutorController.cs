using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBooksApi.Data;
using SimpleBooksApi.Model;

namespace SimpleBooksApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]    
    public class AutorController : Controller
    {
        private readonly SimpleBooksDbContext _context = new SimpleBooksDbContext();

        // GET: api/autor
        [HttpGet]
        public IEnumerable<Autor> ListarAutores()
        {
            return _context.Autores;
        }

        // GET: api/autor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscaAutor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var autor = await _context.Autores.FindAsync(id);

            if (autor == null)
            {
                return NotFound();
            }

            var livrosAutor = _context.Livros.Where(l => l.AutorId == id);
            autor.Livros = livrosAutor.ToList();

            return Ok(autor);
        }

        // PUT: api/autor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAutor([FromRoute] int id, [FromBody] Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var autorOriginal = await _context.Autores.FindAsync(id);

            if (autorOriginal != null)
            {
                autorOriginal.Nome = autor.Nome;
                autorOriginal.DataNascimento = autor.DataNascimento;
                autorOriginal.Biografia = autor.Biografia;
                _context.SaveChanges();

                return Ok(autor);
                
            }
            return NotFound();

        }

        // POST: api/autor        
        [HttpPost]
        public async Task<IActionResult> CriarAutor([FromBody] Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("BuscaAutor", new { id = autor.Id }, autor);
        }

        // DELETE: api/autor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAutor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            var livrosAutor = _context.Livros.Where(l => l.AutorId == id);
            foreach (Livro l in livrosAutor)
            {
                _context.Livros.Remove(l);
            }

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();

            return Ok(autor);
        }

    }
}