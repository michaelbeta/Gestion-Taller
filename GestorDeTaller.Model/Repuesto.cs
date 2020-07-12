using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeTaller.Model
{
    public class Repuesto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(25)]
        public String Nombre { get; set; }
        public int Id_Articulo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números ")]
        [Range(1, 999999999, ErrorMessage = "El Precio debe ser mayor a 0 y menor 999999999 ")]

        public Double Precio { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Descripción")]
        [MaxLength(250)]
        public String Descripcion { get; set; }
        [NotMapped]
        public int CantidadDeOrdenesTerminadas { get; set; }
        [NotMapped]
        public int CantidadDeOrdenesEnProceso { get; set; }
        [NotMapped]
        public List<Articulo> articuloAsociado { get; set; }
        [NotMapped]
        public List<Mantenimiento> MantenimientoAsosiado { get; set; }


    }
}
