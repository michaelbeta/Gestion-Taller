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
    public class OrdenesDeMantenimientoTerminadaController : Controller
    {
        private readonly IRepositorioDeTaller Repositorio;

        public OrdenesDeMantenimientoTerminadaController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        public ActionResult ListarOrdenesDeMantenimientoTerminadas()
        {
            List<OrdenDeMantenimiento> laLista;
            laLista = Repositorio.ListarOrdenesDeMantenimientoTerminadas();

            return View(laLista);
        }

        public ActionResult DetallesDeOrdenesDeMantenimientoTerminadas(int id)
        {
            OrdenDeMantenimiento DetallesDelAOrden;
            DetallesDelAOrden = Repositorio.ObtenerOrdenesDeMantenimentoTerminadasPorid(id);

            List<Articulo> articuloAsociado;
            articuloAsociado = Repositorio.ObtenerArticuloAsociadosALaOrdenEnMantenimiento(id);

            List<Mantenimiento> MantenimientoAsosiado;
            MantenimientoAsosiado = Repositorio.ObtenermantenimientoAsociadosalaOrden(id);

            ViewData["Articulo"] = articuloAsociado;
            ViewData["Mantenimiento"] = MantenimientoAsosiado;

            return View(DetallesDelAOrden);
        }
    }
}