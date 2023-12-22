using System;
using System.Collections.Generic;

namespace WebApplicationMVC02.Models;

public partial class Proveedore
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? CargoContacto { get; set; }

    public string? Direc { get; set; }

    public string? Ciudad { get; set; }

    public string? Region { get; set; }

    public string? Cpostal { get; set; }

    public string? Pais { get; set; }

    public string? Te { get; set; }

    public string? Fax { get; set; }

    public string? PagPrincipal { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
