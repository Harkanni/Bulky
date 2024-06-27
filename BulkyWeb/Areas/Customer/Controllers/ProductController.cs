using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBook.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [BindProperties]
    public class ProductController : Controller
    {

        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> Products = _unitOfWork.Product.GetAll().ToList();

            return View(Products);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
                return View(productVM);

            else
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.PId == id);
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM OBJ, IFormFile file)
        {
            if (OBJ.Product.Author == OBJ.Product.Description.ToString())
            {
                ModelState.AddModelError("name", "The Author directly matches the Description. Try again!");
            }
            if (ModelState.IsValid)
            {
                string wwwRoothPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRoothPath, @"images\products");

                    if(!string.IsNullOrEmpty(productPath))
                    {
                        // delete old image
                        var oldImagePath = Path.Combine(wwwRoothPath, OBJ.Product.ImageUrl.TrimStart('\\'));

                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }



                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.CreateNew))
                    {
                        file.CopyTo(fileStream);
                    }

                    OBJ.Product.ImageUrl = @"\images\products\" + fileName;
                }


                _unitOfWork.Product.Add(OBJ.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index", "Product");
            }
            return View(OBJ);
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
    }
}

