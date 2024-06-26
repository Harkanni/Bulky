using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [BindProperties]
    public class ProductController : Controller
    {

        private IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public IActionResult Index()
        {
            List<Product> Products = _unitOfWork.Product.GetAll().ToList();
            return View(Products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product.Author == product.Description.ToString())
            {
                ModelState.AddModelError("name", "The Author directly matches the Description. Try again!");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("Index", "Product");
            }
            return View(product);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? productFromDB = _unitOfWork.Product.Get(u => u.PId == id);

            if (productFromDB == null)
            {
                return NotFound();
            }
            return View(productFromDB);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Product productFromDB = _unitOfWork.Product.Get(u => u.PId == id);
            _unitOfWork.Product.Delete(productFromDB);
            _unitOfWork.Save();
            TempData["success"] = "Successfully deleted category";
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? productFromDB = _unitOfWork.Product.Get(u => u.PId == id);
            //Category? categoryFromDB2 = _db.Categories.FirstOrDefault(U => U.Id == id);
            //Category? categoryfromdb3 = _db.Categories.Where(category => category.Id == id).FirstOrDefault();

            if (productFromDB == null)
            {
                return NotFound();
            }
            return View(productFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Successfully updated category!";
                return RedirectToAction("Index", "Product");
            }
            return View(product);
        }

    }
}

