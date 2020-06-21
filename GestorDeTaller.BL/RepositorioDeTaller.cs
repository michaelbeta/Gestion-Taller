using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestorDeTaller.DA;
using GestorDeTaller.Model;
using GestorDeTaller.UI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GestorDeTaller.BL
{
    public class RepositorioDeTaller : IRepositorioDeTaller
    {
        private ContextoDeBaseDeDatos ElContextoDeBaseDeDatos;

      

        public RepositorioDeTaller(ContextoDeBaseDeDatos contexto)
        {
            ElContextoDeBaseDeDatos = contexto;
           
        }


        public List<Articulo> ObtenerArticulo()
        {
            List<Articulo> laListaDeArticulos = ElContextoDeBaseDeDatos.articulo.ToList();
            return laListaDeArticulos;
        }
        public void AgregarArticulo(Articulo articulo)
        {


            ElContextoDeBaseDeDatos.articulo.Add(articulo);
            ElContextoDeBaseDeDatos.SaveChanges();

        }
        public void EditarArticulo(Articulo articulo)
        {
            Articulo ArticuloParaActualizar;

            ArticuloParaActualizar = ObtenerPorId(articulo.Id);

            ArticuloParaActualizar.Nombre = articulo.Nombre;
            ArticuloParaActualizar.Marca = articulo.Marca;
            ArticuloParaActualizar.Descripcion = articulo.Descripcion;

            ElContextoDeBaseDeDatos.articulo.Update(ArticuloParaActualizar);
            ElContextoDeBaseDeDatos.SaveChanges();
        }
        public Articulo ObtenerPorId(int id)
        {
            Articulo articulo;
            articulo = ElContextoDeBaseDeDatos.articulo.Find(id);

            return articulo;
        }



        public List<Repuesto> ObtenerRepuestoAsociadosAlArticulo(int id)
        {

            var resultado = from c in ElContextoDeBaseDeDatos.repuestos
                            where c.Id_Articulo == id
                            select c;

            return resultado.ToList();
        }

        public void AgregarRepuesto(Repuesto repuesto,int id)
        {
            repuesto.Id_Articulo = id;
            ElContextoDeBaseDeDatos.repuestos.Add(repuesto);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public void EditarCatalogoDeMantenimiento(Mantenimiento mantenimiento)
        {
            Mantenimiento ActualizarUnMantenimiento;

            ActualizarUnMantenimiento = ObteneCatalogoDeMantenimeintosPorId(mantenimiento.Id);

            ActualizarUnMantenimiento.Descripcion = mantenimiento.Descripcion;
            ActualizarUnMantenimiento.CostoFijo = mantenimiento.CostoFijo;


            ElContextoDeBaseDeDatos.mantenimientos.Update(ActualizarUnMantenimiento);
            ElContextoDeBaseDeDatos.SaveChanges();
        }
        public void AgregarMantenimiento(Mantenimiento mantenimiento,int id)
        {
            mantenimiento.Id_Articulo = id;
            ElContextoDeBaseDeDatos.mantenimientos.Add(mantenimiento);
            ElContextoDeBaseDeDatos.SaveChanges();
        }
        public List<Mantenimiento> ObtenerCatalogoDeMantenimeintos(int id)
        {
            var resultado = from c in ElContextoDeBaseDeDatos.mantenimientos
                            where c.Id_Articulo == id
                            select c;

            return resultado.ToList();
        }
      

        public Mantenimiento ObteneCatalogoDeMantenimeintosPorId(int id)
        {
            Mantenimiento mantenimiento;
            mantenimiento = ElContextoDeBaseDeDatos.mantenimientos.Find(id);

            return mantenimiento;
        }

        public void EditarRepuesto(Repuesto repuesto)
        {
            Repuesto RepuestoParaActualizar;

            RepuestoParaActualizar = ObtenerRepuestoPorId(repuesto.Id);

            RepuestoParaActualizar.Nombre = repuesto.Nombre;
            RepuestoParaActualizar.Precio = repuesto.Precio;
            RepuestoParaActualizar.Descripcion = repuesto.Descripcion;

            ElContextoDeBaseDeDatos.repuestos.Update(RepuestoParaActualizar);
            ElContextoDeBaseDeDatos.SaveChanges();

        }
        public Repuesto ObtenerRepuestoPorId(int id)
        {
            Repuesto repuesto;
            repuesto = ElContextoDeBaseDeDatos.repuestos.Find(id);

            return repuesto;
        }

        public List<Articulo> ObtenerArticuloAsociadosAlRepuesto(int id)
        {
            Repuesto repuesto;
            repuesto = ElContextoDeBaseDeDatos.repuestos.Find(id);

            var resultado = from c in ElContextoDeBaseDeDatos.articulo
                            where c.Id == repuesto.Id_Articulo
                            select c;

            return resultado.ToList();
        }
        public List<Repuesto> ObtenerRepuestosPorID(int id)
        {
            var resultado = from c in ElContextoDeBaseDeDatos.repuestos
                            where c.Id == id
                            select c;

            return resultado.ToList();
        }
       
        public List<Repuesto> ObtenerRepuestosAsociadosAlMantenimiento(int id)
        {
            int idRepuesto = 0;
           
            if (ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.Count() == 0)
            {}
            else
            {
 
              Mantenimiento mantenimiento = ElContextoDeBaseDeDatos.mantenimientos.Find(id);

              List<RepuestoParaMantenimiento> listaDeRepuestoParaMantenimiento = ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.ToList();
              

                foreach (var item in listaDeRepuestoParaMantenimiento)
                {
                    if (item.Id_Mantenimiento == mantenimiento.Id)
                    {
                     
                        idRepuesto = item.Id_Repuesto;
                    }
                }
               
            }
            var resultado = from c in ElContextoDeBaseDeDatos.repuestos
                            where c.Id == idRepuesto
                            select c;


            return resultado.ToList();
        }
       

        public List<Mantenimiento> ObtenerMantenimientoAsociadoAlRepuesto(int id)
        {
            Repuesto repuesto;
            repuesto = ElContextoDeBaseDeDatos.repuestos.Find(id);

            var resultado = from c in ElContextoDeBaseDeDatos.mantenimientos
                            where c.Id_Articulo == repuesto.Id_Articulo
                            select c;

            return resultado.ToList();
        }

        public List<Repuesto> ObtenerCatalogoRepuestos()
        {

            List<Repuesto> laListaDeRepuestos = ElContextoDeBaseDeDatos.repuestos.ToList();
            return laListaDeRepuestos;
        }

        public List<OrdenDeMantenimiento> ListarOrdenesDeMantenimientoRecibidas()
        {
            var resultado = from c in ElContextoDeBaseDeDatos.ordenesDeMantenimiento
                            where c.Estado== Estado.Recibido
                            select c;

            return resultado.ToList();
        }

        public List<OrdenDeMantenimiento> ListarOrdenesDeMantenimentoEnProceso()
        {

            var resultado = from c in ElContextoDeBaseDeDatos.ordenesDeMantenimiento
                            where c.Estado == Estado.EnProceso
                            select c;

            return resultado.ToList();
        }

        public List<OrdenDeMantenimiento> ListarOrdenesDeMantenimientoTerminadas()
        {
            var resultado = from c in ElContextoDeBaseDeDatos.ordenesDeMantenimiento
                            where c.Estado == Estado.Terminado
                            select c;

            return resultado.ToList();
        }

        public void TerminarMantenimiento(int id)
        {
            OrdenDeMantenimiento ordenDeMantenimiento;
            ordenDeMantenimiento = ObtenerOrdenDeMantenimientoPorId(id);
            ordenDeMantenimiento.Estado = Estado.Terminado;
            ordenDeMantenimiento.FechaDeFinalizacion = DateTime.Now;
            Articulo articulo = new Articulo();
           
            ElContextoDeBaseDeDatos.ordenesDeMantenimiento.Update(ordenDeMantenimiento);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public OrdenDeMantenimiento ObtenerOrdenDeMantenimientoPorId(int id)
        {
            OrdenDeMantenimiento ordenDeMantenimiento;
            ordenDeMantenimiento = ElContextoDeBaseDeDatos.ordenesDeMantenimiento.Find(id);
            return ordenDeMantenimiento;
        }
        public Mantenimiento ObtenerMantenimientoPorId(int id)
        {
            Mantenimiento Mantenimiento;
            Mantenimiento = ElContextoDeBaseDeDatos.mantenimientos.Find(id);

            return Mantenimiento;
        }
        public List<OrdenDeMantenimiento> ListarOrdenesDeMantenimentoCanceladas()
        {
            var resultado = from c in ElContextoDeBaseDeDatos.ordenesDeMantenimiento
                            where c.Estado == Estado.Cancelada
                            select c;

            return resultado.ToList();
        }

        public void AgregarARepuestosParaMantenimiento(int idRepuesto, int idMantenimiento)
        {
            List< RepuestoParaMantenimiento> listaDeRepuestoParaMantenimiento = ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.ToList();
            Boolean contieneRepuesto=false;

            foreach (var item in listaDeRepuestoParaMantenimiento)
            {
                if (item.Id_Mantenimiento == idMantenimiento && item.Id_Repuesto==idRepuesto)
                {
                    contieneRepuesto = true;
                }
            }
            if (contieneRepuesto==false)
            {
                RepuestoParaMantenimiento repuestoParaMantenimiento = new RepuestoParaMantenimiento();
                repuestoParaMantenimiento.Id_Repuesto = idRepuesto;
                repuestoParaMantenimiento.Id_Mantenimiento = idMantenimiento;

                ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.Add(repuestoParaMantenimiento);
                ElContextoDeBaseDeDatos.SaveChanges();
            }
          
        }

        public void CancelarMantenimiento(int id, string MotivoDeCancelacion)
        {
            OrdenDeMantenimiento ordenDeMantenimiento = new OrdenDeMantenimiento();
            ordenDeMantenimiento = ObtenerOrdenDeMantenimientoPorId(id);
            ordenDeMantenimiento.Estado = Estado.Cancelada;
            ordenDeMantenimiento.MotivoDeCancelacion = MotivoDeCancelacion;
            ElContextoDeBaseDeDatos.ordenesDeMantenimiento.Update(ordenDeMantenimiento);
            ElContextoDeBaseDeDatos.SaveChanges();
        }
        public void EditaOrdenDeMantenimientoRecibida(OrdenDeMantenimiento ordenDeMantenimiento)
        {
            OrdenDeMantenimiento EditaOrdenDeMantenimientoRecibida;
            EditaOrdenDeMantenimientoRecibida = ObtenerOrdenDeMantenimientoPorId(ordenDeMantenimiento.Id);

            EditaOrdenDeMantenimientoRecibida.NombreDelCliente = ordenDeMantenimiento.NombreDelCliente;
            EditaOrdenDeMantenimientoRecibida.DescripcionDelProblema = ordenDeMantenimiento.DescripcionDelProblema;
            EditaOrdenDeMantenimientoRecibida.MontoDeAdelanto = ordenDeMantenimiento.MontoDeAdelanto;


            ElContextoDeBaseDeDatos.ordenesDeMantenimiento.Update(EditaOrdenDeMantenimientoRecibida);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public Repuesto ObtenerRepuestoAdesasociar(int id)
        {

           Repuesto Repuesto;
           Repuesto = ElContextoDeBaseDeDatos.repuestos.Find(id);

            return Repuesto;
        }

        public void DesasociarRepuesto(int id)
        {
            List<RepuestoParaMantenimiento> listaDeRepuestoParaMantenimiento = ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.ToList();
            int idRepuestoParaMantenimientoAbuscar=0;
            foreach (var item in listaDeRepuestoParaMantenimiento)
            {
                if (item.Id_Repuesto == id)
                {
                    idRepuestoParaMantenimientoAbuscar = item.Id;
                }
            }
            RepuestoParaMantenimiento desasociarRepuesto;
            desasociarRepuesto = ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.Find(idRepuestoParaMantenimientoAbuscar);

            ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.Remove(desasociarRepuesto);
            ElContextoDeBaseDeDatos.SaveChanges();

        }

        public OrdenDeMantenimiento ObtenerOrdenesDeMantenimentoCanceladasPorid(int id)
        {
            OrdenDeMantenimiento detalleDeLaOrdenEnmantenimiento;
            detalleDeLaOrdenEnmantenimiento = ElContextoDeBaseDeDatos.ordenesDeMantenimiento.Find(id);

            return detalleDeLaOrdenEnmantenimiento;
        }

        public List<Articulo> ObtenerArticuloAsociadosALaOrdenEnMantenimiento(int id)
        {
            var resultado = from c in ElContextoDeBaseDeDatos.articulo
                            where c.Id == id
                            select c;

            return resultado.ToList();
        }

        public List<Mantenimiento> ObtenermantenimientoAsociadosalaOrden(int id)
        {
            List<DetalleOrdenesDeMantenimiento> listaDetalleOrdenesDeMantenimiento = ElContextoDeBaseDeDatos.DetalleOrdenesDeMantenimiento.ToList();
            List<RepuestoParaMantenimiento> listaRepuestoParaMantenimiento = ElContextoDeBaseDeDatos.RepuestosParaMantenimiento.ToList();
            List<Repuesto> listaDeRepuestos = ElContextoDeBaseDeDatos.repuestos.ToList();
            int idMantenimientoABuscar = 0;
           
            foreach (var item in listaDetalleOrdenesDeMantenimiento)
            {
                if (item.Id_OrdenesDeMantenimiento == id)
                {
                    idMantenimientoABuscar = item.Id_Mantenimiento;

                   
                }
            }
            ///Costo de repuestos. La suma de los montos de los repuestos asociados al mantenimiento.
            Mantenimiento mantenimiento;
            mantenimiento = ElContextoDeBaseDeDatos.mantenimientos.Find(idMantenimientoABuscar);
            double monto = 0;
            foreach (var item in listaRepuestoParaMantenimiento)
            {
               

                if (item.Id_Mantenimiento==idMantenimientoABuscar)
                {

                    foreach (var BuscarPrecioRepuesto in listaDeRepuestos)
                    {
                        if (BuscarPrecioRepuesto.Id==item.Id_Repuesto)
                        {
                            Repuesto repuesto;
                            repuesto = ElContextoDeBaseDeDatos.repuestos.Find(BuscarPrecioRepuesto.Id);

                            monto += repuesto.Precio;

                        }

                    }
            }
                }
            if (idMantenimientoABuscar==0)
            {}
            else
            {
                mantenimiento.CostoDeRepuestos = monto;
            }
           

          var resultado = from c in ElContextoDeBaseDeDatos.mantenimientos
                            where c.Id == idMantenimientoABuscar
                            select c;

            return resultado.ToList();
        }
        public void AgregarOrdenDeMantenimientoRecibida(int id,OrdenDeMantenimiento ordenDeMantenimiento)
        {

            OrdenDeMantenimiento orden = new OrdenDeMantenimiento();
            orden.Id_Articulo = id;
            orden.NombreDelCliente = ordenDeMantenimiento.NombreDelCliente;
            orden.Estado = Estado.Recibido;
            orden.DescripcionDelProblema = ordenDeMantenimiento.DescripcionDelProblema;
            orden.FechaDeIngreso = DateTime.Now;
            orden.MontoDeAdelanto = ordenDeMantenimiento.MontoDeAdelanto;

            ElContextoDeBaseDeDatos.ordenesDeMantenimiento.Add(orden);
            ElContextoDeBaseDeDatos.SaveChanges();
        }

        public OrdenDeMantenimiento ObtenerOrdenesDeMantenimentoTerminadasPorid(int id)
        {
            OrdenDeMantenimiento detalleDeLaOrdenEnmantenimiento;
            detalleDeLaOrdenEnmantenimiento = ElContextoDeBaseDeDatos.ordenesDeMantenimiento.Find(id);

            return detalleDeLaOrdenEnmantenimiento;
        }
        public void AgregarMantenimientoAOrdenRecibidas(int idOrdenDeMantenimiento, int idMantenimiento)

        {
            DetalleOrdenesDeMantenimiento detalleOrdenesDeMantenimiento = new DetalleOrdenesDeMantenimiento();

            detalleOrdenesDeMantenimiento.Id_Mantenimiento = idMantenimiento;
            detalleOrdenesDeMantenimiento.Id_OrdenesDeMantenimiento = idOrdenDeMantenimiento;

            ElContextoDeBaseDeDatos.DetalleOrdenesDeMantenimiento.Add(detalleOrdenesDeMantenimiento);
            ElContextoDeBaseDeDatos.SaveChanges();
        }
        public void IniciarOrdenDerMantenimiento(int id)
        {
            OrdenDeMantenimiento IniciarordenDeMantenimiento;
            IniciarordenDeMantenimiento = ObtenerOrdenesDeMantenimentoEnProcesoPorId(id);
            IniciarordenDeMantenimiento.Estado = Estado.EnProceso;
            IniciarordenDeMantenimiento.FechaDeInicio = DateTime.Now;

            ElContextoDeBaseDeDatos.ordenesDeMantenimiento.Update(IniciarordenDeMantenimiento);
            ElContextoDeBaseDeDatos.SaveChanges();


        }
        public OrdenDeMantenimiento ObtenerOrdenesDeMantenimentoEnProcesoPorId(int id)
        {
            OrdenDeMantenimiento ordenDeMantenimiento;
            ordenDeMantenimiento = ElContextoDeBaseDeDatos.ordenesDeMantenimiento.Find(id);
            return ordenDeMantenimiento;
        }
        public List<Mantenimiento> ObtenerMantenimiento()
        {
            List<Mantenimiento> laListaDeArticulos = ElContextoDeBaseDeDatos.mantenimientos.ToList();
            return laListaDeArticulos;
        }
        public void AgregarDetallesOrdenesDeMantenimiento(int idMantenimiento, int OrdenDeMantenimiento)
        {
            DetalleOrdenesDeMantenimiento detalleOrdenesDeMantenimiento = new DetalleOrdenesDeMantenimiento();
            detalleOrdenesDeMantenimiento.Id_Mantenimiento = idMantenimiento;
            detalleOrdenesDeMantenimiento.Id_OrdenesDeMantenimiento = OrdenDeMantenimiento;

            ElContextoDeBaseDeDatos.DetalleOrdenesDeMantenimiento.Add(detalleOrdenesDeMantenimiento);
            ElContextoDeBaseDeDatos.SaveChanges();

        }
        public List<Costos> ObtenerCatalogoDeMantenimeintosMasRepuestos(int id)
        {
            var ResultadoTotal = from c in ElContextoDeBaseDeDatos.mantenimientos
                                 join x in ElContextoDeBaseDeDatos.RepuestosParaMantenimiento on c.Id equals x.Id_Mantenimiento
                                 join z in ElContextoDeBaseDeDatos.repuestos on x.Id_Repuesto equals z.Id
                                 where c.Id_Articulo == id
                                 select z.Precio;
            double total = ResultadoTotal.Sum();
            var resultado = (from c in ElContextoDeBaseDeDatos.mantenimientos
                             join x in ElContextoDeBaseDeDatos.RepuestosParaMantenimiento on c.Id equals x.Id_Mantenimiento
                             join z in ElContextoDeBaseDeDatos.repuestos on x.Id_Repuesto equals z.Id
                             where c.Id_Articulo == id
                             select new Costos { Descripcion = c.Descripcion, CostoFijo = c.CostoFijo, ID = c.Id, CostoRepuestos = total })
                            .Distinct();


            return resultado.ToList();
        }

        public List<DetalleOrdenesDeMantenimiento> obtenerDetallesOrdenDeMantenimiento(int id)
        {

            var resultado = from c in ElContextoDeBaseDeDatos.DetalleOrdenesDeMantenimiento
                            where c.Id == id
                            select c;

            return resultado.ToList();

        }

        public DetallesRepuesto ObtenerDetalleRepuesto(int id)
        {
            DetallesRepuesto detallesRepuesto = new DetallesRepuesto();
            List<Mantenimiento> mantenimientos = new List<Mantenimiento>();

            detallesRepuesto.repuesto = ObtenerRepuestoPorId(id);
            detallesRepuesto.articulo = ObtenerPorId(detallesRepuesto.repuesto.Id_Articulo);
            var resultado = from c in ElContextoDeBaseDeDatos.RepuestosParaMantenimiento
                            where c.Id_Repuesto == detallesRepuesto.repuesto.Id
                            select c;
            foreach (var item in resultado.ToList())
            {
                mantenimientos.Add(ObteneCatalogoDeMantenimeintosPorId(item.Id_Mantenimiento));
            }
            detallesRepuesto.Cantidad = (int)resultado.ToList().Count;
            detallesRepuesto.Lista = mantenimientos;



            return detallesRepuesto;
        }
        public List<OrdenDeMantenimiento> ListarOrdenesDeMantenimientoEnProceso()
        {
            OrdenDeMantenimiento ordenes = new OrdenDeMantenimiento();

            var resultado = from c in ElContextoDeBaseDeDatos.ordenesDeMantenimiento
                            where c.Estado == Estado.EnProceso
                            select c;
            if (resultado != null)
            {
                foreach (var item in resultado)
                {

                    DateTime fecha_Ingreso = item.FechaDeIngreso;
                    DateTime fecha_Inicio = (DateTime)item.FechaDeInicio;
                    TimeSpan ts = fecha_Inicio - fecha_Ingreso;
                    ordenes.DiasEnProceso = ts.Days;

                    item.DiasEnProceso = ordenes.DiasEnProceso;
                }
            }


            return resultado.ToList();
        }
    }
}
