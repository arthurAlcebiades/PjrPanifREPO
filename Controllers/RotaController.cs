using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrjPanifMVC.Models;

namespace PrjPanifMVC.Controllers
{
    public class RotaController : Controller
    {
        private readonly PanificadoradbContext _context;

        public RotaController(PanificadoradbContext context)
        {
            _context = context;
        }

        // GET: Rota
        public async Task<IActionResult> Index()
        {
            var panificadoradbContext = _context.TbRota.Include(t => t.IdMotoristaNavigation);
            return View(await panificadoradbContext.ToListAsync());
        }

        // GET: Rota/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbRota == null)
            {
                return NotFound();
            }

            var tbRotum = await _context.TbRota
                .Include(t => t.IdMotoristaNavigation)
                .FirstOrDefaultAsync(m => m.IdRota == id);
            if (tbRotum == null)
            {
                return NotFound();
            }

            return View(tbRotum);
        }

        // GET: Rota/Create
        public IActionResult Create()
        {
            ViewData["IdMotorista"] = new SelectList(_context.TbMotorista, "IdMotorista", "IdMotorista");
            return View();
        }

        // POST: Rota/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRota,IdMotorista,Periodo")] TbRotum tbRotum)
        {
            
         //  if (ModelState.IsValid)
          // {
                _context.Add(tbRotum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
          // }
            ViewData["IdMotorista"] = new SelectList(_context.TbMotorista, "IdMotorista", "IdMotorista", tbRotum.IdMotorista);
            return View(tbRotum);
        }

        // GET: Rota/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbRota == null)
            {
                return NotFound();
            }

            var tbRotum = await _context.TbRota.FindAsync(id);
            if (tbRotum == null)
            {
                return NotFound();
            }
            ViewData["IdMotorista"] = new SelectList(_context.TbMotorista, "IdMotorista", "IdMotorista", tbRotum.IdMotorista);
            return View(tbRotum);
        }

        // POST: Rota/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRota,IdMotorista,Periodo")] TbRotum tbRotum)
        {
            if (id != tbRotum.IdRota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbRotum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbRotumExists(tbRotum.IdRota))
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
            ViewData["IdMotorista"] = new SelectList(_context.TbMotorista, "IdMotorista", "IdMotorista", tbRotum.IdMotorista);
            return View(tbRotum);
        }

        // GET: Rota/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbRota == null)
            {
                return NotFound();
            }

            var tbRotum = await _context.TbRota
                .Include(t => t.IdMotoristaNavigation)
                .FirstOrDefaultAsync(m => m.IdRota == id);
            if (tbRotum == null)
            {
                return NotFound();
            }

            return View(tbRotum);
        }

        // POST: Rota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbRota == null)
            {
                return Problem("Entity set 'PanificadoradbContext.TbRota'  is null.");
            }
            var tbRotum = await _context.TbRota.FindAsync(id);
            if (tbRotum != null)
            {
                _context.TbRota.Remove(tbRotum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbRotumExists(int id)
        {
          return (_context.TbRota?.Any(e => e.IdRota == id)).GetValueOrDefault();
        }
    }
}
