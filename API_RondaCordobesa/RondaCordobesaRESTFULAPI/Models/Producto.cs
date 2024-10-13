using System;
using System.Collections.Generic;

namespace RondaCordobesaRESTFULAPI.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string? NombreProducto { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public int? StockDisponible { get; set; }

    public int? Idcategoria { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVenta> DetalleVenta { get; } = new List<DetalleVenta>();

    public virtual Categoria? IdcategoriaNavigation { get; set; }

    public virtual Stock? Stock { get; set; }
}
