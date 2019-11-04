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
  public class TreatFlavorController : Controller
  {
    private readonly PierreBakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatFlavorController(UserManager<ApplicationUser> userManager, PierreBakeryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        var userTreatFlavor = _db.TreatFlavor.Where(entry => entry.User.Id == currentUser.Id);
        return View(userTreatFlavor);
    }

    // public ActionResult AddEmployee(int id)
    // {
    //     var thisKind = _db.Kinds.FirstOrDefault(kinds => kinds.KindId == id);
    //     ViewBag.EmployeeId = new SelectList(_db.Employees, "EmployeeId", "Name");
    //     return View(thisKind);
    // }

    // [HttpPost]
    // public ActionResult AddEmployee(Kind kind, int EmployeeId)
    // {
    //     if (EmployeeId != 0)
    //     {
    //     _db.EmployeeKind.Add(new EmployeeKind() { EmployeeId = EmployeeId, KindId = kind.KindId });
    //     }
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }

    public ActionResult Create()
    {
        ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Title");
        ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
        return View();
    }

    // [HttpPost]
    // public async Task<ActionResult> Create(Kind kind, int EmployeeId)
    // {
    //     var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    //     var currentUser = await _userManager.FindByIdAsync(userId);
    //     kind.User = currentUser;
    //     _db.Kinds.Add(kind);
    //     if (EmployeeId != 0)
    //     {
    //         _db.EmployeeKind.Add(new EmployeeKind() { EmployeeId = EmployeeId, KindId = kind.KindId });
    //     }
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }

    // public ActionResult Details(int id)
    // {
    //     var thisKind = _db.Kinds
    //         .Include(kind => kind.Employees)
    //         .ThenInclude(join => join.Employee)
    //         .FirstOrDefault(kind => kind.KindId == id);
    //     return View(thisKind);
    // }

    // public ActionResult Edit(int id)
    // {
    //   var thisKind = _db.Kinds.FirstOrDefault(kinds => kinds.KindId == id);
    //   ViewBag.EmployeeId = new SelectList(_db.Employees, "EmployeeId", "Name");
    //   return View(thisKind);
    // }

    // [HttpPost]
    // public ActionResult Edit(Kind kind, int EmployeeId)
    // {
    //   if (EmployeeId != 0)
    //   {
    //     _db.EmployeeKind.Add(new EmployeeKind() { EmployeeId = EmployeeId, KindId = kind.KindId });
    //   }
    //   _db.Entry(kind).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Delete(int id)
    // {
    //   var thisKind = _db.Kinds.FirstOrDefault(kinds => kinds.KindId == id);
    //   return View(thisKind);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   var thisKind = _db.Kinds.FirstOrDefault(kinds => kinds.KindId == id);
    //   _db.Kinds.Remove(thisKind);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // [HttpPost]
    // public ActionResult DeleteEmployee(int joinId)
    // {
    //     var joinEntry = _db.EmployeeKind.FirstOrDefault(entry => entry.EmployeeKindId == joinId);
    //     _db.EmployeeKind.Remove(joinEntry);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }
  }
}
