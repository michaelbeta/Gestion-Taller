using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GestorDeTaller.BL;
using GestorDeTaller.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestorDeTaller.UI.Controllers
{
    [Authorize]
    public class OrdenesDeMantenimientoTerminadaController : Controller
    {
        private readonly IRepositorioDeTaller Repositorio;

        public OrdenesDeMantenimientoTerminadaController()
        {
           
        }
        public async Task<IActionResult> ListarOrdenesDeMantenimientoTerminadas()
        {
            List<OrdenDeMantenimiento> laLista = new List<OrdenDeMantenimiento>();
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:5001/api/OrdenesDeMantenimientoTerminadas");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<OrdenDeMantenimiento>>(apiResponse);
            }
            catch (Exception)
            {

                throw;
            }
            return View(laLista);
        }

        public ActionResult DetallesDeOrdenesDeMantenimientoTerminadas(int id)
        {
            OrdenDeMantenimiento DetallesDelAOrden;
            DetallesDelAOrden = Repositorio.ObtenerOrdenesDeMantenimentoTerminadasPorid(id);

            List<Articulo> articuloAsociado;
            articuloAsociado = Repositorio.ObtenerArticuloAsociadosALaOrdenEnMantenimiento(id);

            List<Mantenimiento> MantenimientoAsosiado;
            MantenimientoAsosiado = Repositorio.ObtenermantenimientoAsociadosalaOrden(id);

            ViewData["Articulo"] = articuloAsociado;
            ViewData["Mantenimiento"] = MantenimientoAsosiado;

            return View(DetallesDelAOrden);
        }
    }
}