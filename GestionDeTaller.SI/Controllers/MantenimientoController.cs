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
    public class MantenimientoController : ControllerBase
    {
        private readonly IRepositorioDeTaller Repositorio;
        public MantenimientoController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        // GET: api/<MantenimientoController>
        [HttpGet("{id}")]
        public IEnumerable<Mantenimiento> Get(int id)
        {
            List<Mantenimiento> laLista;
            laLista = Repositorio.ObtenerCatalogoDeMantenimeintos(id);
            return laLista;
        }

        // GET api/<MantenimientoController>/5
        [HttpGet("{accion}/{id}")]
        public string Get(string accion, int id)
        {
            return "value";
        }

        // POST api/<MantenimientoController>
        [HttpPost]
        public IActionResult Post([FromBody] Mantenimiento mantenimiento)
        {
            try
            {


                if (ModelState.IsValid)
                {

                    Repositorio.AgregarMantenimiento(mantenimiento, mantenimiento.Id_Articulo);


                }


            }
            catch (Exception ex)
            {

                return NotFound();
            }
            return Ok(mantenimiento);
        }

        // PUT api/<MantenimientoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MantenimientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
