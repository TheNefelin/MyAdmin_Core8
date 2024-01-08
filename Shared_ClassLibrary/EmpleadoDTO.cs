using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_ClassLibrary
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Nombre { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
        public int Sueldo { get; set; }

        [Required]
        //[Range(typeof(DateTime), DateTime.Now.AddYears(-120).ToString(), DateTime.Now.ToString(), ErrorMessage = "La fecha del campo {0} esta fuera de rango.")]
        public DateTime FechaContrato { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido.")]
        public int IdDepto { get; set; }

        public DepartamentoDTO? Departamento { get; set; }
    }
}
