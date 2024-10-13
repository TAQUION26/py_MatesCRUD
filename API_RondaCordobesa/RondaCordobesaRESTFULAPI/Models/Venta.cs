using System;
using System.Collections.Generic;

namespace RondaCordobesaRESTFULAPI.Models;

public partial class Venta
{
    public int Idventa { get; set; }

    public DateTime? FechaVenta { get; set; }

    public int? Idcliente { get; set; }

    public decimal? TotalVenta { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();

    public virtual Cliente? IdclienteNavigation { get; set; }
}
