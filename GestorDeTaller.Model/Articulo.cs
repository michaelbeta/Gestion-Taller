using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestorDeTaller.Model
{
    public class Articulo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(25)]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Marca")]
        [MaxLength(25)]
        public String Marca { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Descripción")]
        [MaxLength(150)]
        public String Descripcion { get; set; }

        public string NombreMarca
        {
            get
            {
                return string.Format("{0} {1}", Nombre, Marca);
            }
        }
        [NotMapped]
       public List<Repuesto> repuestoasociado { get; set; }
        [NotMapped]
        public List<OrdenDeMantenimiento> ordenesDeMantenimientosEnProceso { get; set; }
        [NotMapped]
        public List<OrdenDeMantenimiento> ordenesDeMantenimientosterminada { get; set; }
        [NotMapped]
        public int CantidadDeOrdenesEnProceso { get; set; }
        [NotMapped]
        public int CantidadDeOrdenesTerminadas { get; set; }
    }
}
