using EcommerceB.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceB.Servicio.Contrato
{
    public interface IDashboardServicio
    {
        DashboardDTO Resumen();
    }
}
