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

    public Incidencia(string descripcionSolicitud, bool estado, Solicitude solicitude)
    {
        this.DescripcionUsuario = descripcionSolicitud;
        this.EstadoIncidencia = estado;
        this.IdSolicitudNavigation = solicitude;
        this.HorasIncidencia = 0;
        this.CosteIncidencia = 0;
    }

    public Incidencia(string descripcionSolicitud, bool estado, Solicitude solicitude, int idIncidencia, float? costeIncidencia, string? descripcionTecnica, string descripcionUsuario, bool estadoIncidencia, DateTime? fechaFin, DateTime? fechaInicio, int? horasIncidencia, int? idUsuario, int? idSolicitud, Solicitude? idSolicitudNavigation, Usuario? idUsuarioNavigation, ICollection<Trabajo> trabajos) : this(descripcionSolicitud, estado, solicitude)
    {
        IdIncidencia = idIncidencia;
        CosteIncidencia = costeIncidencia;
        DescripcionTecnica = descripcionTecnica;
        DescripcionUsuario = descripcionUsuario;
        EstadoIncidencia = estadoIncidencia;
        FechaFin = fechaFin;
        FechaInicio = fechaInicio;
        HorasIncidencia = horasIncidencia;
        IdUsuario = idUsuario;
        IdSolicitud = idSolicitud;
        IdSolicitudNavigation = idSolicitudNavigation;
        IdUsuarioNavigation = idUsuarioNavigation;
        Trabajos = trabajos;
    }

    public Incidencia()
    {
    }

}
