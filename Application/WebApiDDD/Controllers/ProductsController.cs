using DDD.Data;
using DDD.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApiDDD.Jsons;

namespace WebApiDDD.Controllers
{
    [ApiController]
    [Route("api/v1/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public DataContext _dataContext;

        public ProductsController(ILogger<ProductsController> logger, DataContext dbcontext)
        {
            _logger = logger;
            _dataContext = dbcontext;
        }

        [HttpGet]
        public ActionResult<IEnumerable> GetProducts()
        {
            try
            {
                IEnumerable<Product> products = _dataContext.Products.ToList();

                return Ok(products);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao consultar recursos");
            }
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<Product> GetProduct(long id)
        {
            try
            {
                Product product = _dataContext.Products.FirstOrDefault(p => p.Id == id);

                if (product == null)
                    return NotFound($"Produto com id={id} n�o encontrado");

                return Ok(product);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao consultar recurso");
            }
        }

        [Route("CreateProduct")]
        [HttpPost]
        public ActionResult CreateProduct([FromBody] CreateProductDTO jsonCreateProduct)
        {
            try
            {
                if (_dataContext.Products.FirstOrDefault(prod => prod.Code == jsonCreateProduct.Code) != null)
                    return BadRequest($"Produto com o c�digo =  {jsonCreateProduct.Code} j� registrado");

                Product product = new(jsonCreateProduct.Price, jsonCreateProduct.Name, jsonCreateProduct.Code);

                _dataContext.Products.Add(product);

                _dataContext.SaveChanges();

                return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar recurso");
            }
        }

        [Route("UpdatePrice")]
        [HttpPut("{id}")]
        public ActionResult UpdatePrice(int id, [FromBody] UpdatePriceProductDTO updatePriceDTO)
        {
            try
            {
                if (id != updatePriceDTO.Id)
                    return BadRequest($"Os id�s  n�o coincidem");

                Product product = _dataContext.Products.FirstOrDefault(prod => prod.Id == updatePriceDTO.Id);

                product.UpdatePrice(updatePriceDTO.Price);

                _dataContext.SaveChanges();

                return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao consultar recursos");
            }
        }

        [Route("DeleteProduct")]
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(long id)
        {
            try
            {
                Product product = _dataContext.Products.FirstOrDefault(prod => prod.Id == id);

                if (id != product.Id)
                    return BadRequest($"recurso n�o encontrado");

                _dataContext.Products.Remove(product);
                _dataContext.SaveChanges();

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao consultar recursos");
            }
        }
    }
}