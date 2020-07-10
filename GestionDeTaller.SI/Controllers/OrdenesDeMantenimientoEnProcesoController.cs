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

        // GET api/<OrdenesDeMantenimientoEnProcesoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdenesDeMantenimientoEnProcesoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
