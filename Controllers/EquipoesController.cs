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
    public class EquipoesController : Controller
    {
        private readonly Taller_en_ClaseContext _context;

        public EquipoesController(Taller_en_ClaseContext context)
        {
            _context = context;
        }

        // GET: Equipoes
        // Método para mostrar todos los equipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Equipo.ToListAsync());
        }

        // GET: Equipoes/Details/5
        // Método para mostrar los detalles de un equipo específico
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: Equipoes/Create
        // Método para mostrar el formulario de creación de un nuevo equipo
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipoes/Create
        // Método para crear un nuevo equipo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Ciudad,Titulos,AceptaExtranjeros")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        // Método para mostrar el formulario de edición de un equipo existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }

        // POST: Equipoes/Edit/5
        // Método para guardar los cambios realizados en un equipo existente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Ciudad,Titulos,AceptaExtranjeros")] Equipo equipo)
        {
            if (id != equipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.Id))
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
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        // Método para mostrar la vista de confirmación de eliminación de un equipo
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        // Método para confirmar la eliminación de un equipo
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var equipo = await _context.Equipo.FindAsync(id);
                if (equipo != null)
                {
                    _context.Equipo.Remove(equipo);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manejo de error en caso de que ocurra una excepción al eliminar el equipo
                ModelState.AddModelError("", "No se pudo eliminar el equipo.");
            }
            return RedirectToAction(nameof(Index));
        }

        // Método privado para verificar si un equipo existe en la base de datos
        private bool EquipoExists(int id)
        {
            return _context.Equipo.Any(e => e.Id == id);
        }
    }
}
