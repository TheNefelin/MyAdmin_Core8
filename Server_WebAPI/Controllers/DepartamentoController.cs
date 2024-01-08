using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server_WebAPI.Models;
using Shared_ClassLibrary;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Server_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DB_Context _dbContext;

        public DepartamentoController(DB_Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responseAPI = new ResponseAPI<List<DepartamentoDTO>>();
            var listaDepartamentoDTO = new List<DepartamentoDTO>();

            try
            {
                foreach (var item in await _dbContext.Departamentos.ToListAsync())
                {
                    listaDepartamentoDTO.Add(new DepartamentoDTO
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                    });
                }

                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listaDepartamentoDTO;
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }

        [HttpGet]
        [Route("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var responseAPI = new ResponseAPI<DepartamentoDTO>();
            var departamentoDTO = new DepartamentoDTO();

            try
            {
                var departamento = await _dbContext.Departamentos.FirstOrDefaultAsync(d => d.Id == id);

                if (departamento != null)
                {
                    departamentoDTO.Id = departamento.Id;
                    departamentoDTO.Nombre = departamento.Nombre;

                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = departamentoDTO;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "No Encontrado";
                }
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }
    }
}
