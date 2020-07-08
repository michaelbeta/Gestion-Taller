using GestorDeTaller.BL;
using GestorDeTaller.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GestorDeTaller.UI.Controllers
{
    public class MantenimientoController : Controller
    {

        private readonly IRepositorioDeTaller Repositorio;

        public MantenimientoController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        // GET: Mantenimiento
        public ActionResult ListarMantenimientosAsociados(int id)
        {
            List<Mantenimiento> laLista;
            laLista = Repositorio.ObtenerCatalogoDeMantenimeintos(id);
            TempData["IdArticulo"] = id;

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
        public ActionResult CrearMantenimiento(Mantenimiento mantenimiento)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    int idArticulo = int.Parse(TempData["IdArticulo"].ToString());
                    Repositorio.AgregarMantenimiento(mantenimiento, idArticulo);

                    return RedirectToAction("ListarCatalogoDeArticulos", "CatalogoDeArticulos");


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

                    return RedirectToAction(nameof(ListarMantenimientosAsociados));
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