using EcommerceB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceB.Servicio.Contrato
{
    public interface ICategoriaServicio
    {
        Task<List<CategoriaDTO>> Lista(string buscar);

        Task<CategoriaDTO> Obtener(CategoriaDTO modelo);

        Task<CategoriaDTO> Crear(CategoriaDTO modelo);

        Task<bool> Editar(CategoriaDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
