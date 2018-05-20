using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ToysRMe.CommonLibrary.Contracts;
using ToysRMe.CommonLibrary.Models;

namespace ToysRMe.WebApi.Services
{
  public class ProductRepository : IRepository<Product>
  {
    private List<Product> _products;    
    private static readonly string ProductFile = Path.Combine(AppContext.BaseDirectory, "products.json");
    
    public void Add(Product product)
    {
      List<Product> products = GetAll().ToList();

      int nextIndex = 1;

      if (products != null && products.Count > 0)
      {
        int last = products.FindLastIndex(i => i != null);
        nextIndex = products[last].Id + 1;
      }

      product.Id = nextIndex;
      products.Add(product);

      SaveProducts(products);
    }

    private void SaveProducts(List<Product> products)
    {
      if (File.Exists(ProductFile))
        File.Delete(ProductFile);

      using (FileStream fs = File.Open(ProductFile, FileMode.Create))
      using (StreamWriter sw = new StreamWriter(fs))
      using (JsonWriter jw = new JsonTextWriter(sw))
      {
        jw.Formatting = Formatting.Indented;

        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(jw, products);
      }
    }

    public IEnumerable<Product> GetAll()
    {
      if (!File.Exists(ProductFile))
      {
        SaveProducts(new List<Product>());
      }

      return _products = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(ProductFile));
    }

    public Product GetById(int id)
    {
      return GetAll().First(x => x.Id.Equals(id));
    }


    public void Delete(int productId)
    {
      List<Product> products = GetAll().ToList();
      Product result = products.Find(x => x.Id.Equals(productId));
      products.Remove(result);

      SaveProducts(products);
    }

    public void Update(Product product)
    {
      List<Product> products = GetAll().ToList();

      var data = products.Find(x => x.Id.Equals(product.Id));

      data.AgeRestriction = product.AgeRestriction;
      data.Company = product.Company;
      data.Description = product.Description;
      data.Name = product.Name;
      data.Price = product.Price;

      SaveProducts(products);
    }
  }
}
