using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Acceso
{
    public int IdAcceso { get; set; }

    public string CodigoAcceso { get; set; } = null!;

    public string? DescripcionAcceso { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
