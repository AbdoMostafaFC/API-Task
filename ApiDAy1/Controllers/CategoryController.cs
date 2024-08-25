using ApiDAy1.DTO;
using ApiDAy1.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDAy1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Irepository<Category> category;

        public CategoryController(Irepository<Category>category)
        {
            this.category = category;
        }
        [Authorize]
        [HttpGet("{id:int}")]
        public IActionResult getcategorywiyhdetails(int id)
        {

            var cat=category.Getbyid(id);
            CategoryDetalis catdatelais=new CategoryDetalis();
            catdatelais.Name = cat.name;
            foreach(var product  in cat.products) {
            
                catdatelais.products.Add(product.name);
            }

            return Ok(catdatelais);
        }
    }
}
