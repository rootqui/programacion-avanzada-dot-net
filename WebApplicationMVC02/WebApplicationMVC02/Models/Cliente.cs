using System;
using System.Collections.Generic;

namespace WebApplicationMVC02.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? CargoCont { get; set; }

    public string? Dire { get; set; }

    public string? Ciudad { get; set; }

    public string? Region { get; set; }

    public string? Cpostal { get; set; }

    public int? IdPaises { get; set; }

    public string? Te { get; set; }

    public string? Fax { get; set; }

    public virtual Paise? IdPaisesNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
