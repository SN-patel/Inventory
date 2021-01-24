using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Context.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IRepository<Product> _prodRepo;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IRepository<Product> repo,ILogger<ProductController> logger)
        {
            _logger = logger;
            _prodRepo = repo;
        }

        [HttpPost]
        public IActionResult Add(Product p)
        {
            var id = _prodRepo.Add(p);
            _logger.LogInformation("Product {@Product} added", p);
            return Ok(id);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var prod = _prodRepo.Get(id);
            _logger.LogInformation("Product {@Product} fetched", prod);
            return Ok(prod);
        }

        [Route("getall")]
        public IActionResult GetAll()
        {
            var prod = _prodRepo.GetAll();
            _logger.LogInformation("Product {@Product} fetched", prod);
            return Ok(prod);
        }

        public IActionResult Update(Product p)
        {
            _prodRepo.Update(p);
            _logger.LogInformation("Product {@Product} updated", p);
            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var prod = _prodRepo.Get(id);
            _prodRepo.Delete(prod);
            _logger.LogInformation("Product {@Product} deleted", prod);
            return Ok();
        }
    }
}
