using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string ContraseniaUsuario { get; set; } = null!;

    public string CorreoUsuario { get; set; } = null!;

    public byte[]? FotoUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string TelefonoUsuario { get; set; } = null!;

    public int? IdAcceso { get; set; }

    public bool Alta { get; set; }

    public virtual Acceso? IdAccesoNavigation { get; set; }

    public virtual ICollection<Incidencia> Incidencia { get; set; } = new List<Incidencia>();

    public virtual ICollection<Solicitude> Solicitudes { get; set; } = new List<Solicitude>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
