using RondaCordobesaRESTFULAPI.Models;

namespace RondaCordobesaRESTFULAPI.Repositories.Interfaces
{
    public interface IProductoService
    {
        List<Producto> GetAllProductsService();

        bool AddProductoService(Producto producto);

        bool UpdateProductoService(int id, int stockDisponible);

        bool DeleteProductoService(int id);
    }
}
