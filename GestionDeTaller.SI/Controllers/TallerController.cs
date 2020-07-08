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
    public class TallerController : ControllerBase
    {
        private readonly IRepositorioDeTaller Repositorio;

        public TallerController(IRepositorioDeTaller repositorio)
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TallerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
