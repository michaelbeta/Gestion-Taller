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
    public class OrdenesDeMantenimientoRecibidaController : Controller
    {
        private readonly IRepositorioDeTaller Repositorio;

        public OrdenesDeMantenimientoRecibidaController()
        {
           
        }
       
        public async Task<IActionResult> ListarOrdenesDeMantenimientoRecibidas()
        {
            List<OrdenDeMantenimiento> laLista = new List<OrdenDeMantenimiento>();
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoRecibida");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<OrdenDeMantenimiento>>(apiResponse);
            }
            catch (Exception)
            {

                throw;
            }
            return View(laLista);
        }


        public async Task<IActionResult> DetallesDeOrdenRecibida(int id)
        {
            OrdenDeMantenimiento ordenDeMantenimiento;
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoRecibida/Detalles/" + id.ToString());
                string apiResponse = await response.Content.ReadAsStringAsync();
                ordenDeMantenimiento = JsonConvert.DeserializeObject<OrdenDeMantenimiento>(apiResponse);
            }
            catch (Exception e)
            {
                throw e;
            }
           
            ViewData["Articulo"] = ordenDeMantenimiento.articulos;
            ViewData["Mantenimiento"] = ordenDeMantenimiento.mantenimientos;
            return View(ordenDeMantenimiento);
        }
       
       
        public async Task<IActionResult> ListarMantenimientosDisponiblesParaArticulo(int id)
        {
            List<Mantenimiento> laLista;
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
            
            TempData["IdArticulo"] = id;

            return View(laLista);
        }
        public async Task<IActionResult> AgregarMantenimientoAOrdenRecibidas(OrdenDeMantenimiento ordenDeMantenimiento, Mantenimiento mantenimiento)
        {
            
            ordenDeMantenimiento.Id = int.Parse(TempData["IdArticulo"].ToString());
           
            try
            {
               
                    var httpClient = new HttpClient();

                    var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoRecibida/AgregarMantenimientoAOrdenRecibidas/" + ordenDeMantenimiento.Id  +"/"+ mantenimiento.Id);

                    string apiResponse = await response.Content.ReadAsStringAsync();


            }
            catch (Exception)
            {

                return View();
            }

            return RedirectToAction(nameof(ListarOrdenesDeMantenimientoRecibidas));





        }
       
        public async Task<IActionResult> AgregarOrdenDeMantenimientoRecibidas()
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
            ViewBag.laLista = laLista;
            return View();

           

        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarOrdenDeMantenimientoRecibidas(string Articulo, OrdenDeMantenimiento ordenDeMantenimiento)
        {
            int idArticulo = int.Parse(Articulo);
            ordenDeMantenimiento.Id_Articulo = idArticulo;
            try
            {
                if (ModelState.IsValid)
                {
                    var httpClient = new HttpClient();

                    string json = JsonConvert.SerializeObject(ordenDeMantenimiento);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                    var byteContent = new ByteArrayContent(buffer);

                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    await httpClient.PostAsync("https://localhost:44343/api/OrdenesDeMantenimientoRecibida", byteContent);

                    
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
            return RedirectToAction(nameof(ListarOrdenesDeMantenimientoRecibidas));
        }

        // GET: OrdenesDeMantenimientoRecibidatroller/Edit/5
        public async Task<ActionResult> EditarOrden(int id)
        {
            OrdenDeMantenimiento ordenDeMantenimiento;
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoRecibida/" + id.ToString());
                string apiResponse = await response.Content.ReadAsStringAsync();
                ordenDeMantenimiento = JsonConvert.DeserializeObject<OrdenDeMantenimiento>(apiResponse);
            }
            catch (Exception e)
            {
                throw e;
            }
            return View(ordenDeMantenimiento);
        }

        // POST: OrdenesDeMantenimientoRecibidatroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditarOrden(OrdenDeMantenimiento ordenDeMantenimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var httpClient = new HttpClient();

                    string json = JsonConvert.SerializeObject(ordenDeMantenimiento);

                    var buffer = System.Text.Encoding.UTF8.GetBytes(json);

                    var byteContent = new ByteArrayContent(buffer);

                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                    await httpClient.PutAsync("https://localhost:44343/api/OrdenesDeMantenimientoRecibida", byteContent);

                    return RedirectToAction(nameof(ListarOrdenesDeMantenimientoRecibidas));
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
        public async Task<ActionResult> IniciarOrdenMantenimiento(int id)
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoRecibida/IniciarOrden/" + id.ToString());
                string apiResponse = await response.Content.ReadAsStringAsync();
                
            }
            catch (Exception e)
            {
                throw e;
            }
            
            //Repositorio.IniciarOrdenDerMantenimiento(id);

            return RedirectToAction(nameof(ListarOrdenesDeMantenimientoRecibidas));
        }
       
       
    }
}