using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Solicitude
{
    public int IdSolicitud { get; set; }

    public string DescripcionSolicitud { get; set; } = null!;

    public bool Estado { get; set; }

    public DateTime? FechaLimite { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Incidencia> Incidencia { get; set; } = new List<Incidencia>();
}
