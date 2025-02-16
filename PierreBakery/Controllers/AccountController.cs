using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using PierreBakery.Models;
using System.Threading.Tasks;
using PierreBakery.ViewModels;

namespace PierreBakery.Controllers
{
  public class AccountController : Controller
  {
    private readonly PierreBakeryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PierreBakeryContext db)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _db = db;
    }

    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> LogOff()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index");
    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {   System.Console.WriteLine($"{model.Email}, {model.Password}");
        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
        System.Console.WriteLine($"{result.Succeeded}");
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }
        else
        {
            System.Console.WriteLine("View showing");
            return View();
        }
    }
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register (RegisterViewModel model)
    {
        var user = new ApplicationUser { UserName = model.Email };
        IdentityResult result = await _userManager.CreateAsync(user, model.Password);//
        if (result.Succeeded)//(true) 
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }
  }
}
