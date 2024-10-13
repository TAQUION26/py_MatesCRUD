using System;
using System.Collections.Generic;

namespace RondaCordobesaRESTFULAPI.Models;

public partial class Proveedore
{
    public int Idproveedor { get; set; }

    public string? NombreProveedor { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Provincia { get; set; }

    public string? CodigoPostal { get; set; }

    public virtual ICollection<Compra> Compras { get; } = new List<Compra>();
}
