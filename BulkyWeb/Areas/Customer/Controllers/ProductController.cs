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
    }
}
