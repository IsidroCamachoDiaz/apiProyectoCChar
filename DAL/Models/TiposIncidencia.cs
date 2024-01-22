using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class TiposIncidencia
{
    public int IdTipo { get; set; }

    public string DescripcionTipo { get; set; } = null!;

    public DateTime? FechaExpiracion { get; set; }

    public double PrecioTipo { get; set; }

    public virtual ICollection<Trabajo> Trabajos { get; set; } = new List<Trabajo>();
}
