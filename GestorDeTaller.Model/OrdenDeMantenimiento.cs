using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeTaller.Model
{
    public class OrdenDeMantenimiento
    {

        public int Id { get; set; }


        [Display(Name = "Nombre del cliente")]
        [MaxLength(25)]
        [Required(ErrorMessage = "Este campo es requerido")]
        public String NombreDelCliente { get; set; }

        public Estado Estado { get; set; }

        [Display(Name = "Descripción del problema")]
        [MaxLength(120)]
        [Required(ErrorMessage = "Este campo es requerido")]
        public String DescripcionDelProblema { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de ingreso")]
        public DateTime FechaDeIngreso { get; set; }



        [Required(ErrorMessage = "Este campo es requerido")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números ")]
        [Range(0, 999999999, ErrorMessage = "El Costo Fijo debe ser mayor o igual a 0 y menor 999999999 ")]
        [Display(Name = "Monto de adelanto")]
        public Decimal MontoDeAdelanto { get; set; }

        public int Id_Articulo { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de inicio")]

        public DateTime? FechaDeInicio { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de finalización")]
        public DateTime? FechaDeFinalizacion { get; set; }

        [Display(Name = "Motivo de cancelación")]

        public String? MotivoDeCancelacion { get; set; }
        [NotMapped]

        [Display(Name = "Cantidad de días en proceso")]
        public int CantidadDeDiasEnProceso { get; set; }
        [NotMapped]
        public int CantidadDeDiasTrabajados { get; set; }
        [NotMapped]
        public int CantidadUtilizadaenlasOrdenesdeMantenimiento { get; set; }
        [NotMapped, Display(Name = "Cantidad de órdenes en proceso")]
        public int DiasEnProceso { get; set; }

        [NotMapped, Display(Name = "Cantidad de órdenes terminadas")]
        public decimal DiasTrabajados { get; set; }
    }
}
