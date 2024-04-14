using EcommerceB.DTO;
using EcommerceB.WebAssembly.Servicio.Contrato;
using System.Net.Http.Json;

namespace EcommerceB.WebAssembly.Servicio.Implementacion
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly HttpClient _httpClient;

        public DashboardServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashboardDTO>> Resumen()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>("Dashboard/Resumen");
        }
    }
}
