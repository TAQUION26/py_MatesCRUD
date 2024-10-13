using System;
using System.Collections.Generic;

namespace RondaCordobesaRESTFULAPI.Models;

public partial class Stock
{
    public int Idproducto { get; set; }

    public int? CantidadDisponible { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual Producto IdproductoNavigation { get; set; } = null!;
}
