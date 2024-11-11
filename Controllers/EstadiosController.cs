using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Taller_en_Clase.Data;
using Taller_en_Clase.Models;

namespace Taller_en_Clase.Controllers
{
    public class EstadiosController : Controller
    {
        private readonly Taller_en_ClaseContext _context;

        public EstadiosController(Taller_en_ClaseContext context)
        {
            _context = context;
        }

        // GET: Estadios
        // Método para mostrar todos los estadios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estadio.ToListAsync());
        }

        // GET: Estadios/Details/5
        // Método para mostrar los detalles de un estadio específico
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // GET: Estadios/Create
        // Método para mostrar el formulario de creación de un nuevo estadio
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estadios/Create
        // Método para crear un nuevo estadio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Direccion,Ciudad,Capacidad")] Estadio estadio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadio);
        }

        // GET: Estadios/Edit/5
        // Método para mostrar el formulario de edición de un estadio existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio.FindAsync(id);
            if (estadio == null)
            {
                return NotFound();
            }
            return View(estadio);
        }

        // POST: Estadios/Edit/5
        // Método para guardar los cambios realizados en un estadio existente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Direccion,Ciudad,Capacidad")] Estadio estadio)
        {
            if (id != estadio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadioExists(estadio.Id))
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
            return View(estadio);
        }

        // GET: Estadios/Delete/5
        // Método para mostrar la vista de confirmación de eliminación de un estadio
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadio = await _context.Estadio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estadio == null)
            {
                return NotFound();
            }

            return View(estadio);
        }

        // POST: Estadios/Delete/5
        // Método para confirmar la eliminación de un estadio
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var estadio = await _context.Estadio.FindAsync(id);
                if (estadio != null)
                {
                    _context.Estadio.Remove(estadio);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manejo de error en caso de que ocurra una excepción al eliminar el estadio
                ModelState.AddModelError("", "No se pudo eliminar el estadio.");
            }
            return RedirectToAction(nameof(Index));
        }

        // Método privado para verificar si un estadio existe en la base de datos
        private bool EstadioExists(int id)
        {
            return _context.Estadio.Any(e => e.Id == id);
        }
    }
}
