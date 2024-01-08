using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_ClassLibrary
{
    public class DepartamentoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
    }
}
