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
    public class JugadorsController : Controller
    {
        private readonly Taller_en_ClaseContext _context;

        public JugadorsController(Taller_en_ClaseContext context)
        {
            _context = context;
        }

        // GET: Jugadors
        // Método para mostrar la lista de todos los jugadores
        public async Task<IActionResult> Index()
        {
            var taller_en_ClaseContext = _context.Jugador.Include(j => j.Equipo);
            return View(await taller_en_ClaseContext.ToListAsync());
        }

        // GET: Jugadors/Details/5
        // Método para mostrar los detalles de un jugador específico
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugadors/Create
        // Método para mostrar el formulario de creación de un nuevo jugador
        public IActionResult Create()
        {
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Nombre");
            return View();
        }

        // POST: Jugadors/Create
        // Método para crear un nuevo jugador
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,posicion,edad,IdEquipo")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Id", jugador.IdEquipo);
            return View(jugador);
        }

        // GET: Jugadors/Edit/5
        // Método para mostrar el formulario de edición de un jugador existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador.FindAsync(id);
            if (jugador == null)
            {
                return NotFound();
            }
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Id", jugador.IdEquipo);
            return View(jugador);
        }

        // POST: Jugadors/Edit/5
        // Método para guardar los cambios en un jugador existente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,posicion,edad,IdEquipo")] Jugador jugador)
        {
            if (id != jugador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.Id))
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
            ViewData["IdEquipo"] = new SelectList(_context.Equipo, "Id", "Id", jugador.IdEquipo);
            return View(jugador);
        }

        // GET: Jugadors/Delete/5
        // Método para mostrar la confirmación de eliminación de un jugador
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugadors/Delete/5
        // Método para confirmar la eliminación de un jugador
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var jugador = await _context.Jugador.FindAsync(id);
                if (jugador != null)
                {
                    _context.Jugador.Remove(jugador);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Manejo de error en caso de que ocurra una excepción al eliminar el jugador
                ModelState.AddModelError("", "No se pudo eliminar el jugador.");
            }
            return RedirectToAction(nameof(Index));
        }

        // Método privado para verificar si un jugador existe en la base de datos
        private bool JugadorExists(int id)
        {
            return _context.Jugador.Any(e => e.Id == id);
        }
    }
}
