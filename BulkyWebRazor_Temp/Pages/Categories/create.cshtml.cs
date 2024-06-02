using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class createModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public createModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void onGet()
        {

        }

        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Successfully created a category!";
            return RedirectToPage("Index");
        }
    }
}
