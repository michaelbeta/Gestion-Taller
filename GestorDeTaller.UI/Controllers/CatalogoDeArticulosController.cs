using GestorDeTaller.BL;
using GestorDeTaller.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GestorDeTaller.Controllers
{

    public class CatalogoDeArticulosController : Controller
    {

        private readonly IRepositorioDeTaller Repositorio;

        public CatalogoDeArticulosController()
        {
           
        }
        public async Task<IActionResult> ListarCatalogoDeArticulos()
        {

            List<Articulo> laLista = new List<Articulo>();
            
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44343/api/CatalogoDeArticulos");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<Articulo>>(apiResponse);
            }
            catch (Exception)
            {

                throw;
            }
            return View(laLista);

        }

        public ActionResult ListarArticuloAsociadosARepuesto(int id)
        {
            List<Articulo> ArticuloAsociado;
            ArticuloAsociado = Repositorio.ObtenerArticuloAsociadosAlRepuesto(id);
            TempData["IdArticulo"] = id;

            return View(ArticuloAsociado);
        }
        // GET: Repuestos
        public ActionResult ListarDetallesDelRepuesto(int id)
        {
            List<Repuesto> repuestoasociado;
            repuestoasociado = Repositorio.ObtenerRepuestoAsociadosAlArticulo(id);

            return View(repuestoasociado);
        }

        // GET: CatalogoDeArticulos/Details/5
        public ActionResult DetallesDelArticulo(int id)
        {
            Articulo detalleDeLArticulo;
            detalleDeLArticulo = Repositorio.ObtenerPorId(id);
            List<Repuesto> repuestoasociado;
            repuestoasociado = Repositorio.ObtenerRepuestoAsociadosAlArticulo(id);

            ViewData["Repuesto"] = repuestoasociado;

            List<OrdenDeMantenimiento> ordenesDeMantenimientosEnProceso;
            ordenesDeMantenimientosEnProceso = Repositorio.ListarOrdenesDeMantenimientoEnProceso();
            int CantidadDeOrdenesEnProceso = ordenesDeMantenimientosEnProceso.Count();

            ViewBag.OrdenesEnProceso = CantidadDeOrdenesEnProceso;

            List<OrdenDeMantenimiento> ordenesDeMantenimientosTerminadas;
            ordenesDeMantenimientosTerminadas = Repositorio.ListarOrdenesDeMantenimientoTerminadas();
            int CantidadDeOrdenesTerminadas = ordenesDeMantenimientosTerminadas.Count();

            ViewBag.OrdenesTerminadas = CantidadDeOrdenesTerminadas;

            return View(detalleDeLArticulo);
        }

        // GET: CatalogoDeArticulos/Create
        public ActionResult AgregarArticulo()
        {
            return View();
        }

        // POST: CatalogoDeArticulos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarArticulo(Articulo articulo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var httpClient = new HttpClient();

                    string json = JsonConvert.SerializeObject(articulo);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                    var byteContent = new ByteArrayContent(buffer);

                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    await httpClient.PostAsync("https://localhost:44343/api/CatalogoDeArticulos", byteContent);

                    return RedirectToAction(nameof(ListarCatalogoDeArticulos));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                return View();
            }
           
        }

        // GET: CatalogoDeArticulos/Edit/5
        public ActionResult EditarCatalogoDeArticulos(int id)
        {
            Articulo ListarArticuloAEditar;
            ListarArticuloAEditar = Repositorio.ObtenerPorId(id);

            return View(ListarArticuloAEditar);
        }

        // POST: CatalogoDeArticulos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCatalogoDeArticulos(Articulo articulo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.EditarArticulo(articulo);

                    return RedirectToAction(nameof(ListarCatalogoDeArticulos));
                }
                else
                {
                    return View(articulo);
                }
            }
            catch (Exception)
            {

                return View(articulo);
            }
        }

    }
}