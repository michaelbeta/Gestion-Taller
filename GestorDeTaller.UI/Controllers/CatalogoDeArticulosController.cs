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

                var response = await httpClient.GetAsync("https://localhost:5001/api/CatalogoDeArticulos");

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

        public async Task<IActionResult> DetallesDelArticulo(int id)
        {
            Articulo articulo;
            List<Repuesto> repuestoasociado = new List<Repuesto>();
            List<OrdenDeMantenimiento> ordenesDeMantenimientosEnProceso = new List<OrdenDeMantenimiento>();
            List<OrdenDeMantenimiento> ordenesDeMantenimientosTerminadas = new List<OrdenDeMantenimiento>();
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:5001/api/CatalogoDeArticulos/Detalles_De_Articulo" + id.ToString());
                string apiResponse = await response.Content.ReadAsStringAsync();
                articulo = JsonConvert.DeserializeObject<Articulo>(apiResponse);
                ////////////////////////
                var httpClientRepuesto = new HttpClient();
                var responseRepuesto = await httpClientRepuesto.GetAsync("https://localhost:5001/api/CatalogoDeArticulos");
                string apiResponseRepuesto = await responseRepuesto.Content.ReadAsStringAsync();
                repuestoasociado = JsonConvert.DeserializeObject<List<Repuesto>>(apiResponseRepuesto);
                ViewData["Repuesto"] = repuestoasociado;
                ///////////////////////
                var httpClientordenesDeMantenimientosEnProceso = new HttpClient();
                var responseordenesDeMantenimientosEnProceso = await httpClientordenesDeMantenimientosEnProceso.GetAsync("https://localhost:5001/api/CatalogoDeArticulos");
                string apiResponseordenesDeMantenimientosEnProceso = await responseordenesDeMantenimientosEnProceso.Content.ReadAsStringAsync();
                ordenesDeMantenimientosEnProceso = JsonConvert.DeserializeObject<List<OrdenDeMantenimiento>>(apiResponseordenesDeMantenimientosEnProceso);
                int CantidadDeOrdenesEnProceso = ordenesDeMantenimientosEnProceso.Count();
                ViewBag.OrdenesEnProceso = CantidadDeOrdenesEnProceso;
                ///////////////////////
                var httpClientordenesDeMantenimientosTerminadas = new HttpClient();
                var responseordenesDeMantenimientosTerminadas = await httpClientordenesDeMantenimientosTerminadas.GetAsync("https://localhost:5001/api/CatalogoDeArticulos");
                string apiResponseordenesDeMantenimientosTerminadas = await responseordenesDeMantenimientosTerminadas.Content.ReadAsStringAsync();
                ordenesDeMantenimientosTerminadas = JsonConvert.DeserializeObject<List<OrdenDeMantenimiento>>(apiResponseordenesDeMantenimientosTerminadas);
                int CantidadDeOrdenesTerminadas = ordenesDeMantenimientosTerminadas.Count();
                ViewBag.OrdenesTerminadas = CantidadDeOrdenesTerminadas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(articulo);

            /*Articulo detalleDeLArticulo;
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

            return View(detalleDeLArticulo);*/
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

                    await httpClient.PostAsync("https://localhost:5001/api/CatalogoDeArticulos", byteContent);

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

        // POST: CatalogoDeArticulos/Edit/5 //
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