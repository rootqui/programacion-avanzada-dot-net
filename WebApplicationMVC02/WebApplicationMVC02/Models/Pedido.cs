using System;
using System.Collections.Generic;

namespace WebApplicationMVC02.Models;

public partial class Pedido
{
    public int Id { get; set; }

    public int? IdClientes { get; set; }

    public int? IdEmpleados { get; set; }

    public DateTime? FechaPed { get; set; }

    public DateTime? FechaEntr { get; set; }

    public DateTime? FechaEnv { get; set; }

    public int? IdTransportes { get; set; }

    public decimal? Cargo { get; set; }

    public string? Destinatario { get; set; }

    public string? DirDestinatario { get; set; }

    public string? CiudadDest { get; set; }

    public string? RegDestinatario { get; set; }

    public string? CpostalDes { get; set; }

    public int? IdPaises { get; set; }

    public virtual ICollection<DetPed> DetPeds { get; } = new List<DetPed>();

    public virtual Cliente? IdClientesNavigation { get; set; }

    public virtual Empleado? IdEmpleadosNavigation { get; set; }

    public virtual Paise? IdPaisesNavigation { get; set; }

    public virtual Transporte? IdTransportesNavigation { get; set; }
}
