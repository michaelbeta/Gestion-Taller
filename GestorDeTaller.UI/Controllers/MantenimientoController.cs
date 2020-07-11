using GestorDeTaller.BL;
using GestorDeTaller.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestorDeTaller.UI.Controllers
{
    public class MantenimientoController : Controller
    {

        private readonly IRepositorioDeTaller Repositorio;

        public MantenimientoController()
        {
           
        }
        // GET: Mantenimiento
        public async Task<IActionResult> ListarMantenimientosAsociados(int id)
        {
            List<Mantenimiento> laLista;
            TempData["IdArticulo"] = id;
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44343/api/Mantenimiento/" + id.ToString());

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<Mantenimiento>>(apiResponse);
            }
            catch (Exception)
            {

                throw;
            }

            return View(laLista);
        }



        // GET: Mantenimiento/Details/5
        public ActionResult DetallesDeMantenimiento(int id)
        {
            Mantenimiento detalleDeMantenimiento;
            detalleDeMantenimiento = Repositorio.ObteneCatalogoDeMantenimeintosPorId(id);
            List<Repuesto> laLista;
            laLista = Repositorio.ObtenerRepuestosAsociadosAlMantenimiento(id);
            ViewData["Repuesto"] = laLista;

            return View(detalleDeMantenimiento);
        }

        // GET: Mantenimiento/Create
        public ActionResult CrearMantenimiento(int IdArticulo)
        {
            ViewBag.IdArticulo = IdArticulo;
            return View();
        }

        // POST: Mantenimiento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearMantenimiento(Mantenimiento mantenimiento)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    int idArticulo = int.Parse(TempData["IdArticulo"].ToString());
                    mantenimiento.Id_Articulo = idArticulo;
                    var httpClient = new HttpClient();

                    string json = JsonConvert.SerializeObject(mantenimiento);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                    var byteContent = new ByteArrayContent(buffer);

                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    await httpClient.PostAsync("https://localhost:44343/api/Mantenimiento", byteContent);


                    return RedirectToAction("ListarMantenimientosAsociados", new { id = idArticulo });


                }
                else
                {
                    return View(mantenimiento);
                }

            }
            catch (Exception)
            {

                return View();
            }
        }

        // GET: Mantenimiento/Edit/5
        public ActionResult EditarMantenimiento(int id)
        {
            Mantenimiento ListarMantenimientoAeditar;
            ListarMantenimientoAeditar = Repositorio.ObteneCatalogoDeMantenimeintosPorId(id);

            return View(ListarMantenimientoAeditar);
        }

        // POST: Mantenimiento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMantenimiento(Mantenimiento Mantenimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.EditarCatalogoDeMantenimiento(Mantenimiento);
                    int idArticulo = int.Parse(TempData["IdArticulo"].ToString());

                    return RedirectToAction("ListarMantenimientosAsociados", new { id = idArticulo });
                }
                else
                {
                    return View(Mantenimiento);
                }
            }
            catch (Exception)
            {

                return View(Mantenimiento);
            }
        }


        // GET: Mantenimiento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mantenimiento/Delete/5
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