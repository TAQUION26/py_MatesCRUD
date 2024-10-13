using RondaCordobesaRESTFULAPI.Models;
using RondaCordobesaRESTFULAPI.Repositories.Interfaces;

namespace RondaCordobesaRESTFULAPI.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DbRondacordobesaContext _context;

        public ProductoRepository(DbRondacordobesaContext context)
        {
            _context = context;
        }

        public bool AddProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProducto(int id)
        {
            throw new NotImplementedException();
        }

        public List<Producto> GetAll()
        {
            var productos = _context.Productos.ToList();
            return productos;
        }

        public bool UpdateProducto(int id, int stockDisponible)
        {
            throw new NotImplementedException();
        }
    }
}
