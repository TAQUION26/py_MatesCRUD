using System;
using System.Collections.Generic;

namespace RondaCordobesaRESTFULAPI.Models;

public partial class Categoria
{
    public int Idcategoria { get; set; }

    public string? NombreCategoria { get; set; }

    public string? DescripcionCategoria { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
