using Microsoft.AspNetCore.Mvc;
using PierreBakery.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierreBakery.Controllers
{
  [Authorize]
  public class TypesController : Controller
  {
    private readonly PierreBakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TypesController(UserManager<ApplicationUser> userManager, PierreBakeryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        var userTypes = _db.Types.Where(entry => entry.User.Id == currentUser.Id);
        return View(userTypes);
    }

    public ActionResult AddEmployee(int id)
    {
        var thisType = _db.Types.FirstOrDefault(types => types.TypeId == id);
        ViewBag.EmployeeId = new SelectList(_db.Employees, "EmployeeId", "Name");
        return View(thisType);
    }

    [HttpPost]
    public ActionResult AddEmployee(Type type, int EmployeeId)
    {
        if (EmployeeId != 0)
        {
        _db.EmployeeType.Add(new EmployeeType() { EmployeeId = EmployeeId, TypeId = type.TypeId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Create()
    {
        ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Title");
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Type type, int EmployeeId)
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        type.User = currentUser;
        _db.Types.Add(type);
        if (EmployeeId != 0)
        {
            _db.EmployeeType.Add(new EmployeeType() { EmployeeId = EmployeeId, TypeId = type.TypeId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        var thisType = _db.Types
            .Include(type => type.Employees)
            .ThenInclude(join => join.Employee)
            .FirstOrDefault(type => type.TypeId == id);
        return View(thisType);
    }

    public ActionResult Edit(int id)
    {
      var thisType = _db.Types.FirstOrDefault(types => types.TypeId == id);
      ViewBag.EmployeeId = new SelectList(_db.Employees, "EmployeeId", "Name");
      return View(thisType);
    }

    [HttpPost]
    public ActionResult Edit(Type type, int EmployeeId)
    {
      if (EmployeeId != 0)
      {
        _db.EmployeeType.Add(new EmployeeType() { EmployeeId = EmployeeId, TypeId = type.TypeId });
      }
      _db.Entry(type).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisType = _db.Types.FirstOrDefault(types => types.TypeId == id);
      return View(thisType);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisType = _db.Types.FirstOrDefault(types => types.TypeId == id);
      _db.Types.Remove(thisType);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteEmployee(int joinId)
    {
        var joinEntry = _db.EmployeeType.FirstOrDefault(entry => entry.EmployeeTypeId == joinId);
        _db.EmployeeType.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}
