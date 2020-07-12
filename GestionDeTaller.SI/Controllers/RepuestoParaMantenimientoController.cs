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
    public class RepuestoParaMantenimientoController : ControllerBase
    {
        private readonly IRepositorioDeTaller Repositorio;
        public RepuestoParaMantenimientoController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        // GET: api/<RepuestoParaMantenimientoController>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Repuesto repuestoAdesasociar;
            repuestoAdesasociar = Repositorio.ObtenerRepuestoAdesasociar(id);

            Repositorio.DesasociarRepuesto(id);
            return Ok(repuestoAdesasociar);
        }

        [HttpGet("{accion}/{id}")]
        public IEnumerable<Repuesto> Get(string accion, int id)
        {
            if (accion.Equals("ListarRepuestosAsociadosAMantenimiento"))
            {

                List<Repuesto> repuestoasociado;
                repuestoasociado = Repositorio.ObtenerRepuestosAsociadosAlMantenimiento(id);
                return repuestoasociado;
            }
            if (accion.Equals("Asociar_Repuesto"))
            {
                List<Repuesto> laLista;
                laLista = Repositorio.ObtenerCatalogoRepuestos();
                return laLista;
            }
            else
            {
                return null;
            }
        }

        [HttpGet("{accion}/{idRepuesto}/{idMantenimiento}")]
        public IActionResult Get(string accion, int idRepuesto, int idMantenimiento)
        {
            if (accion.Equals("AsociarRepuesto"))
            {

                
                Repositorio.AgregarARepuestosParaMantenimiento(idRepuesto, idMantenimiento);
                return Ok();
            }
            else
            {
                return null;
            }
        }

        // POST api/<RepuestoParaMantenimientoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RepuestoParaMantenimientoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RepuestoParaMantenimientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
