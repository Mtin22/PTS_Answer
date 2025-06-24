using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_App.Models; // Make sure you import your models

namespace MVC_App.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        // Inject the context to access the database
        public LoginController(Context context)
        {
            _context = context;
        }

        public IActionResult Login_Page()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login_Page(string username, string password)
        {
            var user = await _context.Register
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user != null && user.Password == password)
            {
                HttpContext.Session.SetString("User", username);

                return RedirectToAction("Students", "Student");
            }
            return View();
        }
    }
}

