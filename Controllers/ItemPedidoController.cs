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
    public class ItemPedidoController : Controller
    {
        private readonly PanificadoradbContext _context;

        public ItemPedidoController(PanificadoradbContext context)
        {
            _context = context;
        }

        // GET: ItemPedido
        public async Task<IActionResult> Index()
        {
            var panificadoradbContext = _context.TbItemPedidos.Include(t => t.IdPedidoNavigation).Include(t => t.IdProdutoNavigation);
            return View(await panificadoradbContext.ToListAsync());
        }

        // GET: ItemPedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbItemPedidos == null)
            {
                return NotFound();
            }

            var tbItemPedido = await _context.TbItemPedidos
                .Include(t => t.IdPedidoNavigation)
                .Include(t => t.IdProdutoNavigation)
                .FirstOrDefaultAsync(m => m.IdItemPedido == id);
            if (tbItemPedido == null)
            {
                return NotFound();
            }

            return View(tbItemPedido);
        }

        // GET: ItemPedido/Create
        public IActionResult Create()
        {
            ViewData["IdPedido"] = new SelectList(_context.TbPedidos, "IdPedido", "IdPedido");
            ViewData["IdProduto"] = new SelectList(_context.TbProdutos, "IdProduto", "IdProduto");
            return View();
        }

        // POST: ItemPedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdItemPedido,IdPedido,IdProduto,Quantidade,ValorUnitario,ValorTotal,ValorDesconto")] TbItemPedido tbItemPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbItemPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPedido"] = new SelectList(_context.TbPedidos, "IdPedido", "IdPedido", tbItemPedido.IdPedido);
            ViewData["IdProduto"] = new SelectList(_context.TbProdutos, "IdProduto", "IdProduto", tbItemPedido.IdProduto);
            return View(tbItemPedido);
        }

        // GET: ItemPedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbItemPedidos == null)
            {
                return NotFound();
            }

            var tbItemPedido = await _context.TbItemPedidos.FindAsync(id);
            if (tbItemPedido == null)
            {
                return NotFound();
            }
            ViewData["IdPedido"] = new SelectList(_context.TbPedidos, "IdPedido", "IdPedido", tbItemPedido.IdPedido);
            ViewData["IdProduto"] = new SelectList(_context.TbProdutos, "IdProduto", "IdProduto", tbItemPedido.IdProduto);
            return View(tbItemPedido);
        }

        // POST: ItemPedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdItemPedido,IdPedido,IdProduto,Quantidade,ValorUnitario,ValorTotal,ValorDesconto")] TbItemPedido tbItemPedido)
        {
            if (id != tbItemPedido.IdItemPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbItemPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbItemPedidoExists(tbItemPedido.IdItemPedido))
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
            ViewData["IdPedido"] = new SelectList(_context.TbPedidos, "IdPedido", "IdPedido", tbItemPedido.IdPedido);
            ViewData["IdProduto"] = new SelectList(_context.TbProdutos, "IdProduto", "IdProduto", tbItemPedido.IdProduto);
            return View(tbItemPedido);
        }

        // GET: ItemPedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbItemPedidos == null)
            {
                return NotFound();
            }

            var tbItemPedido = await _context.TbItemPedidos
                .Include(t => t.IdPedidoNavigation)
                .Include(t => t.IdProdutoNavigation)
                .FirstOrDefaultAsync(m => m.IdItemPedido == id);
            if (tbItemPedido == null)
            {
                return NotFound();
            }

            return View(tbItemPedido);
        }

        // POST: ItemPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbItemPedidos == null)
            {
                return Problem("Entity set 'PanificadoradbContext.TbItemPedidos'  is null.");
            }
            var tbItemPedido = await _context.TbItemPedidos.FindAsync(id);
            if (tbItemPedido != null)
            {
                _context.TbItemPedidos.Remove(tbItemPedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbItemPedidoExists(int id)
        {
          return (_context.TbItemPedidos?.Any(e => e.IdItemPedido == id)).GetValueOrDefault();
        }
    }
}
