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
        public IActionResult Get(int id)
        {
            Articulo detalleDeLArticulo;
            detalleDeLArticulo = Repositorio.ObtenerPorId(id);
            List<Repuesto> repuestoasociado;
            repuestoasociado = Repositorio.ObtenerRepuestoAsociadosAlArticulo(id);

            ViewData["Repuesto"] = repuestoasociado;

            List<OrdenDeMantenimiento> ordenesDeMantenimientosEnProceso;
            ordenesDeMantenimientosEnProceso = Repositorio.ListarOrdenesDeMantenimientoEnProceso();
            int CantidadDeOrdenesEnProceso = ordenesDeMantenimientosEnProceso.Count();

            ViewBag.OrdenesEnProceso = CantidadDeOrdenesEnProceso;

            List<OrdenDeMantenimiento> ordenesDeMantenimientosTerminadas;
            ordenesDeMantenimientosTerminadas = Repositorio.ListarOrdenesDeMantenimientoTerminadas();
            int CantidadDeOrdenesTerminadas = ordenesDeMantenimientosTerminadas.Count();

            ViewBag.OrdenesTerminadas = CantidadDeOrdenesTerminadas;

            if (detalleDeLArticulo==null)
            {
                return NotFound();
            }
            return Ok(detalleDeLArticulo);
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TallerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
