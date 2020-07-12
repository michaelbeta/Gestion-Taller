using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using GestorDeTaller.BL;
using GestorDeTaller.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionDeTaller.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoDeArticulosController : ControllerBase
    {
        private readonly IRepositorioDeTaller Repositorio;

        //public object ViewBag { get; private set; }
        //public object ViewData { get; private set; }
        public dynamic ViewBag { get; }
        public dynamic ViewData { get; }

        public CatalogoDeArticulosController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        // GET: api/<TallerController>
        [HttpGet]
        public IEnumerable<Articulo> Get()
        {
            List<Articulo> laLista;
            laLista = Repositorio.ObtenerArticulo();

            return laLista;
        }


        // GET api/<TallerController>/5
        [HttpGet("{id}")]
        public ActionResult<Articulo> GetEditar(int id)
        {
            Articulo articulo;
            articulo = Repositorio.ObtenerPorId(id);

            return (articulo);

        }
        [HttpGet("{accion}/{id}")]
        public ActionResult<Articulo> Get(string accion, int id)
        {
            try
            {
                if (accion.Equals("Detalles"))
                {
                    Articulo detalleDeLArticulo;
                    detalleDeLArticulo = Repositorio.ObtenerPorId(id);

                    List<Repuesto> repuestoasociado;
                    repuestoasociado = Repositorio.ObtenerRepuestoAsociadosAlArticulo(id);
                    detalleDeLArticulo.repuestoasociado = repuestoasociado;

                    List<OrdenDeMantenimiento> ordenesDeMantenimientosEnProceso;
                    ordenesDeMantenimientosEnProceso = Repositorio.ListarOrdenesDeMantenimientoEnProceso();
                    detalleDeLArticulo.CantidadDeOrdenesEnProceso = ordenesDeMantenimientosEnProceso.Count();

                    List<OrdenDeMantenimiento> ordenesDeMantenimientosTerminadas;
                    ordenesDeMantenimientosTerminadas = Repositorio.ListarOrdenesDeMantenimientoTerminadas();
                    detalleDeLArticulo.CantidadDeOrdenesTerminadas = ordenesDeMantenimientosTerminadas.Count();

                    return detalleDeLArticulo;
                }
                else 
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        // POST api/<TallerController>
        [HttpPost]
        public IActionResult Post([FromBody] Articulo articulo)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    Repositorio.AgregarArticulo(articulo);


                }


            }
            catch (Exception ex)
            {

                return NotFound();
            }
            return Ok(articulo);
        }

        // PUT api/<TallerController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Articulo articulo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.EditarArticulo(articulo);
                }
            }
            catch
            {

            }
            return Ok(articulo);
        }

      
    }
}
