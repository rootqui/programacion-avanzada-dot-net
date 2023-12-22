using System;
using System.Collections.Generic;

namespace WebApplicationMVC02.Models;

public partial class Transporte
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Te { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
