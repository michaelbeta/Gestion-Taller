using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestorDeTaller.Model
{
   public class Repuesto
    {
            [Key]
            public int Id { get; set; }
            public String Nombre { get; set; }
            public int Id_Articulo { get; set; }
            public Double Precio { get; set; }
            public String Descripcion { get; set; }
            [NotMapped]
            public int CantidadDeOrdenesTerminadas { get; set; }
            [NotMapped]
            public int CantidadDeOrdenesEnProceso { get; set; }
       
    }
}
