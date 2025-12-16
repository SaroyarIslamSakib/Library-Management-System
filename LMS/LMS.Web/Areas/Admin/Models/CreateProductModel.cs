using System.ComponentModel.DataAnnotations;

namespace LMS.Web.Areas.Admin.Models
{
    public class CreateProductModel
    {
        [Required]
        public string Name { get; set; }
        [Range(1,1000, ErrorMessage ="Price should be between 1 to 1000")]
        public decimal Price { get; set; }
        [Length(1, 500)]
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
