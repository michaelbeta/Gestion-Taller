using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTaller.Model
{
    public class DetalleOrdenesDeMantenimiento
    {
        public int Id { get; set; }
        public int Id_OrdenesDeMantenimiento { get; set; }
        public int Id_Mantenimiento { get; set; }
       
    }
    

}
