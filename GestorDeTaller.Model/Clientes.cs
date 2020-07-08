using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestorDeTaller.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(25)]
        public String Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Nombre")]
        [MaxLength(25)]
        public String Apellidos { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Marca")]
        [MaxLength(30)]
        public String Email { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name = "Descripcion")]
        [MaxLength(150)]
        public String Dirrecion { get; set; }

    }
}
