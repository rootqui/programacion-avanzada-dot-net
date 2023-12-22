using System;
using System.Collections.Generic;

namespace WebApplicationMVC02.Models;

public partial class Usuario
{
    public string Usuario1 { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string NombreyApellidos { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Telefono { get; set; }

    public string Tipo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte Intentos { get; set; }

    public bool Bloqueado { get; set; }
}
