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
    public class AutorController : Controller
    {
        private TranslateResponse tr = new TranslateResponse();
        // GET: Autor
        public ActionResult Index()
        {
            List<AutorViewModel> autores = tr.BuscarTodosAutores();

            return View(autores);
        }

        // GET: Autor/Details/5
        public ActionResult Details(int id)
        {
            List<LivroViewModel> livros = null;
            AutorViewModel autor = tr.BuscarAutor(id, out livros);

            ViewBag.Livros = livros;            
            
            return View(autor);
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] AutorViewModel autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AutorViewModel autorRetorno = tr.CriarAutor(autor);
                    if(autorRetorno != null)
                        return RedirectToAction(nameof(Index));
                }
                
                return View(autor);
            }
            catch
            {
                return View();
            }
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            List<LivroViewModel> livros = null;
            AutorViewModel autorRetorno = tr.BuscarAutor(id, out livros);

            if (autorRetorno == null)
            {
                return StatusCode(404);
            }

            return View(autorRetorno);
        }

        // POST: Autor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AutorViewModel autor)
        {
            try
            {
                AutorViewModel autorRetorno = tr.AtualizarAutor(id, autor);
                if (autorRetorno != null)
                    return RedirectToAction(nameof(Index));

                return View(autor);
            }
            catch
            {
                return View(autor);
            }
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int id)
        {
            List<LivroViewModel> livros = null;
            AutorViewModel autorRetorno = tr.BuscarAutor(id, out livros);

            if (autorRetorno == null)
            {
                return StatusCode(404);
            }

            return View(autorRetorno);
        }

        // POST: Autor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AutorViewModel autor)
        {
            try
            {
                AutorViewModel autorRetorno = tr.DeletarAutor(id, autor);
                if (autorRetorno != null)
                    return RedirectToAction(nameof(Index));

                return View(autor);
            }
            catch
            {
                return View();
            }
        }
    }
}