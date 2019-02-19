using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeLembretes.Models;

namespace SistemaDeLembretes.Controllers
{
    public class LembretesController : Controller
    {
        private readonly SistemaDeLembretesContext _context;

        public LembretesController(SistemaDeLembretesContext context)
        {
            _context = context;
        }

        // GET: Lembretes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lembrete.ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        // GET: Lembretes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembrete
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lembrete == null)
            {
                return NotFound();
            }

            return View(lembrete);
        }

        // GET: Lembretes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lembretes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Data")] Lembrete lembrete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lembrete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lembrete);
        }

        // GET: Lembretes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembrete.FindAsync(id);
            if (lembrete == null)
            {
                return NotFound();
            }
            return View(lembrete);
        }

        // POST: Lembretes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Data")] Lembrete lembrete)
        {
            if (id != lembrete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lembrete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LembreteExists(lembrete.Id))
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
            return View(lembrete);
        }

        // GET: Lembretes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lembrete = await _context.Lembrete
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lembrete == null)
            {
                return NotFound();
            }

            return View(lembrete);
        }

        // POST: Lembretes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lembrete = await _context.Lembrete.FindAsync(id);
            _context.Lembrete.Remove(lembrete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LembreteExists(int id)
        {
            return _context.Lembrete.Any(e => e.Id == id);
        }
    }
}
