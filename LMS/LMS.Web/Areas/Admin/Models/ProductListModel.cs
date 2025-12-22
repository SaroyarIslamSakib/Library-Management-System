using LMS.Domain;

namespace LMS.Web.Areas.Admin.Models
{
    public class ProductListModel : DataTables
    {
        public ProductAdvanceSearchModel SearchItem { get; set; }
    }
}
