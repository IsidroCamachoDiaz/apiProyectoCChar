using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Incidencia
{
    public int IdIncidencia { get; set; }

    public float? CosteIncidencia { get; set; }

    public string? DescripcionTecnica { get; set; }

    public string DescripcionUsuario { get; set; } = null!;

    public bool EstadoIncidencia { get; set; }

    public DateTime? FechaFin { get; set; }

    public DateTime? FechaInicio { get; set; }

    public int? HorasIncidencia { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdSolicitud { get; set; }

    public virtual Solicitude? IdSolicitudNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Trabajo> Trabajos { get; set; } = new List<Trabajo>();
}
