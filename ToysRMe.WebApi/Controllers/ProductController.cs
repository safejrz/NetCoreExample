using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToysRMe.CommonLibrary.Contracts;
using ToysRMe.CommonLibrary.Models;


namespace ToysRMe.WebApi.Controllers
{
  [Route("api/[controller]")]
  public class ProductController : Controller
  {
    public IRepository<Product> Products { get; set; }

    public ProductController(IRepository<Product> productRepository)
    {
      Products = productRepository;
    }

    // GET api/values
    [HttpGet]
    public IEnumerable<Product> Get()
    {
      return Products.GetAll();
    }


    [HttpGet("{id}", Name = "GetProduct")]
    public IActionResult GetById(int id)
    {
      var item = Products.GetById(id);
      if (item == null)
      {
        return NotFound();
      }
      return new ObjectResult(item);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Product product)
    {
      if (product == null)
      {
        return BadRequest();
      }

      Products.Add(product);
      return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
    }

    [HttpPut]
    public IActionResult Update([FromBody] Product item)
    {
      Products.Update(item);
      return new NoContentResult();
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      Products.Delete(id);
      return new NoContentResult();
    }
  }
}
