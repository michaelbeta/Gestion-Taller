using System;
using System.ComponentModel.DataAnnotations;

namespace GestorDeTaller.Model
{
    public class MotivoDeCancelacion
    {
        [Display(Name = "Motivo de cancelación")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Debe digitar el motivo de cancelación")]
        public String motivoDeCancelacion { get; set; }
        public int Id { get; set; }
    }
}
