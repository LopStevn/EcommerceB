using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceB.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Contraseña es obligatorio")]
        public string? Clave { get; set; }
    }
}
