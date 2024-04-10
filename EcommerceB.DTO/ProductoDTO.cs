using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceB.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion es obligatorio")]
        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "Precio es obligatorio")]
        public decimal? Precio { get; set; }

        [Required(ErrorMessage = "Precio oferta es obligatorio")]
        public decimal? PrecioOferta { get; set; }

        [Required(ErrorMessage = "Cantidad es obligatorio")]
        public int? Cantidad { get; set; }

        [Required(ErrorMessage = "Imagen es obligatorio")]
        public string? Imagen { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }
    }
}
