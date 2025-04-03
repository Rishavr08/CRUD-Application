using bulkyweb.Models;
using Microsoft.AspNetCore.Mvc;
using bulkyweb.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace bulkyweb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext _db;

        public CategoryController(ApplicationContext db)
        {
            _db = db;  
        
        }
        public IActionResult Index()
        {
            List<Category> objCategoriesList= _db.Categories.ToList();
            return View(objCategoriesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category? CategoryfromDB = _db.Categories.Find(id);
            if (CategoryfromDB == null)
            {
                return NotFound();
            }
            return View(CategoryfromDB);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category? CategoryfromDB = _db.Categories.Find(id);
            if (CategoryfromDB == null)
            {
                return NotFound();
            }
            return View(CategoryfromDB);
        }

        [HttpPost]
        public IActionResult Create( Category obj)
        {
            if( obj.DisplayOrder.ToString()== obj.Name)
            {
                ModelState.AddModelError("name", "The Display order and Name can not be exactly the same.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.DisplayOrder.ToString() == obj.Name)
            {
                ModelState.AddModelError("name", "The Display order and Name can not be exactly the same.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)

        {
            Category? obj = _db.Categories.Find(id);
            if (id == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }

    }
}
