using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ToysRMe.CommonLibrary.Models;

namespace ToysRMe.WebMVC.Controllers
{
  public class HomeController : Controller
  {
    private AppSettings AppSettings { get; set; }
    private HttpClient WebClient { get; set; }

    public HomeController(IOptions<AppSettings> settings)
    {
      AppSettings = settings.Value;

      WebClient = new HttpClient { BaseAddress = new Uri(AppSettings.ToyRMeWebApiUrl) };
      WebClient.DefaultRequestHeaders.Accept.Clear();
      WebClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    }

    public IActionResult Index()
    {
      return this.RedirectToAction("Index", "Product");
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Toys and Game Store Application Example.";

      return View();
    }    

    public IActionResult Error()
    {
      return View();
    }
  }
}
