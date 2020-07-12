using GestorDeTaller.BL;
using GestorDeTaller.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestorDeTaller.UI.Controllers
{
    [Authorize]
    public class OrdenesDeMantenimientoCanceladasController : Controller
    {
        private readonly IRepositorioDeTaller Repositorio;

        public OrdenesDeMantenimientoCanceladasController()
        {
           
        }
        public async Task<IActionResult> ListarOrdenesDeMantenimientoCanceladas()
        {
            List<OrdenDeMantenimiento> laLista = new List<OrdenDeMantenimiento>();
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:5001/api/OrdenesDeMantenimientoCanceladas");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<OrdenDeMantenimiento>>(apiResponse);
            }
            catch (Exception)
            {

                throw;
            }
            return View(laLista);

        }


        public ActionResult DetallesDeLaOrden(int id)
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

        // GET: OrdenesDeMantenimientoCanceladas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenesDeMantenimientoCanceladas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenesDeMantenimientoCanceladas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrdenesDeMantenimientoCanceladas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenesDeMantenimientoCanceladas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenesDeMantenimientoCanceladas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}