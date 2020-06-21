using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestorDeTaller.Model
{
    public class Articulo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Este campo es requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(25)]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Marca")]
        [MaxLength(25)]
        public String Marca { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Descripcion")]
        [MaxLength(150)]
        public String Descripcion { get; set; }

        public string NombreMarca
        {
            get
            {
                return string.Format("{0} {1}", Nombre, Marca);
            }
        }
    }
}
