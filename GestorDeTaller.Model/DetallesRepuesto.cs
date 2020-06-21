using GestorDeTaller.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestorDeTaller.Model

{

    public class DetallesRepuesto
    {
        [NotMapped]
        public int Cantidad { get; set; }
        [NotMapped]
        public Repuesto repuesto { get; set; }
        [NotMapped]
        public Articulo articulo { get; set; }
        public List<Mantenimiento> Lista { get; set; }
    }
}