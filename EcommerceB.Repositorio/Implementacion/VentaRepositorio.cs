using EcommerceB.Modelo;
using EcommerceB.Repositorio.Contrato;
using EcommerceB.Repositorio.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceB.Repositorio.Implementacion
{
    public class VentaRepositorio : GenericoRepositorio<Venta>, IVentaRepositorio
    {
        private readonly BlazorEcommerceContext _context;

        public VentaRepositorio(BlazorEcommerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach(DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto producto_encontrado = _context.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;

                        _context.Productos.Update(producto_encontrado);
                    }

                    await _context.SaveChangesAsync();

                    await _context.Venta.AddAsync(modelo);
                    ventaGenerada = modelo;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return ventaGenerada;
        }
    }
}
