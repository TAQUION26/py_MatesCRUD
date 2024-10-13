using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RondaCordobesaRESTFULAPI.Repositories.Interfaces;
using RondaCordobesaRESTFULAPI.Services;

namespace RondaCordobesaRESTFULAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductoController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet("GET ALL PRODUCTS")]
        public IActionResult GetAllProductos()
        {
            var resultado = _service.GetAllProductsService();

            if(resultado != null)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest("No tienes productos para traer de tu base de datos!! :P");
            }
        }
    }
}
