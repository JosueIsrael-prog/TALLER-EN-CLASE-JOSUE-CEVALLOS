using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taller_en_Clase.Models;

namespace Taller_en_Clase.Controllers
{
    public class HomeController : Controller
    {
        // Método para mostrar la página de inicio
        public IActionResult Index()
        {
            return View();
        }

        // Método para mostrar la página de privacidad
        public IActionResult Privacy()
        {
            return View();
        }

        // Método para manejar errores en la aplicación
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Se usa la clase ErrorViewModel para capturar la información del error
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
