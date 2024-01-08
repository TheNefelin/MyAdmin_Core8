using Shared_ClassLibrary;
using System.Net.Http.Json;

namespace Client_BlazorWebAssembly.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly HttpClient _httpClient;

        public EmpleadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmpleadoDTO>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<List<EmpleadoDTO>>>("api/Empleado/GetAll");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<EmpleadoDTO> GetById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseAPI<EmpleadoDTO>>($"api/Empleado/GetById/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }

        public async Task<int> Post(EmpleadoDTO empleadoDTO)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Empleado/Post", empleadoDTO);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Put(EmpleadoDTO empleadoDTO)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Empleado/Put/{empleadoDTO.Id}", empleadoDTO);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }
        public async Task<bool> Delete(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Empleado/Delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }

    }
}
