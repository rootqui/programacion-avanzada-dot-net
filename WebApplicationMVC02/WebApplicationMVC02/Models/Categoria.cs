using System;
using System.Collections.Generic;

namespace WebApplicationMVC02.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descrip { get; set; }

    public string? ArchivoImagen { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
