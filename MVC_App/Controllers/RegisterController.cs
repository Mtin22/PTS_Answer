using Microsoft.AspNetCore.Mvc;
using MVC_App.Models;

namespace MVC_App.Controllers
{
    public class RegisterController : Controller
    {
        private readonly Context _context;

        public RegisterController(Context context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register user)
        {
            if (ModelState.IsValid)
            {
                _context.Register.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login_Page", "Login");
            }
            return View(user);
        }
    }
}