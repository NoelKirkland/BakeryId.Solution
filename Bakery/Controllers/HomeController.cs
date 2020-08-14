using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bakery.Models;

namespace Bakery.Controllers
{
  public class HomeController : Controller
  {
    private readonly BakeryContext _db;

    public HomeController(BakeryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/Details")]
    public ActionResult Details()
    {
      List<Flavor> flavors = _db.Flavors.ToList();
      List<Treat> treats = _db.Treats.ToList();
      ViewBag.flavorsBag = flavors;
      ViewBag.treatsBag = treats;
      return View();
    }
  }
}