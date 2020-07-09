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

        public object ViewBag { get; private set; }
        public object ViewData { get; private set; }

        public CatalogoDeArticulosController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        // GET: Lista de articulos
        [HttpGet]
        public IEnumerable<Articulo> Lista_De_Articulos()
        {
            List<Articulo> laLista;
            laLista = Repositorio.ObtenerArticulo();

            return laLista;
        }

        // GET Detalles de articulos
        [HttpGet("{id}")]
        public IActionResult Detalles_De_Articulo(int id)
        {

            Articulo detalleDeLArticulo;
            detalleDeLArticulo = Repositorio.ObtenerPorId(id);
            List<Repuesto> repuestoasociado;
            repuestoasociado = Repositorio.ObtenerRepuestoAsociadosAlArticulo(id);

            List<OrdenDeMantenimiento> ordenesDeMantenimientosEnProceso;
            ordenesDeMantenimientosEnProceso = Repositorio.ListarOrdenesDeMantenimientoEnProceso();
           

            List<OrdenDeMantenimiento> ordenesDeMantenimientosTerminadas;
            ordenesDeMantenimientosTerminadas = Repositorio.ListarOrdenesDeMantenimientoTerminadas();
          

            if (detalleDeLArticulo==null)
            {
                return NotFound();
            }
            return Ok(detalleDeLArticulo);
        }

        // POST Agregar articulo
        [HttpPost]
        public IActionResult AgregarArticulo([FromBody] Articulo articulo)
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
