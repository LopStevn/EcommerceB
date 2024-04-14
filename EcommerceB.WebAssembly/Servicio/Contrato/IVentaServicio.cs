using EcommerceB.DTO;

namespace EcommerceB.WebAssembly.Servicio.Contrato
{
    public interface IVentaServicio
    {
        Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO modelo);
    }
}
