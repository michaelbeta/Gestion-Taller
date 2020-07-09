using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GestorDeTaller.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace GestorDeTaller.UI.Controllers
{
    public class InicioDelLoginController : Controller
    {
        private readonly ILogger<InicioDelLoginController> _logger;

        public InicioDelLoginController(ILogger<InicioDelLoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult InicioDeLogin()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
