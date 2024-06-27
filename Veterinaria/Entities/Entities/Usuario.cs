using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Usuario
{
    public int CodigoUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Contraseña { get; set; }

    public string? Rol { get; set; }

    public byte[]? ImagenUsuario { get; set; }

    public DateTime? UltimaConexion { get; set; }

    public string? EstadoUsuario { get; set; }

    public virtual ICollection<Cita> CitaVeterinarioPrincipals { get; set; } = new List<Cita>();

    public virtual ICollection<Cita> CitaVeterinarioSecundarios { get; set; } = new List<Cita>();

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();
}
