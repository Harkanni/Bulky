using BulkyBook.DataAcess.Data;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using BulkyBook.DataAccess.Repository.IRepository;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategory = _unitOfWork.Category.GetAll().ToList();
            return View(objCategory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name directly matches the Display order. Try again!");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View(category);
        }



        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDB = _unitOfWork.Category.Get(u => u.Id == id);
            //Category? categoryFromDB2 = _db.Categories.FirstOrDefault(U => U.Id == id);
            //Category? categoryfromdb3 = _db.Categories.Where(category => category.Id == id).FirstOrDefault();

            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Successfully updated category!";
                return RedirectToAction("Index", "Category");
            }
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDB = _unitOfWork.Category.Get(u => u.Id == id);

            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Category categoryFromDB = _unitOfWork.Category.Get(u => u.Id == id);
            _unitOfWork.Category.Delete(categoryFromDB);
            _unitOfWork.Save();
            TempData["success"] = "Successfully deleted category";
            return RedirectToAction("Index", "Category");
        }
    }
}
