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
    public class MotoristaController : Controller
    {
        private readonly PanificadoradbContext _context;

        public MotoristaController(PanificadoradbContext context)
        {
            _context = context;
        }

        // GET: Motorista
        public async Task<IActionResult> Index()
        {
              return _context.TbMotorista != null ? 
                          View(await _context.TbMotorista.ToListAsync()) :
                          Problem("Entity set 'PanificadoradbContext.TbMotorista'  is null.");
        }

        // GET: Motorista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbMotorista == null)
            {
                return NotFound();
            }

            var tbMotoristum = await _context.TbMotorista
                .FirstOrDefaultAsync(m => m.IdMotorista == id);
            if (tbMotoristum == null)
            {
                return NotFound();
            }

            return View(tbMotoristum);
        }

        // GET: Motorista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motorista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMotorista,NomeMotorista")] TbMotoristum tbMotoristum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbMotoristum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbMotoristum);
        }

        // GET: Motorista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbMotorista == null)
            {
                return NotFound();
            }

            var tbMotoristum = await _context.TbMotorista.FindAsync(id);
            if (tbMotoristum == null)
            {
                return NotFound();
            }
            return View(tbMotoristum);
        }

        // POST: Motorista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMotorista,NomeMotorista")] TbMotoristum tbMotoristum)
        {
            if (id != tbMotoristum.IdMotorista)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMotoristum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMotoristumExists(tbMotoristum.IdMotorista))
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
            return View(tbMotoristum);
        }

        // GET: Motorista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbMotorista == null)
            {
                return NotFound();
            }

            var tbMotoristum = await _context.TbMotorista
                .FirstOrDefaultAsync(m => m.IdMotorista == id);
            if (tbMotoristum == null)
            {
                return NotFound();
            }

            return View(tbMotoristum);
        }

        // POST: Motorista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbMotorista == null)
            {
                return Problem("Entity set 'PanificadoradbContext.TbMotorista'  is null.");
            }
            var tbMotoristum = await _context.TbMotorista.FindAsync(id);
            if (tbMotoristum != null)
            {
                _context.TbMotorista.Remove(tbMotoristum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMotoristumExists(int id)
        {
          return (_context.TbMotorista?.Any(e => e.IdMotorista == id)).GetValueOrDefault();
        }
    }
}
