using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Xunit;

namespace GestorDeTaller.Model
{
  public  class OrdenDeMantenimiento
    {
        
            public int Id { get; set; }
            [Required(ErrorMessage = "Este campo es requerido")]
            [Display(Name = "Nombre")]
            [MaxLength(25)]
            public String NombreDelCliente { get; set; }
            public Estado Estado { get; set; }
            [Required(ErrorMessage = "Este campo es requerido")]
            [Display(Name = "Descripcion del problema")]
            [MaxLength(120)]
            public String DescripcionDelProblema { get; set; }
            [DataType(DataType.Date)]
            [Display(Name = "Fecha De Ingreso")]
            public DateTime FechaDeIngreso { get; set; }
            [Required(ErrorMessage = "Este campo es requerido")]
            public decimal MontoDeAdelanto { get; set; }
            public int Id_Articulo { get; set; }
            [DataType(DataType.Date)]
            [Display(Name = "Fecha De Inicio")]
            public DateTime ? FechaDeInicio { get; set; }
            [DataType(DataType.DateTime)]
            [Display(Name = "Fecha De Finalizacion")]
            public DateTime ? FechaDeFinalizacion { get; set; }
            public String  MotivoDeCancelacion { get; set; }
               [NotMapped]
            public int 	CantidadDeDiasEnProceso { get; set; }
             [NotMapped]
            public int CantidadDeDiasTrabajados { get; set; }
             [NotMapped]
             public int CantidadUtilizadaenlasOrdenesdeMantenimiento { get; set; }
        [NotMapped, Display(Name = "Cantidad de Órdenes en Proceso")]
        public int DiasEnProceso { get; set; }
        
        [NotMapped, Display(Name = "Cantidad de Órdenes Terminadas")]
        public decimal DiasTrabajados { get; set; }
    }
    }
