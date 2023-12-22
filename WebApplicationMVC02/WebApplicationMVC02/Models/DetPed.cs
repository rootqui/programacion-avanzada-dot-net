using System;
using System.Collections.Generic;

namespace WebApplicationMVC02.Models;

public partial class DetPed
{
    public int Id { get; set; }

    public int? IdPedidos { get; set; }

    public int IdProductos { get; set; }

    public decimal PrecioUnidad { get; set; }

    public short Cantidad { get; set; }

    public float Descuento { get; set; }

    public virtual Pedido? IdPedidosNavigation { get; set; }

    public virtual Producto IdProductosNavigation { get; set; } = null!;
}
