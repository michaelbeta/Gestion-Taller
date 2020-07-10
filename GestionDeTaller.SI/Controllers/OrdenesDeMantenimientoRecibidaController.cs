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
    public class OrdenesDeMantenimientoRecibidaController : ControllerBase
    {
        private readonly IRepositorioDeTaller Repositorio;

       // public object ViewBag { get; private set; }
        public object ViewData { get; private set; }
        public dynamic ViewBag { get; }

        public OrdenesDeMantenimientoRecibidaController(IRepositorioDeTaller repositorio)
        {
            Repositorio = repositorio;
        }
        // GET: api/<OrdenesDeMantenimientoRecibidas>
        [HttpGet]
        public IEnumerable<OrdenDeMantenimiento> Get()
        {
            List<OrdenDeMantenimiento> laLista;
            laLista = Repositorio.ListarOrdenesDeMantenimientoRecibidas();

            return laLista;
        }

        // GET api/<OrdenesDeMantenimientoRecibidas>/5
        [HttpGet("{id}")]
        public ActionResult<OrdenDeMantenimiento> Get(int id)
        {
            OrdenDeMantenimiento ListarOrdenDeMantenimientoAeditar;
            ListarOrdenDeMantenimientoAeditar = Repositorio.ObtenerOrdenDeMantenimientoPorId(id);
            return ListarOrdenDeMantenimientoAeditar;
        }

        // POST api/<OrdenesDeMantenimientoRecibidas>
        [HttpPost]
        public IActionResult Post([FromBody] OrdenDeMantenimiento ordenDeMantenimiento)
        {
            try
            {
                

                if (ModelState.IsValid)
                {

                    Repositorio.AgregarOrdenDeMantenimientoRecibida(ordenDeMantenimiento.Id_Articulo, ordenDeMantenimiento);


                }


            }
            catch (Exception ex)
            {

                return NotFound();
            }
            return Ok(ordenDeMantenimiento);
        }

        // PUT api/<OrdenesDeMantenimientoRecibidas>/5
        [HttpPut]
        public IActionResult Put([FromBody] OrdenDeMantenimiento ordenDeMantenimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.EditaOrdenDeMantenimientoRecibida(ordenDeMantenimiento);
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok(ordenDeMantenimiento);
            
        }

        
        [HttpGet("{iniciar}/{id}")]
        public IActionResult Iniciar(string iniciar, int id)
        {
            if (iniciar.Equals("IniciarOrden"))
            {
                Repositorio.IniciarOrdenDerMantenimiento(id);
                return Ok();
            }
            else 
            {
                return null;
            }
        }
    }
}
