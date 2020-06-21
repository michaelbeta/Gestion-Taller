using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeTaller.UI.Models
{
    public class MotivoDeCancelacion
    {
        [Display(Name = "Motivo de cancelacion")]
        [MaxLength(50)]
        [Required]
        public String motivoDeCancelacion { get; set; }
        public int Id { get; set; }
    }
}
