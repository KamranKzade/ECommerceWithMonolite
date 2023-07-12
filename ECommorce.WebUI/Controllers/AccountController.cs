using ECommorce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using ECommorce.WebUI.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommorce.WebUI.Controllers;

public class AccountController : Controller
{
    private UserManager<CustomIdentityUser> _userManager;
    private RoleManager<CustomIdentityRole> _roleManager;
    private SignInManager<CustomIdentityUser> _signInManager;

    public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    // GET: AccountController
    [HttpGet]
    public ActionResult LogIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> LogIn(LogInViewModel logInViewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(logInViewModel.UserName, logInViewModel.Password, logInViewModel.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Admin");
            }
        }
        return View();
    }

    [HttpGet]
    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            CustomIdentityUser user = new()
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    CustomIdentityRole role = new()
                    {
                        Name = "Admin"
                    };

                    IdentityResult roleResult = await _roleManager.CreateAsync(role);

                    if (!roleResult.Succeeded)
                    {
                        ModelState.AddModelError("", "we can nit add the role");
                        return View(registerViewModel);
                    }
                }

                await _userManager.AddToRoleAsync(user, "Admin");
                return RedirectToAction("LogIn", "Account");
            }
        }
        return View(registerViewModel);
    }


    // GET: AccountController
    public async Task<ActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("LogIn","Account");
    }

}
