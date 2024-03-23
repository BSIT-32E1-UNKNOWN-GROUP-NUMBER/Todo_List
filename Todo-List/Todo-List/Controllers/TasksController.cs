using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Todo_List.Models;
using Todo_List.Data;

namespace Todo_List.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {

                return View();
            }

            var tasks = await _context.Tasks
                .Where(t => t.UserId == userId.Value)
                .ToListAsync();

            return View(tasks);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,DueDate,PriorityLevel,IsComplete,Category")] TaskModel task)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32("UserId");
                if (userId == null)
                {

                    return RedirectToAction("Index", "Home");
                }

                task.UserId = userId.Value;
                _context.Add(task);
                await _context.SaveChangesAsync();

             
                return RedirectToAction("Task", "Home");
            }
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                // User is not logged in, redirect to login page
                return View();
            }

            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId.Value);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // GET: Tasks/GetTask/5
        [HttpGet]
        public async Task<IActionResult> GetTask(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                // User is not logged in, redirect to login page
                return View();
            }

            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId.Value);

            if (task == null)
            {
                return NotFound();
            }

            return Json(task);
        }


        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromBody][Bind("Id,Description,DueDate,PriorityLevel,IsComplete,Category")] TaskModel taskModel)
        {
            if (id != taskModel.Id)
            {
                return NotFound();
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
           
                return RedirectToAction("Index", "Home");
            }

            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId.Value);
            if (task == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    task.Description = taskModel.Description;
                    task.DueDate = taskModel.DueDate;
                    task.PriorityLevel = taskModel.PriorityLevel;
                    task.CompletionStatus = taskModel.CompletionStatus;
                    task.Category = taskModel.Category;

             
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
               
                return View();
            }

            var task = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId.Value);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

     
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
               
                return View();
            }

            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId.Value);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}