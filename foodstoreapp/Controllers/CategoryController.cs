using foodstoreapp.Data;
using foodstoreapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace foodstoreapp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        // Внедряем зависимость ApplicationDbContext через конструктор
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // Создаем список записей категорий из базы данных
            IEnumerable<category> categoryList = _db.category;
            // Возвращаем загруженный список в представление
            return View(categoryList);
        }
        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(category cat)
        {
            if (ModelState.IsValid)
            {
                _db.category.Add(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.category.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(category cat)
        {
            if (ModelState.IsValid)
            {
                _db.category.Update(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cat = _db.category.Find(id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var cat = _db.category.Find(id);
            if (cat == null)
            {
                return NotFound();
            }
            _db.category.Remove(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }

}

