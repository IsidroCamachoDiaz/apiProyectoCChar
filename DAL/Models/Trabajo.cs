using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Trabajo
{
    public int IdTrabajo { get; set; }

    public string DescripcionTrabajo { get; set; } = null!;

    public bool EstadoTrabajo { get; set; }

    public int HorasTrabajo { get; set; }

    public int? IdIncidencia { get; set; }

    public int? IdTipoIncidencia { get; set; }

    public virtual Incidencia? IdIncidenciaNavigation { get; set; }

    public virtual TiposIncidencia? IdTipoIncidenciaNavigation { get; set; }
}
