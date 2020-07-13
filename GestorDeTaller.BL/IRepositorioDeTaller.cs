using GestorDeTaller.Model;
using System.Collections.Generic;

namespace GestorDeTaller.BL
{
    public interface IRepositorioDeTaller
    {
        public List<Articulo> ObtenerArticulo();
        void AgregarRepuesto(Repuesto repuesto, int id);
        public List<Repuesto> ObtenerRepuestoAsociadosAlArticulo(int id);
        void AgregarArticulo(Articulo articulo);
        void AgregarARepuestosParaMantenimiento(int idRepuesto, int idMantenimiento);
        void AgregarMantenimiento(Mantenimiento mantenimiento, int id);
        void EditarArticulo(Articulo articulos);
        Articulo ObtenerPorId(int id);
        Mantenimiento ObteneCatalogoDeMantenimeintosPorId(int id);
        OrdenDeMantenimiento ObtenerOrdenesDeMantenimentoCanceladasPorid(int id);
        List<Mantenimiento> ObtenerCatalogoDeMantenimeintos(int id);
        public void EditarCatalogoDeMantenimiento(Mantenimiento mantenimiento);
        void EditarRepuesto(Repuesto repuesto);
        Repuesto ObtenerRepuestoPorId(int id);
        public List<Articulo> ObtenerArticuloAsociadosAlRepuesto(int id);
        public List<Articulo> ObtenerArticuloAsociadosALaOrdenEnMantenimiento(int id);
        public List<Mantenimiento> ObtenermantenimientoAsociadosalaOrden(int id);
        public List<Repuesto> ObtenerRepuestosPorID(int id);
        public List<Repuesto> ObtenerCatalogoRepuestos();
        public List<Repuesto> ObtenerRepuestosAsociadosAlMantenimiento(int id);
        public List<Mantenimiento> ObtenerMantenimientoAsociadoAlRepuesto(int id);
        public List<OrdenDeMantenimiento> ListarOrdenesDeMantenimientoRecibidas();
        public List<OrdenDeMantenimiento> ListarOrdenesDeMantenimentoEnProceso();
        public List<OrdenDeMantenimiento> ListarOrdenesDeMantenimientoTerminadas();
        public void TerminarMantenimiento(int id);
        public OrdenDeMantenimiento ObtenerOrdenDeMantenimientoPorId(int id);
        public List<OrdenDeMantenimiento> ListarOrdenesDeMantenimentoCanceladas();
        public void CancelarMantenimiento(int id, string MotivoDeCancelacion);
        public void EditaOrdenDeMantenimientoRecibida(OrdenDeMantenimiento ordenDeMantenimiento);
        public Repuesto ObtenerRepuestoAdesasociar(int id);
        public void DesasociarRepuesto(int id);
        void AgregarOrdenDeMantenimientoRecibida(int id, OrdenDeMantenimiento ordenDeMantenimiento);
        OrdenDeMantenimiento ObtenerOrdenesDeMantenimentoTerminadasPorid(int id);
        void AgregarMantenimientoAOrdenRecibidas(int IDmantenimiento, int id_OrdenDeMantenimiento);
        public OrdenDeMantenimiento ObtenerOrdenesDeMantenimentoEnProcesoPorId(int id);
        public void IniciarOrdenDerMantenimiento(int id);
        List<Costos> ObtenerCatalogoDeMantenimeintosMasRepuestos(int id);
        public List<Mantenimiento> ObtenerMantenimiento();
        void AgregarDetallesOrdenesDeMantenimiento(int idMantenimiento, int OrdenDeMantenimiento);
        public Mantenimiento ObtenerMantenimientoPorId(int id);
        public List<DetalleOrdenesDeMantenimiento> obtenerDetallesOrdenDeMantenimiento(int id);
        public List<int> ObtenerDetalleRepuesto(int id);
        public int ListarOrdenesDeMantenimientoEnProceso(int id);
        int ListarOrdenesDeMantenimientoTerminadass(int id);
    }
}
