using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductController : Controller
    {

        private IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IActionResult Page()
        {
            List<Product> Products = _unitOfWork.Product.GetAll().ToList();
            return View(Products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
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
    }
}
