using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestorDeTaller.Model
{
    public class Mantenimiento
    {
      
            public int Id { get; set; }
            public int Id_Articulo { get; set; }
            [Required(ErrorMessage = "Este campo es requerido")]
            [Display(Name = "Descripcion")]
            [MaxLength(120)]
            public String Descripcion { get; set; }
            [Required(ErrorMessage = "Este campo es requerido")]
            [Display(Name = "Costo Fijo")]
          
            [Range(0, double.MaxValue)]
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
       
}

    
}
