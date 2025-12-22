namespace LMS.Web.Areas.Admin.Models
{
    public class ProductAdvanceSearchModel
    {
        public string Name { get; set; }
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
        public bool IsAvailable { get; set; }
    }
}
