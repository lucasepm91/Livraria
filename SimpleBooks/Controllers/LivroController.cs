using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBooks.Models;
using SimpleBooks.Repository;

namespace SimpleBooks.Controllers
{
    [Route("Autor/{autorId}/Livro")]
    public class LivroController : Controller
    {
        private TranslateResponse tr = new TranslateResponse();
       
        [Route("{id}")]
        // GET: Livro/Details/5
        public ActionResult Details([FromRoute]int autorId,[FromRoute]int id)
        {
            LivroViewModel livro = tr.BuscarLivro(autorId, id);
            if (livro == null)
                return RedirectToAction("Index", "Autor");
            else
                return View(livro);
        }

        [Route("Create")]
        // GET: Livro/Create
        public ActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        // POST: Livro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromRoute]int autorId,LivroViewModel livro)
        {
            try
            {
                LivroViewModel livroRetorno = tr.CriarLivro(autorId, livro);

                if (livroRetorno != null)
                    return RedirectToAction("Index", "Autor");
                else
                    return View(livroRetorno);
            }
            catch
            {
                return View();
            }
        }

        [Route("Edit/{id}")]
        // GET: Livro/Edit/5
        public ActionResult Edit([FromRoute]int autorId, [FromRoute]int id)
        {
            LivroViewModel livro = tr.BuscarLivro(autorId, id);
            if (livro == null)
                return RedirectToAction("Index", "Autor");
            else
                return View(livro);
        }

        [Route("Edit/{id}")]
        // POST: Livro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute]int autorId, [FromRoute]int id, LivroViewModel livro)
        {
            try
            {
                LivroViewModel livroRetorno = tr.AtualizarLivro(autorId, id, livro);

                if (livroRetorno == null)
                    return View(livro);
                else
                    return RedirectToAction("Index", "Autor");
            }
            catch
            {
                return View();
            }
        }

        [Route("Delete/{id}")]
        // GET: Livro/Delete/5
        public ActionResult Delete([FromRoute]int autorId, [FromRoute]int id)
        {
            LivroViewModel livro = tr.BuscarLivro(autorId, id);
            if (livro == null)
                return RedirectToAction("Index", "Autor");
            else
                return View(livro);
        }

        [Route("Delete/{id}")]
        // POST: Livro/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromRoute]int autorId, [FromRoute]int id,LivroViewModel livro)
        {
            try
            {
                bool livroRetorno = tr.DeletarLivro(autorId, id);

                return RedirectToAction("Index", "Autor");
               
            }
            catch
            {
                return RedirectToAction("Index", "Autor");
            }
        }
    }
}