using EcommerceB.Repositorio.Contrato;
using EcommerceB.Repositorio.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceB.Repositorio.Implementacion
{
    public class GenericoRepositorio<TModelo> : IGenericoRepositorio<TModelo>  where TModelo :class
    {
        private readonly BlazorEcommerceContext _context;

        public GenericoRepositorio(BlazorEcommerceContext context)
        {
            _context = context;
        }

        public IQueryable<TModelo> Consulta(Expression<Func<TModelo, bool>> ? filtro = null)
        {
            IQueryable<TModelo> consulta = (filtro == null) ? _context.Set<TModelo>() : _context.Set<TModelo>().Where(filtro);
            return consulta;
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                _context.Set<TModelo>().Add(modelo);
                await _context.SaveChangesAsync();
                return modelo;
            }
            catch(Exception ex)
            {
                string mensajeError = $"Ocurrió un error: {ex.Message}";
                throw new Exception(mensajeError);
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _context.Set<TModelo>().Update(modelo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string mensajeError = $"Ocurrió un error: {ex.Message}";
                throw new Exception(mensajeError);
            }
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            try
            {
                _context.Set<TModelo>().Remove(modelo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                string mensajeError = $"Ocurrió un error: {ex.Message}";
                throw new Exception(mensajeError);
            }
        }
    }
}
