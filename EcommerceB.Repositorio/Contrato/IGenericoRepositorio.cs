using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceB.Repositorio.Contrato
{
    public interface IGenericoRepositorio<TModelo> where TModelo : class
    {
        IQueryable<TModelo> Consulta(Expression<Func<TModelo, bool>> ? filtro = null);

        Task<TModelo> Crear(TModelo modelo);

        Task<bool> Editar(TModelo modelo);

        Task<bool> Eliminar(TModelo modelo);
    }
}
