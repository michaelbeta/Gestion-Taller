using GestorDeTaller.BL;
using GestorDeTaller.Model;
using GestorDeTaller.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestorDeTaller.UI.Controllers
{
    public class OrdenesDeMantenimientoEnProcesoController : Controller
    {
        private readonly IRepositorioDeTaller Repositorio;

        public OrdenesDeMantenimientoEnProcesoController()
        {
            
        }

        public async Task<IActionResult> ListarOrdenesDeMantenimentoEnProceso()
        {
            
            List<OrdenDeMantenimiento> laLista = new List<OrdenDeMantenimiento>();
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:5001/api/OrdenesDeMantenimientoEnProceso");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<OrdenDeMantenimiento>>(apiResponse);
            }
            catch (Exception)
            {

                throw;
            }
            return View(laLista);
        }

        public ActionResult TerminarOrdeMantenimiento(int id)
        {
            Repositorio.TerminarMantenimiento(id);
            return RedirectToAction(nameof(ListarOrdenesDeMantenimentoEnProceso));
        }

        public ActionResult CancelarOrdenDeMantenimiento(int id)
        {
            MotivoDeCancelacion motivoDeCancelacion = new MotivoDeCancelacion();
            motivoDeCancelacion.Id = id;

            return View(motivoDeCancelacion);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CancelarOrdenDeMantenimiento(MotivoDeCancelacion motivoCancelacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.CancelarMantenimiento(motivoCancelacion.Id, motivoCancelacion.motivoDeCancelacion);

                    return RedirectToAction(nameof(ListarOrdenesDeMantenimentoEnProceso));
                }
                else
                {
                    return View(motivoCancelacion);
                }
            }
            catch (Exception)
            {

                return View(motivoCancelacion);
            }


        }
        public ActionResult AgregarMantenimiento(int id)
        {
            List<Mantenimiento> laLista;
            laLista = Repositorio.ObtenerMantenimiento();
            TempData["IdOrdenDeMantenimiento"] = id;
            ViewBag.laLista = laLista;
            return View();
        }

        [HttpPost]
        public ActionResult AgregarMantenimiento(String Mantenimiento)
        {
            int idMantenimiento = Int32.Parse(Mantenimiento);
            int idOrdenDeMantenimiento = int.Parse(TempData["IdOrdenDeMantenimiento"].ToString());
            Repositorio.AgregarDetallesOrdenesDeMantenimiento(idMantenimiento, idMantenimiento);

            return RedirectToAction(nameof(ListarOrdenesDeMantenimentoEnProceso));
        }

        public ActionResult DetallesDeOrdenDeMantenimiento(int id)
        {

            OrdenDeMantenimiento DetallesDelAOrden;
            DetallesDelAOrden = Repositorio.ObtenerOrdenesDeMantenimentoCanceladasPorid(id);

            List<Articulo> articuloAsociado;
            articuloAsociado = Repositorio.ObtenerArticuloAsociadosALaOrdenEnMantenimiento(id);

            List<Mantenimiento> MantenimientoAsosiado;
            MantenimientoAsosiado = Repositorio.ObtenermantenimientoAsociadosalaOrden(id);

            ViewData["Articulo"] = articuloAsociado;
            ViewData["Mantenimiento"] = MantenimientoAsosiado;

            return View(DetallesDelAOrden);

        }

        public ActionResult Articulo(int id)
        {
            Articulo elArticulo;
            elArticulo = Repositorio.ObtenerPorId(id);
            return View(elArticulo);
        }

        public ActionResult MostrarMantenimiento(int id)
        {
            List<Costos> elCosto;
            elCosto = Repositorio.ObtenerCatalogoDeMantenimeintosMasRepuestos(id);
            return View(elCosto);


        }
    }
}