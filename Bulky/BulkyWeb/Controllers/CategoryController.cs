using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Cateogry Name cannot match the Display Name");
            }
            if (obj.Name != null && obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("name", "Test is an invalid value");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            
            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) { return NotFound(); }

            // made this field nullable in order to remove warnings since we have logic checks
            // Find() only works with Primary Key
            Category? categoryFromDb = _db.Categories.Find(id);

            // other options for record retrieval
            // Category? categoryFromDb2 = _db.Categories.FirstOrDefault(u => u.Id == id); *this is a very good option
            // Category? categoryFromDb3 = _db.Categories.Where(u => u.Id == id).FirstOrDefault(); *this option is usually used when multiple attributes need to be considered in the Where()

            if (categoryFromDb == null) { return NotFound(); }

            // passing this obj allows ASP to populate fields in HTML on page load.
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                // using .Update allows for ease of updating record based on the ID from the obj passed
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }

            Category? categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null) { return NotFound(); }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null) { return NotFound(); }

            _db.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
