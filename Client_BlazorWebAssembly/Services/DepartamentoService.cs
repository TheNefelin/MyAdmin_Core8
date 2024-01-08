using Shared_ClassLibrary;
using System.Net.Http.Json;

namespace Client_BlazorWebAssembly.Services
{
    public class DepartamentoService: IDepartamentoService
    {
        private readonly HttpClient _httpClient;

        public DepartamentoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DepartamentoDTO>> GetAll()
        {
            var res = await _httpClient.GetFromJsonAsync<ResponseAPI<List<DepartamentoDTO>>>("api/Departamento/GetAll");

            if (res!.EsCorrecto)
                return res.Valor!;
            else
                throw new Exception(res.Mensaje);
        }
    }
}
