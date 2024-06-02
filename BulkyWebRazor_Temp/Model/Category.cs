using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWebRazor_Temp.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(255)]
        public required string Name { get; set; }
        [Range(1, 100, ErrorMessage = "Must be between 1 - 100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
