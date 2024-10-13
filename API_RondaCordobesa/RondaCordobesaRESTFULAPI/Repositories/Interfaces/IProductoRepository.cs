using RondaCordobesaRESTFULAPI.Models;

namespace RondaCordobesaRESTFULAPI.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        List<Producto> GetAll();

        bool AddProducto(Producto producto);

        bool UpdateProducto(int id, int stockDisponible);

        bool DeleteProducto(int id);
    }
}
