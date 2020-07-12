using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorDeTaller.BL;
using GestorDeTaller.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionDeTaller.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesDeMantenimientoTerminadasController : ControllerBase
    {
        private readonly IRepositorioDeTaller Repositorio;
        public OrdenesDeMantenimientoTerminadasController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        // GET: api/<OrdenesDeMantenimientoTerminadasController>
        [HttpGet]
        public IEnumerable<OrdenDeMantenimiento> Get()
        {
            List<OrdenDeMantenimiento> laLista;
            laLista = Repositorio.ListarOrdenesDeMantenimientoTerminadas();

            return laLista;
        }

        // GET api/<OrdenesDeMantenimientoTerminadasController>/5
        [HttpGet("{id}")]
        public ActionResult<OrdenDeMantenimiento> Get(int id)
        {
            try
            {
                OrdenDeMantenimiento DetallesDelAOrden;
                DetallesDelAOrden = Repositorio.ObtenerOrdenesDeMantenimentoTerminadasPorid(id);

                List<Articulo> articuloAsociado;
                articuloAsociado = Repositorio.ObtenerArticuloAsociadosALaOrdenEnMantenimiento(id);
                DetallesDelAOrden.articulos = articuloAsociado;

                List<Mantenimiento> MantenimientoAsosiado;
                MantenimientoAsosiado = Repositorio.ObtenermantenimientoAsociadosalaOrden(id);
                DetallesDelAOrden.mantenimientos = MantenimientoAsosiado;

                return DetallesDelAOrden;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // POST api/<OrdenesDeMantenimientoTerminadasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdenesDeMantenimientoTerminadasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdenesDeMantenimientoTerminadasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
