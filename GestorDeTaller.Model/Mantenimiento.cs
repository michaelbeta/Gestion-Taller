using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeTaller.Model
{
    public class Mantenimiento
    {

        public int Id { get; set; }
        public int Id_Articulo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Descripción")]
        [MaxLength(120)]
        public String Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Costo Fijo")]

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números ")]
        [Range(0, 999999999, ErrorMessage = "El Costo Fijo debe ser mayor o igual a 0 y menor 999999999 ")]
        public Double CostoFijo { get; set; }
        [NotMapped, Display(Name = "Costo total de repuestos")]
        public double CostoDeRepuestos { get; set; }
        public string DescripCosto
        {
            get
            {
                return string.Format("{0} {1}", Descripcion, CostoFijo);
            }
        }
        [NotMapped]
        public List<Repuesto> repuestos { get; set; }
    }


}
