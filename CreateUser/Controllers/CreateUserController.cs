using CreateUser.Context;
using Microsoft.AspNetCore.Mvc;

namespace CreateUser.Controllers
{
    public class CreateUserController : Controller
    {

        private readonly ApplicationDbContext _db;
        public CreateUserController(ApplicationDbContext db)
        {
            _db = db;
        }

        //action ==> view 
        public IActionResult Index()
        {
            var user = _db.createUser.ToList();
            return View(user);
        }
        public IActionResult Detail(int Id)
        {
            var create = _db.createUser.Find(Id);
            return View(create);

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUser cer)
        {
            if (ModelState.IsValid)
            {
                _db.createUser.Add(cer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cer);

        }

        public IActionResult Update(int Id)
        {
            var cat = _db.createUser.Find(Id);

            return View(cat);
        }
        [HttpPost]
        public IActionResult Update(CreateUser cre)
        {
          
            _db.createUser.Update(cre);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var car = _db.createUser.Find(Id);
            _db.createUser.Remove(car);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

