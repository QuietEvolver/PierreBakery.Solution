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
            .Include(employee => employee.Types)
            .ThenInclude(join => join.Type)
            .FirstOrDefault(employee => employee.EmployeeId == id);
        return View(thisEmployee);
    }
    public ActionResult AddType(int id)
    {
        var thisEmployee = _db.Employees.FirstOrDefault(employees => employees.EmployeeId == id);
        ViewBag.TypeId = new SelectList(_db.Types, "TypeId", "TypeId");
        return View(thisEmployee);
    }
    [HttpPost]
    public ActionResult AddType(Employee employee, int TypeId)
    {
        if (TypeId != 0)
        {
        _db.EmployeeType.Add(new EmployeeType() { TypeId = TypeId, EmployeeId = employee.EmployeeId });
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
