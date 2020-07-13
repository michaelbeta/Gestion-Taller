using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorDeTaller.BL;
using GestorDeTaller.Model;
using GestorDeTaller.UI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionDeTaller.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesDeMantenimientoEnProcesoController : ControllerBase
    {
        private readonly IRepositorioDeTaller Repositorio;
        public OrdenesDeMantenimientoEnProcesoController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        // GET: api/<OrdenesDeMantenimientoEnProcesoController>
        [HttpGet]
        public IEnumerable<OrdenDeMantenimiento> Get()
        {
            List<OrdenDeMantenimiento> laLista;
            laLista = Repositorio.ListarOrdenesDeMantenimentoEnProceso();
            return laLista;
        }
        [HttpGet("{id}")]
        public IEnumerable<Mantenimiento> Get(int id)
        {
            List<Mantenimiento> laLista;
            laLista = Repositorio.ObtenerMantenimiento();
            return laLista;
        }
        // GET api/<OrdenesDeMantenimientoEnProcesoController>/5
        [HttpGet("{accion}/{id}")]
        public ActionResult<OrdenDeMantenimiento> Get(string accion, int id)
        {
            if (accion.Equals("TerminarOrdenMantenimiento"))
            {
                Repositorio.TerminarMantenimiento(id);
                return Ok();
            }
            if (accion.Equals("DetallesDeOrdenesEnProceso"))
            {
                OrdenDeMantenimiento DetallesDelAOrden;
                DetallesDelAOrden = Repositorio.ObtenerOrdenesDeMantenimentoCanceladasPorid(id);

                List<Articulo> articuloAsociado;
                articuloAsociado = Repositorio.ObtenerArticuloAsociadosALaOrdenEnMantenimiento(id);
                DetallesDelAOrden.articulos = articuloAsociado;
                List<Mantenimiento> MantenimientoAsosiado;
                MantenimientoAsosiado = Repositorio.ObtenermantenimientoAsociadosalaOrden(id);
                DetallesDelAOrden.mantenimientos = MantenimientoAsosiado;
                return DetallesDelAOrden;
            }
            else
            {
                return null;
            }
        }

        // POST api/<OrdenesDeMantenimientoEnProcesoController>
        [HttpPost]
        public IActionResult Post([FromBody] MotivoDeCancelacion motivoCancelacion)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    Repositorio.CancelarMantenimiento(motivoCancelacion.Id, motivoCancelacion.motivoDeCancelacion);


                }


            }
            catch (Exception ex)
            {

                return NotFound();
            }
            return Ok(motivoCancelacion);

        }

        [HttpGet("{accion}/{idMantenimiento}/{idOrdenDeMantenimiento}")]
        public IActionResult Get(string accion, int idMantenimiento, int idOrdenDeMantenimiento)
        {
            if (accion.Equals("AgregarMantenimiento"))
            {


                Repositorio.AgregarDetallesOrdenesDeMantenimiento(idMantenimiento, idOrdenDeMantenimiento);
                return Ok();
            }
            else
            {
                return null;
            }
        }
        // PUT api/<OrdenesDeMantenimientoEnProcesoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdenesDeMantenimientoEnProcesoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
