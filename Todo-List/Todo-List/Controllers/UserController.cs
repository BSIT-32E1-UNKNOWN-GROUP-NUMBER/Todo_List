using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Todo_List.Models;
using Todo_List.Data;
using Microsoft.EntityFrameworkCore;

namespace Todo_List.Controllers
{
    public class UserController : Controller
    {
        private readonly TaskContext _context;

        public UserController(TaskContext context)
        {
            _context = context;
        }

        // GET: User/Create
        public IActionResult Create()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.UserID = userId;
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        // GET: User/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user == null)
            {
     
                return View();
            }


            HttpContext.Session.SetInt32("UserId", user.UserId); 
            return RedirectToAction("Task", "Home");
        }
    }


}