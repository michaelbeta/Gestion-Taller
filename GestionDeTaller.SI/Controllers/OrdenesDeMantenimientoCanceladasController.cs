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
    public class OrdenesDeMantenimientoCanceladasController : ControllerBase
    {
        private readonly IRepositorioDeTaller Repositorio;

        public OrdenesDeMantenimientoCanceladasController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        // GET: api/<OrdenesDeMantenimientoCanceladasController>
        [HttpGet]
        public IEnumerable<OrdenDeMantenimiento> Get()
        {
            List<OrdenDeMantenimiento> laLista;
            laLista = Repositorio.ListarOrdenesDeMantenimentoCanceladas();
            return laLista;
        }

        // GET api/<OrdenesDeMantenimientoCanceladasController>/5
        [HttpGet("{id}")]
        public ActionResult<OrdenDeMantenimiento> Get(int id)
        {
            OrdenDeMantenimiento DetallesDelAOrden;
            try
            {
                
                DetallesDelAOrden = Repositorio.ObtenerOrdenesDeMantenimentoCanceladasPorid(id);

                List<Articulo> articuloAsociado;
                articuloAsociado = Repositorio.ObtenerArticuloAsociadosALaOrdenEnMantenimiento(id);
                DetallesDelAOrden.articulos = articuloAsociado;
                List<Mantenimiento> MantenimientoAsosiado;
                MantenimientoAsosiado = Repositorio.ObtenermantenimientoAsociadosalaOrden(id);
                DetallesDelAOrden.mantenimientos = MantenimientoAsosiado;
            }
            catch (Exception e)
            {
                throw e;
            }
            return DetallesDelAOrden;
        }

        // POST api/<OrdenesDeMantenimientoCanceladasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdenesDeMantenimientoCanceladasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdenesDeMantenimientoCanceladasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
