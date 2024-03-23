using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Todo_List.Models;
using Todo_List.Data;
using System.Linq;

namespace Todo_List.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TaskContext _context;

        public HomeController(ILogger<HomeController> logger, TaskContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                
                return View();
            }

            var user = _context.Users.Find(userId.Value); 
            if (user != null)
            {
                ViewBag.Username = user.Username; 
            }

            var tasks = _context.Tasks.Where(t => t.UserId == userId.Value).ToList(); 
            return View(tasks); 
        }


        public IActionResult Task()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return View();
            }

            var user = _context.Users.Find(userId.Value); 
            if (user != null)
            {
                ViewBag.Username = user.Username; 
            }

            var tasks = _context.Tasks.Where(t => t.UserId == userId.Value).ToList();
            return View(tasks);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index"); 
        }
    }
}