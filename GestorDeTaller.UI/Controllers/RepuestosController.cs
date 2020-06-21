using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorDeTaller.BL;
using GestorDeTaller.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTaller.UI.Controllers
{
    public class RepuestosController : Controller
    {

        private readonly IRepositorioDeTaller Repositorio;

        public RepuestosController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        
        public ActionResult ListarRepuestosAsociados(int id)
        {
            List<Repuesto> repuestoasociado;
            repuestoasociado = Repositorio.ObtenerRepuestoAsociadosAlArticulo(id);
            TempData["IdArticulo"]=id;

            return View(repuestoasociado);
        }
        public ActionResult ListarRepuestosAsociadosAMantenimiento(int id)
        {
            List<Repuesto> repuestoasociado;
            repuestoasociado = Repositorio.ObtenerRepuestosAsociadosAlMantenimiento(id);
            TempData["IdArticulo"] = id;
            ViewBag.Id = id;
            return View(repuestoasociado);
        }

        // GET: Repuestos/Details/5
        public ActionResult DetalleDeRepuesto(int id)
        {
           
            Repuesto repuesto;
            repuesto = Repositorio.ObtenerRepuestoAdesasociar(id);

            List<Articulo> articuloAsociado;
            articuloAsociado = Repositorio.ObtenerArticuloAsociadosAlRepuesto(id);

            List<Mantenimiento> MantenimientoAsosiado;
            MantenimientoAsosiado = Repositorio.ObtenerMantenimientoAsociadoAlRepuesto(id);

            ViewData["Articulo"] = articuloAsociado;
            ViewData["Mantenimiento"] = MantenimientoAsosiado;

            return View(repuesto);
        }
        public ActionResult CantidadDeRepuestosUtilizados(int id)
        {

            DetallesRepuesto detalleDeRepuesto;
            detalleDeRepuesto = Repositorio.ObtenerDetalleRepuesto(id);

            return View(detalleDeRepuesto);
        }
        public ActionResult ListarMantenimientosAsociadosAlRepuesto(int id)
        {
            List<Mantenimiento> Mantenimientoasociado;
            Mantenimientoasociado = Repositorio.ObtenerMantenimientoAsociadoAlRepuesto(id);
            TempData["IdArticulo"] = id;

            return View(Mantenimientoasociado);
        }
        // GET: Repuestos/Create
        public ActionResult AgregarRepuesto()
        {

            return View();
        }

        // POST: Repuestos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarRepuesto(Repuesto repuesto)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    int idArticulo=int.Parse(TempData["IdArticulo"].ToString());
                    Repositorio.AgregarRepuesto(repuesto,idArticulo);

                    return RedirectToAction("ListarCatalogoDeArticulos", "CatalogoDeArticulos");

                }
                else
                {
                    return View(repuesto);
                }

            }
            catch (Exception)
            {

                return View();
            }
        }

        // GET: Repuestos/Edit/5
       
        public ActionResult EditarRepuesto(int id)
        {
            Repuesto editarRepuesto;
            editarRepuesto = Repositorio.ObtenerRepuestoPorId(id);

           

            return View(editarRepuesto);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarRepuesto(Repuesto repuesto)
        {
          
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.EditarRepuesto(repuesto);

                  
                    return RedirectToAction("ListarRepuestosAsociados");
                }
                else
                {
                    return View(repuesto);
                }
            }
            catch
            {
                return View(repuesto);
            }
        }


        // GET: Repuestos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Repuestos/Delete/5
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