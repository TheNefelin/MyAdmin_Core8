using Shared_ClassLibrary;

namespace Client_BlazorWebAssembly.Services
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDTO>> GetAll();

        Task<EmpleadoDTO> GetById(int id);

        Task<int> Post(EmpleadoDTO empleadoDTO);

        Task<int> Put(EmpleadoDTO empleadoDTO); 

        Task<bool> Delete(int id);
    }
}
