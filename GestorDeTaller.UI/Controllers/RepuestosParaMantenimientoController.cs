using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GestorDeTaller.BL;
using GestorDeTaller.DA;
using GestorDeTaller.Model;
using GestorDeTaller.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace GestorDeTaller.UI.Controllers
{
    public class RepuestosParaMantenimientoController : Controller
    {
        private readonly IRepositorioDeTaller Repositorio;

        public RepuestosParaMantenimientoController()
        {
           
        }


        public async Task<IActionResult> Asociar_Repuesto(int id)
        {

            List<Repuesto> laLista = new List<Repuesto>();
            TempData["IdMantenimiento"] = id;
            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44343/api/RepuestoParaMantenimiento/Asociar_Repuesto/" + id.ToString());

                string apiResponse = await response.Content.ReadAsStringAsync();

                laLista = JsonConvert.DeserializeObject<List<Repuesto>>(apiResponse); 
            }
            catch (Exception)
            {

                throw;
            }
           
            ViewBag.laLista = laLista;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Asociar_Repuesto(String repuesto)
        {
            int idRepuesto = Int32.Parse(repuesto);
            int idMantenimiento = int.Parse(TempData["IdMantenimiento"].ToString());
           
            try
            {

                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44343/api/RepuestoParaMantenimiento/AsociarRepuesto/" + idRepuesto + "/" + idMantenimiento);

                string apiResponse = await response.Content.ReadAsStringAsync();


            }
            catch (Exception)
            {

                return View();
            }
            return RedirectToAction("ListarRepuestosAsociadosAMantenimiento", "Repuestos", new { id = idMantenimiento });
        }


   /*    public ActionResult ConfirmarRepuestoAdesasociar(int id)
        {
            Repuesto repuestoAdesasociar;
            repuestoAdesasociar = Repositorio.ObtenerRepuestoAdesasociar(id);

            return View(repuestoAdesasociar);
        } */


        public async Task<IActionResult> DesasociarRepuesto(int id)
        {
            
            int idMantenimiento = int.Parse(TempData["IdMantenimiento"].ToString());
            try
            {

                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync("https://localhost:44343/api/RepuestoParaMantenimiento/AsociarRepuesto/" + id.ToString());

                string apiResponse = await response.Content.ReadAsStringAsync();


            }
            catch (Exception)
            {

                return View();
            }
            return RedirectToAction("ListarRepuestosAsociadosAMantenimiento", "Repuestos", new { id = idMantenimiento });
        }



    }
}