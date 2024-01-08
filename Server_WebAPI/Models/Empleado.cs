using System;
using System.Collections.Generic;

namespace Server_WebAPI.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Sueldo { get; set; }

    public DateTime FechaContrato { get; set; }

    public int IdDepto { get; set; }

    public virtual Departamento IdDeptoNavigation { get; set; } = null!;
}
