using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Token
{
    public int IdToken { get; set; }

    public DateTime? FechaLimite { get; set; }

    public string Token1 { get; set; } = null!;

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
