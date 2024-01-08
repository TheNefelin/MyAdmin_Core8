using System;
using System.Collections.Generic;

namespace Server_WebAPI.Models;

public partial class PfLinkGrp
{
    public int IdLinkGrp { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<PfLink> PfLinks { get; set; } = new List<PfLink>();
}
