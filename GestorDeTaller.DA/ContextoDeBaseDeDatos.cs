
using GestorDeTaller.Model;
using GestorDeTaller.UI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;



namespace GestorDeTaller.DA
{
    public class ContextoDeBaseDeDatos : DbContext
    {
        public DbSet<Articulo> articulo { get; set; }
        public DbSet<Repuesto> repuestos { get; set; }
        public DbSet<Mantenimiento> mantenimientos { get; set; }
        public DbSet<OrdenDeMantenimiento> ordenesDeMantenimiento { get; set; }
        public DbSet<RepuestoParaMantenimiento> RepuestosParaMantenimiento { get; set; }
        public DbSet<DetalleOrdenesDeMantenimiento> DetalleOrdenesDeMantenimiento { get; set; }
        public ContextoDeBaseDeDatos(DbContextOptions<ContextoDeBaseDeDatos> opciones) : base(opciones)



        { }
    }
}



