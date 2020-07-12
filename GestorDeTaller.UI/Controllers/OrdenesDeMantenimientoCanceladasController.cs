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

                var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoCanceladas");

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<OrdenDeMantenimiento>>(apiResponse);
            }
            catch (Exception)
            {

                throw;
            }
            return View(laLista);

        }


        public async Task<IActionResult> DetallesDeLaOrden(int id)
        {
            OrdenDeMantenimiento DetallesDelAOrden;
            try
            {

                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://localhost:44343/api/OrdenesDeMantenimientoCanceladas/" + id.ToString());
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