using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceB.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Nombre completo es obligatorio")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Contraseña es obligatorio")]
        public string? Clave { get; set; }

        [Required(ErrorMessage = "Confirmar contraseña es obligatorio")]
        public string? ConfirmarClave { get; set; }

        public string? Rol { get; set; }
    }
}
