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
    public class PedidoController : Controller
    {
        private readonly PanificadoradbContext _context;

        public PedidoController(PanificadoradbContext context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index()
        {
            var panificadoradbContext = _context.TbPedidos.Include(t => t.IdClienteNavigation).Include(t => t.IdRotaNavigation);
            return View(await panificadoradbContext.ToListAsync());
        }

        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbPedidos == null)
            {
                return NotFound();
            }

            var tbPedido = await _context.TbPedidos
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdRotaNavigation)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (tbPedido == null)
            {
                return NotFound();
            }

            return View(tbPedido);
        }

        // GET: Pedido/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.TbClientes, "IdCliente", "IdCliente");
            ViewData["IdRota"] = new SelectList(_context.TbRota, "IdRota", "IdRota");
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,IdCliente,IdItemPedido,IdRota,Observacoes,DataInicioRecorrencia,DataFinalRecorrencia,Data")] TbPedido tbPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.TbClientes, "IdCliente", "IdCliente", tbPedido.IdCliente);
            ViewData["IdRota"] = new SelectList(_context.TbRota, "IdRota", "IdRota", tbPedido.IdRota);
            return View(tbPedido);
        }

        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbPedidos == null)
            {
                return NotFound();
            }

            var tbPedido = await _context.TbPedidos.FindAsync(id);
            if (tbPedido == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.TbClientes, "IdCliente", "IdCliente", tbPedido.IdCliente);
            ViewData["IdRota"] = new SelectList(_context.TbRota, "IdRota", "IdRota", tbPedido.IdRota);
            return View(tbPedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,IdCliente,IdItemPedido,IdRota,Observacoes,DataInicioRecorrencia,DataFinalRecorrencia,Data")] TbPedido tbPedido)
        {
            if (id != tbPedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbPedidoExists(tbPedido.IdPedido))
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
            ViewData["IdCliente"] = new SelectList(_context.TbClientes, "IdCliente", "IdCliente", tbPedido.IdCliente);
            ViewData["IdRota"] = new SelectList(_context.TbRota, "IdRota", "IdRota", tbPedido.IdRota);
            return View(tbPedido);
        }

        // GET: Pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbPedidos == null)
            {
                return NotFound();
            }

            var tbPedido = await _context.TbPedidos
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdRotaNavigation)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (tbPedido == null)
            {
                return NotFound();
            }

            return View(tbPedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbPedidos == null)
            {
                return Problem("Entity set 'PanificadoradbContext.TbPedidos'  is null.");
            }
            var tbPedido = await _context.TbPedidos.FindAsync(id);
            if (tbPedido != null)
            {
                _context.TbPedidos.Remove(tbPedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbPedidoExists(int id)
        {
          return (_context.TbPedidos?.Any(e => e.IdPedido == id)).GetValueOrDefault();
        }
    }
}
