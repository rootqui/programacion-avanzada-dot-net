using System;
using System.Collections.Generic;

namespace WebApplicationMVC02.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string NombreProducto { get; set; } = null!;

    public int? IdProveedores { get; set; }

    public int? IdCategorías { get; set; }

    public string? CantidadPorUnidad { get; set; }

    public decimal? PrecioUnidad { get; set; }

    public short? UnidadesEnExistencia { get; set; }

    public short? UnidadesEnPedido { get; set; }

    public int? NivelNuevoPedido { get; set; }

    public bool Suspendido { get; set; }

    public virtual ICollection<DetPed> DetPeds { get; } = new List<DetPed>();

    public virtual Categoria? IdCategoríasNavigation { get; set; }

    public virtual Proveedore? IdProveedoresNavigation { get; set; }
}
