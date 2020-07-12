using System;
using System.Collections.Generic;
using System.Linq;
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

namespace GestorDeTaller.UI.Controllers
{
    [Authorize]
    public class RepuestosParaMantenimientoController : Controller
    {
        private readonly IRepositorioDeTaller Repositorio;

        public RepuestosParaMantenimientoController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }


        public ActionResult Asociar_Repuesto(int id)
        {

            List<Repuesto> laLista;
            laLista = Repositorio.ObtenerCatalogoRepuestos();
            TempData["IdMantenimiento"] = id;
            ViewBag.laLista = laLista;

            return View();

        }

        [HttpPost]
        public ActionResult Asociar_Repuesto(String repuesto)
        {
            int idRepuesto = Int32.Parse(repuesto);
            int idMantenimiento = int.Parse(TempData["IdMantenimiento"].ToString());
            Repositorio.AgregarARepuestosParaMantenimiento(idRepuesto, idMantenimiento);

            return RedirectToAction("ListarRepuestosAsociadosAMantenimiento", "Repuestos", new { id = idMantenimiento });
        }


        public ActionResult ConfirmarRepuestoAdesasociar(int id)
        {
            Repuesto repuestoAdesasociar;
            repuestoAdesasociar = Repositorio.ObtenerRepuestoAdesasociar(id);

            return View(repuestoAdesasociar);
        }


        public ActionResult DesasociarRepuesto(int id)
        {
            Repositorio.DesasociarRepuesto(id);
            int idMantenimiento = int.Parse(TempData["IdMantenimiento"].ToString());

            return RedirectToAction("ListarRepuestosAsociadosAMantenimiento", "Repuestos", new { id = idMantenimiento });
        }



    }
}