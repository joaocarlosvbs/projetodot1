using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetodot1.Models;

namespace projetodot1.Controllers
{
    public class EmprestimosController : Controller
    {
        private readonly Contexto _context;

        public EmprestimosController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var contexto = _context.Emprestimos.Include(e => e.Aluno).Include(e => e.Livro);
            return View(await contexto.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos
                .Include(e => e.Aluno)
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }
        
        public IActionResult Create()
        {            
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome");
            ViewData["LivroId"] = new SelectList(_context.Livros.Where(l => l.Status == StatusLivro.Disponível), "Id", "Titulo");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataEmprestimo,DataDevolucao,LivroId,AlunoId")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {                
                var livro = await _context.Livros.FindAsync(emprestimo.LivroId);
                if (livro != null && livro.Status == StatusLivro.Disponível)
                {
                    livro.Status = StatusLivro.Emprestado;
                    _context.Update(livro);

                    _context.Add(emprestimo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }                
                ModelState.AddModelError("LivroId", "O livro selecionado não está mais disponível.");
            }            
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", emprestimo.AlunoId);
            ViewData["LivroId"] = new SelectList(_context.Livros.Where(l => l.Status == StatusLivro.Disponível), "Id", "Titulo", emprestimo.LivroId);
            return View(emprestimo);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }            
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", emprestimo.AlunoId);
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Titulo", emprestimo.LivroId);
            return View(emprestimo);
        }
               
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataEmprestimo,DataDevolucao,LivroId,AlunoId")] Emprestimo emprestimo)
        {
            if (id != emprestimo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {                   
                    if (emprestimo.DataDevolucao.HasValue)
                    {
                        var livro = await _context.Livros.FindAsync(emprestimo.LivroId);
                        if (livro != null)
                        {
                            livro.Status = StatusLivro.Disponível;
                            _context.Update(livro);
                        }
                    }

                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }        
            ViewData["AlunoId"] = new SelectList(_context.Alunos, "Id", "Nome", emprestimo.AlunoId);
            ViewData["LivroId"] = new SelectList(_context.Livros, "Id", "Titulo", emprestimo.LivroId);
            return View(emprestimo);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimos
                .Include(e => e.Aluno)
                .Include(e => e.Livro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emprestimo = await _context.Emprestimos.FindAsync(id);
            if (emprestimo != null)
            {
                var livro = await _context.Livros.FindAsync(emprestimo.LivroId);
                if (livro != null)
                {
                    livro.Status = StatusLivro.Disponível;
                    _context.Update(livro);
                }

                _context.Emprestimos.Remove(emprestimo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoExists(int id)
        {
            return _context.Emprestimos.Any(e => e.Id == id);
        }
    }
}