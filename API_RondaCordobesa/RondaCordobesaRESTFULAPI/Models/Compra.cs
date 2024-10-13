using System;
using System.Collections.Generic;

namespace RondaCordobesaRESTFULAPI.Models;

public partial class Compra
{
    public int Idcompra { get; set; }

    public DateTime? FechaCompra { get; set; }

    public int? Idproveedor { get; set; }

    public decimal? TotalCompra { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; } = new List<DetalleCompra>();

    public virtual Proveedore? IdproveedorNavigation { get; set; }
}
