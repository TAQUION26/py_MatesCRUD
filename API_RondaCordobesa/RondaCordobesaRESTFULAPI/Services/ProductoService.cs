using RondaCordobesaRESTFULAPI.Models;
using RondaCordobesaRESTFULAPI.Repositories;
using RondaCordobesaRESTFULAPI.Repositories.Interfaces;

namespace RondaCordobesaRESTFULAPI.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public bool AddProductoService(Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductoService(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetAllProductsService()
        {
            return _repository.GetAll();
        }

        public bool UpdateProductoService(int id, int stockDisponible)
        {
            throw new NotImplementedException();
        }
    }
}
