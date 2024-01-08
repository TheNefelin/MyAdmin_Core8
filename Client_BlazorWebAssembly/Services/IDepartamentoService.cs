using Shared_ClassLibrary;

namespace Client_BlazorWebAssembly.Services
{
    public interface IDepartamentoService
    {
        Task<List<DepartamentoDTO>> GetAll();
    }
}
