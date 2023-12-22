using System;
using System.Collections.Generic;

namespace WebApplicationMVC02.Models;

public partial class Paise
{
    public int Id { get; set; }

    public string? Pais { get; set; }

    public string? CodEnTransportes { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
