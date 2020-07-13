using GestorDeTaller.BL;
using GestorDeTaller.Model;
using GestorDeTaller.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestorDeTaller.UI.Controllers
{
    [Authorize]
    public class OrdenesDeMantenimientoEnProcesoController : Controller
    {
        

        public OrdenesDeMantenimientoEnProcesoController()
        {
            
        }

        public async Task<IActionResult> ListarOrdenesDeMantenimentoEnProceso()
        {
            
            List<OrdenDeMantenimiento> laLista = new List<OrdenDeMantenimiento>();
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoEnProceso");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<OrdenDeMantenimiento>>(apiResponse);
            }
            catch (Exception)
            {

                throw;
            }
            return View(laLista);
        }

        public async Task<ActionResult> TerminarOrdeMantenimiento(int id)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoEnProceso/TerminarOrdenMantenimiento/" + id.ToString());
                string apiResponse = await response.Content.ReadAsStringAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
            
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
        public async Task<IActionResult> CancelarOrdenDeMantenimiento(MotivoDeCancelacion motivoCancelacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var httpClient = new HttpClient();

                    string json = JsonConvert.SerializeObject(motivoCancelacion);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                    var byteContent = new ByteArrayContent(buffer);

                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    await httpClient.PostAsync("https://localhost:44343/api/OrdenesDeMantenimientoEnProceso", byteContent);

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
        public async Task<IActionResult> AgregarMantenimiento(int id)
        {
            List<Mantenimiento> laLista;
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoEnProceso/" + id.ToString());

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<Mantenimiento>>(apiResponse);
            }
            catch (Exception)
            {

                throw;
            }
            
            TempData["IdOrdenDeMantenimiento"] = id;
            ViewBag.laLista = laLista;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarMantenimiento(String Mantenimiento)
        {
            int idMantenimiento = Int32.Parse(Mantenimiento);
            int idOrdenDeMantenimiento = int.Parse(TempData["IdOrdenDeMantenimiento"].ToString());
            try
            {

                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoEnProceso/AgregarMantenimiento/" + idMantenimiento + "/" + idOrdenDeMantenimiento);

                string apiResponse = await response.Content.ReadAsStringAsync();


            }
            catch (Exception)
            {

                return View();
            }
           // Repositorio.AgregarDetallesOrdenesDeMantenimiento(idMantenimiento, idMantenimiento);

            return RedirectToAction(nameof(ListarOrdenesDeMantenimentoEnProceso));
        }

        public async Task<IActionResult> DetallesDeOrdenDeMantenimiento(int id)
        {
            OrdenDeMantenimiento DetallesDelAOrden;
            try
            {
                
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoEnProceso/DetallesDeOrdenesEnProceso/" + id.ToString());
                string apiResponse = await response.Content.ReadAsStringAsync();
                DetallesDelAOrden = JsonConvert.DeserializeObject<OrdenDeMantenimiento>(apiResponse);
            }
            catch (Exception e)
            {
                throw e;
            }

            ViewData["Articulo"] = DetallesDelAOrden.articulos;
            ViewData["Mantenimiento"] = DetallesDelAOrden.mantenimientos;
   

            return View(DetallesDelAOrden);

        }

        
    }
}