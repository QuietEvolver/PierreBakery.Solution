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
  public class EmployeesController : Controller
  {
    private readonly PierreBakeryContext _db;

    public EmployeesController(PierreBakeryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Employee> model = _db.Employees.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Employee employee)
    {
      _db.Employees.Add(employee);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        var thisEmployee = _db.Employees
            .Include(employee => employee.Kinds)
            .ThenInclude(join => join.Kind)
            .FirstOrDefault(employee => employee.EmployeeId == id);
        return View(thisEmployee);
    }
    public ActionResult AddKind(int id)
    {
        var thisEmployee = _db.Employees.FirstOrDefault(employees => employees.EmployeeId == id);
        ViewBag.KindId = new SelectList(_db.Kinds, "KindId", "KindId");
        return View(thisEmployee);
    }
    [HttpPost]
    public ActionResult AddKind(Employee employee, int KindId)
    {
        if (KindId != 0)
        {
        _db.EmployeeKind.Add(new EmployeeKind() { KindId = KindId, EmployeeId = employee.EmployeeId });
        }
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      var thisEmployee = _db.Employees.FirstOrDefault(employee => employee.EmployeeId == id);
      return View(thisEmployee);
    }

    [HttpPost]
    public ActionResult Edit(Employee employee)
    {
      _db.Entry(employee).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisEmployee = _db.Employees.FirstOrDefault(employee => employee.EmployeeId == id);
      return View(thisEmployee);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEmployee = _db.Employees.FirstOrDefault(employee => employee.EmployeeId == id);
      _db.Employees.Remove(thisEmployee);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
