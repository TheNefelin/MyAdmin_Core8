using System;
using System.Collections.Generic;

namespace Server_WebAPI.Models;

public partial class PfLink
{
    public int IdLink { get; set; }

    public string Nombre { get; set; } = null!;

    public string Linkurl { get; set; } = null!;

    public bool Estado { get; set; }

    public int IdLinkGrp { get; set; }

    public virtual PfLinkGrp IdLinkGrpNavigation { get; set; } = null!;
}
