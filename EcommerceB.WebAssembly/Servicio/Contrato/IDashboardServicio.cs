using EcommerceB.DTO;

namespace EcommerceB.WebAssembly.Servicio.Contrato
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashboardDTO>> Resumen();
    }
}
