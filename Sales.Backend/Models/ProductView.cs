namespace Sales.Backend.Models
{
    using System.Web;
    using Common.Models;
    

    public class ProductView:Products
    {
        public HttpPostedFileBase ImageFile { get; set; }
    }
}