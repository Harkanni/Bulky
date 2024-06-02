using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public Category? Category { get; set; }

        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;
        }


        public void OnGet(int id)
        {
            Category = _db.Categories.FirstOrDefault(c => c.Id == id);
        }

        public IActionResult OnPost(int? id)
        {
            Category? categoryFromDB = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(categoryFromDB);
            _db.SaveChanges();
            TempData["success"] = "Successfully removed category";
            return RedirectToPage("Index");

        }
    }
}
