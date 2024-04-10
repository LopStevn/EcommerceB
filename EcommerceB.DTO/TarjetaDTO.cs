using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceB.DTO
{
    public class TarjetaDTO
    {
        [Required(ErrorMessage = "Titular es obligatorio")]
        public string? Titular { get; set; }

        [Required(ErrorMessage = "Numero es obligatorio")]
        public string? Numero { get; set; }

        [Required(ErrorMessage = "Vigencia es obligatorio")]
        public string? Vigencia { get; set; }

        [Required(ErrorMessage = "CVV es obligatorio")]
        public string? CVV { get; set; }
    }
}
