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
  public class ViewAllController : Controller
  {
    private readonly PierreBakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public ViewAllController(UserManager<ApplicationUser> userManager, PierreBakeryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
        ViewBag.allTreats = _db.Treats.ToList();
        ViewBag.allFlavors = _db.Flavors.ToList();
        return View();
    }
  }
}  