using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Bakery.Controllers
{
  public class FlavorsController : Controllers
  {
    private readonly BakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public FlavorsController(UserManager<ApplicationUser> userManager, BakeryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Flavors.ToList());
    }

    [Authorize]
    public ActionResult Create()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Flavor flavor)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      recipe.User = currentUser;
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id) //Maybe change user ViewBag requirements
    {
      Flavors thisFlavor = _db.Flavors
      .Include(flavor => flavor.Treats)
      .ThenInclude(join => join.Treat)
      .Include(flavor => flavor.User)
      .FirstOrDefault(flavor => flavor.FlavorId == id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      ViewBag.IsCurrentUser = userId != null ? userId == thisFlavor.User.Id : false;
      return View(thisFlavor);
    }

    [Authorize]
    public async Task<ActionResult> Edit(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisFlavor = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).FirstOrDefault(flavor => flavor.FlavorId == id);
      if (thisFlavor == null)
      {
        return RedirectToAction("Details", new {id = id});
      }
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name"); // thing that comes after ViewBag. is the name of your viewbag. Selectlist object takes 3 arguments: all the data that you want included, what value you want this clickable 'Name' to have, what you want displayed to user
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor, int TreatId)
    {
      if (TreatId != 0)
      {
        _db.FlavorTreat.Add(new FlavorTreat() { TreatId = TreatId, FlavorId = flavor.FlavorId });
      }
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}