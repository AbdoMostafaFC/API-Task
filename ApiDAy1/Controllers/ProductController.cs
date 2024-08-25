using ApiDAy1.models;
using ApiDAy1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDAy1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Irepository<Product> productRepository;

        public ProductController(Irepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult getall()
        {
           var productlist= productRepository.GetAll();

            return Ok(productlist);

        }
        [HttpGet("{id:int}")]
        public IActionResult getbyid(int id)
        {
           var result=   productRepository.Getbyid(id);
            return Ok(result);

        }
        [HttpPost]
        public IActionResult add(Product p)
        {
            if(ModelState.IsValid)
            {
                productRepository.Add(p);
                return Ok("add complete");
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult update(int id,Product p)
        {
            productRepository.put(id,p);
            return Ok("updated successfully");

        }
    }
}
