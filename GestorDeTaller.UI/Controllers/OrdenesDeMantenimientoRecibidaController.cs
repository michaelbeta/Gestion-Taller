using GestorDeTaller.BL;
using GestorDeTaller.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GestorDeTaller.UI.Controllers
{
    public class OrdenesDeMantenimientoRecibidaController : Controller
    {
        private readonly IRepositorioDeTaller Repositorio;

        public OrdenesDeMantenimientoRecibidaController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        // GET: OrdenesDeMantenimientoRecibidatroller
        public ActionResult ListarOrdenesDeMantenimientoRecibidas()
        {
            List<OrdenDeMantenimiento> laLista;
            laLista = Repositorio.ListarOrdenesDeMantenimientoRecibidas();

            return View(laLista);
        }


        public ActionResult DetallesDeOrdenRecibida(int id)
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
        public ActionResult AgregarOrdenDeMantenimientoRecibidas()
        {
            List<Articulo> laLista;
            laLista = Repositorio.ObtenerArticulo();
            ViewBag.laLista = laLista;

            return View();

        }
        public ActionResult AgregarMantenimientoAOrdenRecibidas(Mantenimiento idMantenimiento)
        {

            int idOrdenDeMantenimiento = int.Parse(TempData["IdArticulo"].ToString());


            Repositorio.AgregarMantenimientoAOrdenRecibidas(idOrdenDeMantenimiento, idMantenimiento.Id);

            return RedirectToAction(nameof(ListarOrdenesDeMantenimientoRecibidas));



        }
        public ActionResult ListarMantenimientosDisponiblesParaArticulo(int id)
        {
            List<Mantenimiento> laLista;
            laLista = Repositorio.ObtenerCatalogoDeMantenimeintos(id);
            TempData["IdArticulo"] = id;

            return View(laLista);
        }

        // POST: OrdenesDeMantenimientoRecibidatroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarOrdenDeMantenimientoRecibidas(string Articulo, OrdenDeMantenimiento ordenDeMantenimiento)
        {

            int idArticulo = int.Parse(Articulo);

            try
            {

                if (ModelState.IsValid)
                {

                    Repositorio.AgregarOrdenDeMantenimientoRecibida(idArticulo, ordenDeMantenimiento);

                    return RedirectToAction(nameof(ListarOrdenesDeMantenimientoRecibidas));


                }
                else
                {
                    return View(ordenDeMantenimiento);
                }

            }
            catch (Exception)
            {

                return View();
            }
        }
        // GET: OrdenesDeMantenimientoRecibidatroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenesDeMantenimientoRecibidatroller/Create
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

        // GET: OrdenesDeMantenimientoRecibidatroller/Edit/5
        public ActionResult EditarOrden(int id)
        {
            OrdenDeMantenimiento ListarOrdenDeMantenimientoAeditar;
            ListarOrdenDeMantenimientoAeditar = Repositorio.ObtenerOrdenDeMantenimientoPorId(id);

            return View(ListarOrdenDeMantenimientoAeditar);
        }

        // POST: OrdenesDeMantenimientoRecibidatroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarOrden(OrdenDeMantenimiento ordenDeMantenimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.EditaOrdenDeMantenimientoRecibida(ordenDeMantenimiento);

                    return RedirectToAction(nameof(ListarOrdenesDeMantenimientoRecibidas));
                }
                else
                {
                    return View(ordenDeMantenimiento);
                }
            }
            catch (Exception)
            {

                return View(ordenDeMantenimiento);
            }
        }
        public ActionResult IniciarOrdenMantenimiento(int id)
        {
            Repositorio.IniciarOrdenDerMantenimiento(id);

            return RedirectToAction(nameof(ListarOrdenesDeMantenimientoRecibidas));
        }
        // GET: OrdenesDeMantenimientoRecibidatroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrdenesDeMantenimientoRecibidatroller/Delete/5
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