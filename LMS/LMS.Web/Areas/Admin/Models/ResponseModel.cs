namespace LMS.Web.Areas.Admin.Models
{
    public enum ResponseTypes
    {
        Success,
        Denger
    }
    public class ResponseModel
    {
        public string? Message { get; set; }
        public ResponseTypes Type { get; set; }
    }
}
