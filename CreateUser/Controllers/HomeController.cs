using CreateUser.Context;
using CreateUser.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CreateUser.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;


        public HomeController(ApplicationDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var users = _db.user
              .Include(t => t.user)
              .Where(t => t.UserId == userId)
              .ToList();

            return View(users);
        }

        public IActionResult Details(int id)
        {
            var create = _db.user.Include(w => w.createUser).FirstOrDefault(t => t.Id == id);
            return View(create);

        }
        public IActionResult Create()
        {
            var create= new SelectList(_db.createUser, "Id", "Name");
            

            ViewBag.UserList = create;

            return View();
        }

        [HttpPost]
        public IActionResult Create( CreateUser obj)
        {
            if (ModelState.IsValid)
            {
                obj.Id = _userManager.GetUserId(createUser);
                _db.user.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            var cats = new SelectList(_db.createUser, "Id", "Name");
            ViewBag.UserList = cats;

            return View(obj);
        }

        public IActionResult Update(int id)
        {
            var user = _db.user.Include(w => w.CreateUser).FirstOrDefault(t => t.Id == id);
            var create = new SelectList(_db.createUser, "Id", "Name");
           

            ViewBag.UserList = user;
            return View(create);
        }
        [HttpPost]
        public IActionResult Update(User obj)
        {
            obj.Id = _userManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                _db.user.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            var create = new SelectList(_db.createUser, "Id", "Name");
            ViewBag.UserList = create;

            return View(obj);
        }
    }
}
