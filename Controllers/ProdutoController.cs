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
    public class ProdutoController : Controller
    {
        private readonly PanificadoradbContext _context;

        public ProdutoController(PanificadoradbContext context)
        {
            _context = context;
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
              return _context.TbProdutos != null ? 
                          View(await _context.TbProdutos.ToListAsync()) :
                          Problem("Entity set 'PanificadoradbContext.TbProdutos'  is null.");
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbProdutos == null)
            {
                return NotFound();
            }

            var tbProduto = await _context.TbProdutos
                .FirstOrDefaultAsync(m => m.IdProduto == id);
            if (tbProduto == null)
            {
                return NotFound();
            }

            return View(tbProduto);
        }

        // GET: Produto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduto,NomeProduto,Unidade")] TbProduto tbProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbProduto);
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbProdutos == null)
            {
                return NotFound();
            }

            var tbProduto = await _context.TbProdutos.FindAsync(id);
            if (tbProduto == null)
            {
                return NotFound();
            }
            return View(tbProduto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduto,NomeProduto,Unidade")] TbProduto tbProduto)
        {
            if (id != tbProduto.IdProduto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbProdutoExists(tbProduto.IdProduto))
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
            return View(tbProduto);
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbProdutos == null)
            {
                return NotFound();
            }

            var tbProduto = await _context.TbProdutos
                .FirstOrDefaultAsync(m => m.IdProduto == id);
            if (tbProduto == null)
            {
                return NotFound();
            }

            return View(tbProduto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbProdutos == null)
            {
                return Problem("Entity set 'PanificadoradbContext.TbProdutos'  is null.");
            }
            var tbProduto = await _context.TbProdutos.FindAsync(id);
            if (tbProduto != null)
            {
                _context.TbProdutos.Remove(tbProduto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbProdutoExists(int id)
        {
          return (_context.TbProdutos?.Any(e => e.IdProduto == id)).GetValueOrDefault();
        }
    }
}
