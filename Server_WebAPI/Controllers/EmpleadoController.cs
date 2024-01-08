using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server_WebAPI.Models;
using Shared_ClassLibrary;

namespace Server_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class A_EmpleadoController : ControllerBase
    {
        private readonly DB_Context _dbContext;

        public A_EmpleadoController(DB_Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var responseAPI = new ResponseAPI<List<EmpleadoDTO>>();
            var listaEmpleadoDTO = new List<EmpleadoDTO>();

            try
            {
                foreach (var item in await _dbContext.Empleados.Include(d => d.IdDeptoNavigation).ToListAsync())
                {
                    listaEmpleadoDTO.Add(new EmpleadoDTO
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Sueldo = item.Sueldo,
                        FechaContrato = item.FechaContrato,
                        IdDepto = item.IdDepto,
                        Departamento = new DepartamentoDTO
                        {
                            Id = item.IdDeptoNavigation.Id,
                            Nombre = item.IdDeptoNavigation.Nombre,
                        }
                    });
                }

                responseAPI.EsCorrecto = true;
                responseAPI.Valor = listaEmpleadoDTO;
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var responseAPI = new ResponseAPI<EmpleadoDTO>();
            var empleadoDTO = new EmpleadoDTO();

            try
            {
                var empleado = await _dbContext.Empleados.FirstOrDefaultAsync(e => e.Id == id);

                if (empleado != null)
                {
                    empleadoDTO.Id = empleado.Id;
                    empleadoDTO.Nombre = empleado.Nombre;
                    empleadoDTO.Sueldo = empleado.Sueldo;
                    empleadoDTO.FechaContrato = empleado.FechaContrato;
                    empleadoDTO.IdDepto = empleado.IdDepto;

                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = empleadoDTO;
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

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post(EmpleadoDTO empleadoDTO)
        {
            var responseAPI = new ResponseAPI<int>();

            try
            {
                var dbEmpleado = new Empleado
                {
                    Nombre = empleadoDTO.Nombre,
                    Sueldo = empleadoDTO.Sueldo,
                    FechaContrato = empleadoDTO.FechaContrato,
                    IdDepto = empleadoDTO.IdDepto,
                };

                _dbContext.Empleados.Add(dbEmpleado);
                await _dbContext.SaveChangesAsync();

                if (dbEmpleado.Id != 0)
                {
                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = dbEmpleado.Id;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "No Guardado";
                }
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }

        [HttpPut]
        [Route("Put/{id}")]
        public async Task<IActionResult> Put(EmpleadoDTO empleadoDTO, int id)
        {
            var responseAPI = new ResponseAPI<int>();

            try
            {
                var dbEmpleado = await _dbContext.Empleados.FirstOrDefaultAsync(e => e.Id == id);

                if (dbEmpleado != null)
                {
                    dbEmpleado.Nombre = empleadoDTO.Nombre;
                    dbEmpleado.Sueldo = empleadoDTO.Sueldo;
                    dbEmpleado.FechaContrato = empleadoDTO.FechaContrato;
                    dbEmpleado.IdDepto = empleadoDTO.IdDepto;

                    _dbContext.Empleados.Update(dbEmpleado);
                    await _dbContext.SaveChangesAsync();

                    responseAPI.EsCorrecto = true;
                    responseAPI.Valor = dbEmpleado.Id;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "No Modificado";
                }
            }
            catch (Exception ex)
            {
                responseAPI.EsCorrecto = false;
                responseAPI.Mensaje = ex.Message;
            }

            return Ok(responseAPI);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var responseAPI = new ResponseAPI<int>();

            try
            {
                var dbEmpleado = await _dbContext.Empleados.FirstOrDefaultAsync(e => e.Id == id);

                if (dbEmpleado != null)
                {
                    _dbContext.Empleados.Remove(dbEmpleado);
                    await _dbContext.SaveChangesAsync();

                    responseAPI.EsCorrecto = true;
                }
                else
                {
                    responseAPI.EsCorrecto = false;
                    responseAPI.Mensaje = "No Existe";
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
